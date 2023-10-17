using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheHightSchoolOfAvellanedaSystem.Abstraction;
using TheHightSchoolOfAvellanedaSystem.Domain;
using TheHightSchoolOfAvellanedaSystem.Repository;
using TheHightSchoolOfAvellanedaSystem.Services;

namespace TheHightSchoolOfAvellanedaSystem.AplicationService
{
    public class DVAppService
    {
        // FRAGMENTO DE CODIGO DE PRUEBA PARA REALIZAR LA COMPROBACIÓN DEL TOTAL DE LOS DIGITOVERIFICADORES
        private bool estado = false;
        private IDVRepository _DVrepo;
        public DVAppService() 
        {
            _DVrepo = new DVRepository();   
        }

        public List<Digitoverificador> GetAll()
        {
            return (List<Digitoverificador>)_DVrepo.GetAll();
        }

        public bool verificarConsistenciaDB( )
        {
            try
            {
                DataTable dtUsers = VerificarIntegridadenBD("Usuario");
                if (dtUsers.Rows.Count > 0) { throw new Exception("Se ha detectado inconsistencia en los digitos verificadores horizontales de la tabla usuarios"); }
                //DataTable dtBitacora = VerificarIntegridadenBD("Bitacora");
                //if (dtBitacora.Rows.Count > 0) { throw new Exception("Se ha detectado insconsistencia en los digitos verificadores horizontales de la tabla bitacora"); }
                //DataTable dtMovimientos = VerificarIntegridadenBD("Movimiento");
                //if (dtMovimientos.Rows.Count > 0) { throw new Exception("Se ha detectado insconsistencia en los digitos verificadores horizontales de la tabla Movimientos"); }
                return estado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable verificarCosistencia()
        {
            DataTable dt = VerificarIntegridadenBD("Usuario");
            VerificarIntegridadenBD("Bitacora");
            //VerificarIntegridadenBD("Movimiento");
            if (dt.Rows.Count > 0) { return dt; }
            throw new Exception("No hay registros para reparar");
        }


        public int UpdateDV(DataTable dt)
        {
            if (dt.Rows.Count == 0) {throw new Exception("No hay registros para reparar.");}
            else
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["TABLA"].ToString() == "Usuario")
                    {
                        UsuarioAppService usuario = new UsuarioAppService();
                        usuario.UpdateDVH(Convert.ToInt16(dt.Rows[i][2]), Convert.ToInt16(dt.Rows[i][1]));
                        //ahora toca reparar las dvv, porque ya cambiaron
                        string tablaUsers = "Usuario";
                        int DVVUsers = _DVrepo.ObtenerSumDVH("dvh", tablaUsers);
                        Domain.Digitoverificador dv = new Domain.Digitoverificador();
                        dv.dvv = DVVUsers;
                        dv.tabla = tablaUsers;
                        _DVrepo.Update(dv);
                    }
                    else if (dt.Rows[i]["TABLA"].ToString() == "Bitacora")
                    {
                        BitacoraAppService bitacora = new BitacoraAppService();
                        bitacora.UpdateDVH(Convert.ToInt16(dt.Rows[i][2]), Convert.ToInt16(dt.Rows[i][1]));
                    }
                    else if (dt.Rows[i]["TABLA"].ToString() == "Movimiento")
                    {
                        MovimientosAppService movimientos = new MovimientosAppService();
                        movimientos.UpdateDVH(Convert.ToInt16(dt.Rows[i][2]), Convert.ToInt16(dt.Rows[i][1]));
                    }
                }
            }
            return 0;
        }

        //public DataTable verificarCosistencia()
        //{
        //    DataTable dt = VerificarIntegridadenBD("Usuario");
        //    dt = VerificarIntegridadenBD("Bitacora");
        //    dt = VerificarIntegridadenBD("Movimientos");
        //    if (dt.Rows.Count > 0) { return dt; }
        //    throw new Exception("No hay registros para reparar");
        //} 

        public DataTable VerificarIntegridadenBD(string tabla)
        {
            List<Digitoverificador> ListaDVs = (List<Digitoverificador>)_DVrepo.GetAll();  
            //int DVHActual;
            //int DVHCorrecto;
            DataTable RegistrosAfectadosDT = new DataTable(); // Declaro un datatable para guardar los registros afectados en caso de 
            RegistrosAfectadosDT.Columns.Add("TABLA"); // que surjan errores en los DV
            RegistrosAfectadosDT.Columns.Add("ID_de_REGISTRO");
            RegistrosAfectadosDT.Columns.Add("DV_CORRECTO");
            // linea generada para comparar los DV generados y los existentes en la BD 
            RegistrosAfectadosDT.Columns.Add("DV_DELABD");
            if (tabla == "Usuario")
            {
                UsuarioAppService listaUsuarios = new UsuarioAppService();
                //Lista queb se modifica 
                List<Domain.Usuario> usuarios = listaUsuarios.GetAll();
                List<Domain.Usuario> usuariosParaComparar = new List<Domain.Usuario>();
                foreach (var item in usuarios)
                {
                    usuariosParaComparar.Add((Domain.Usuario)(Services.Usuario.SetDVH(item)));

                }
                //Lista pura
                List<Domain.Usuario> usuariosDeBD = listaUsuarios.GetAll();

                foreach (var item in usuariosDeBD)
                {
                    foreach (var item2 in usuariosParaComparar)
                    {
                        if (item.Id == item2.Id)
                        {
                            if (item.dvh == item2.dvh) { }
                            else
                            {
                                DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
                                //ObtenerRegistrosUsuarioDT(3) = item2.Usuario_DVH;
                                RegistroAfectadoR[0] = "Usuario";
                                RegistroAfectadoR[1] = item2.Id;
                                RegistroAfectadoR[2] = item2.dvh;
                                RegistroAfectadoR[3] = item.dvh;
                                RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
                            }
                        }
                        else { }
                    }
                }
                //Verifico los DVV de la tabla usuarios
                int DVVObtenido = _DVrepo.ObtenerSumDVH("dvh", tabla);
                foreach (var item in ListaDVs)
                {
                    if (item.tabla == tabla)
                    {
                        if (item.dvv == DVVObtenido) { }
                        else { throw new Exception("Se ha detectado inconsistencia en los digitos verificadores verticales de la tabla usuarios"); }
                    }
                }
            }
            else if (tabla == "Bitacora")
            {
                BitacoraAppService listaBitacoras = new BitacoraAppService();
                //Lista que se modifica 
                List<Domain.Bitacora> bitacoras = (List<Domain.Bitacora>)listaBitacoras.GetAll();
                List<Domain.Bitacora> bitacorasParaComparar = new List<Domain.Bitacora>();
                foreach (var item in bitacoras)
                {
                    bitacorasParaComparar.Add((Domain.Bitacora)(Services.Bitacora.SetDVHViejos(item)));

                }
                //Lista pura
                List<Domain.Bitacora> bitacorasDeBD = (List<Domain.Bitacora>)listaBitacoras.GetAll();


                foreach (var item in bitacorasDeBD)
                {
                    foreach (var item2 in bitacorasParaComparar)
                    {
                        if (item.Id == item2.Id)
                        {
                            if (item.dvh == item2.dvh) { }
                            else
                            {
                                DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
                                //ObtenerRegistrosUsuarioDT(3) = item2.Usuario_DVH;
                                RegistroAfectadoR[0] = "Bitacora";
                                RegistroAfectadoR[1] = item2.Id;
                                RegistroAfectadoR[2] = item2.dvh;
                                RegistroAfectadoR[3] = item.dvh;
                                RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
                            }
                        }
                        else { }
                    }
                }
                //Verifico los DVV de la tabla bitacora
                int DVVObtenido = _DVrepo.ObtenerSumDVH("dvh", tabla);
                foreach (var item in ListaDVs)
                {
                    if (item.tabla == tabla)
                    {
                        if (item.dvv == DVVObtenido) { }
                        else { throw new Exception("Se ha detectado inconsistencia en los digitos verificadores verticales de la tabla bitacora"); }
                    }
                }
            }
            //else if (tabla == "Movimiento")
            //{
            //    MovimientosAppService listaMovimientos = new MovimientosAppService();
            //    //Lista que se modifica 
            //    List<Domain.Movimientos> movimientos = (List<Domain.Movimientos>)listaMovimientos.GetAll();
            //    List<Domain.Movimientos> movimientosParaComparar = new List<Domain.Movimientos>();
            //    foreach (var item in movimientos)
            //    {
            //        movimientosParaComparar.Add((Domain.Movimientos)(Services.Movimientos.SetDVHViejos(item)));
            //    }
            //    //Lista pura
            //    List<Domain.Movimientos> movimientosDeBD = (List<Domain.Movimientos>)listaMovimientos.GetAll();

            //    foreach (var item in movimientosDeBD)
            //    {
            //        foreach (var item2 in movimientosParaComparar)
            //        {
            //            if (item.dvh == item2.dvh)
            //            {
            //                if (item.dvh == item2.dvh) { }
            //                else
            //                {
            //                    DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //                    //ObtenerRegistrosUsuarioDT(3) = item2.Usuario_DVH;
            //                    RegistroAfectadoR[0] = "Movimiento";
            //                    RegistroAfectadoR[1] = item2.Id;
            //                    RegistroAfectadoR[2] = item2.descripcion;
            //                    RegistroAfectadoR[3] = item.dvh;
            //                    RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
            //                }
            //            }
            //            else
            //            { }
            //        }
            //    }
            //    //Verifico los DVV de la tabla movimientos
            //    int DVVObtenido = _DVrepo.ObtenerSumDVH("dvh", tabla);
            //    foreach (var item in ListaDVs)
            //    {
            //        if (item.tabla == tabla)
            //        {
            //            if (item.dvv == DVVObtenido) { }
            //            else { throw new Exception("Se ha detectado inconsistencia en los digitos verificadores verticales de la tabla movimientos"); }
            //        }
            //    }
            //}
                        
            //else if (tabla == "Estado")
            //{
            //    DV ObtenerReg = new DV();
            //    // --------------------------------------------------------------------------------------------------------
            //    // ///Comienzo de Digitoverificacion de REGISTROS para Tabla Estado
            //    DataTable ObtenerRegistrosUsuarioDT = new DataTable();
            //    ObtenerRegistrosUsuarioDT = ObtenerReg.Traer_DigitosverificadoresDB("Estado").Copy;
            //    ObtenerRegistrosUsuarioDT.Columns.Add("DV_CORRECTO");
            //    for (var r = 0; r <= ObtenerRegistrosUsuarioDT.Rows.Count - 1; r++) // --Ciclo que concatena tupla x tupla para luego obtener el dv de cada tupla
            //    {
            //        // ARMO UNA CADENA POR CADA TUPLA QUE ME SURGE DE LA CONSULTA (SELECT *) REALIZADA
            //        CadenaDVActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Est_Id").ToString.Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Est_Desc").ToString().Trim;
            //        string[] CadenaFinal = new string[CadenaDVActual.Count().ToString() + 1];
            //        string valor;
            //        string StringFinal;
            //        StringFinal = null;
            //        for (int i = 0; i <= CadenaDVActual.Count().ToString() - 1; i++) // ciclo que cuenta la cant de caracteres de la CadenadeCaracteres
            //        {
            //            valor = CadenaDVActual[i]; // Separa el valor en particular de un caracter
            //            if (Information.IsNumeric(valor))
            //            {
            //                valor = CadenaDVActual[i]; // Pero pone ese valor numerico en la posición del vector correspondiente
            //                CadenaFinal[i] = valor; // Y por último en la CadenaFinal  
            //            }
            //            else
            //            {
            //                valor = Strings.Asc(valor);
            //                CadenaFinal[i] = valor; // Y lo coloco en la posición del vector que corresponda
            //            }
            //            StringFinal = Strings.Join(CadenaFinal, "");
            //        }
            //        // -----COMPARO EL DVH QUE ME TRAE LA CONSULTA CON EL RECIENTEMENTE GENERADO--------------------------
            //        DVHActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Est_DVH").ToString;
            //        DVHCorrecto = ObtenerReg.ActualizarDV(StringFinal);
            //        // ----------------------------------------------------------------------------------------------------
            //        if (DVHActual == DVHCorrecto)
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //        else
            //        {
            //            DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //            RegistroAfectadoR(0) = "Estado_Seguridad";
            //            RegistroAfectadoR(1) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Est_Id").ToString;
            //            RegistroAfectadoR(2) = DVHCorrecto;
            //            RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
            //        }
            //    }
            //}
            //else if (tabla == "Familia")
            //{
            //    DV ObtenerReg = new DV();
            //    // -----------------------------------------------------------------------------------------------------------------------
            //    // ///Comienzo de Digitoverificacion de REGISTROS para Tabla Bitacora
            //    DataTable ObtenerRegistrosUsuarioDT = new DataTable();
            //    ObtenerRegistrosUsuarioDT = ObtenerReg.Traer_DigitosverificadoresDB("Familia").Copy;
            //    ObtenerRegistrosUsuarioDT.Columns.Add("DV_CORRECTO");
            //    for (var r = 0; r <= ObtenerRegistrosUsuarioDT.Rows.Count - 1; r++) // --Ciclo que concatena tupla x tupla para luego obtener el dv de cada tupla
            //    {
            //        // ARMO UNA CADENA POR CADA TUPLA QUE ME SURGE DE LA CONSULTA (SELECT *) REALIZADA
            //        CadenaDVActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Fam_Id").ToString.Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Fam_Desc").ToString().Trim;
            //        string[] CadenaFinal = new string[CadenaDVActual.Count().ToString() + 1];
            //        string valor;
            //        string StringFinal;
            //        StringFinal = null;
            //        for (int i = 0; i <= CadenaDVActual.Count().ToString() - 1; i++) // ciclo que cuenta la cant de caracteres de la CadenadeCaracteres
            //        {
            //            valor = CadenaDVActual[i]; // Separa el valor en particular de un caracter
            //            if (Information.IsNumeric(valor))
            //            {
            //                valor = CadenaDVActual[i]; // Pero pone ese valor numerico en la posición del vector correspondiente
            //                CadenaFinal[i] = valor; // Y por último en la CadenaFinal  
            //            }
            //            else
            //            {
            //                valor = Strings.Asc(valor);
            //                CadenaFinal[i] = valor; // Y lo coloco en la posición del vector que corresponda
            //            }
            //            StringFinal = Strings.Join(CadenaFinal, "");
            //        }
            //        // -----COMPARO EL DVH QUE ME TRAE LA CONSULTA CON EL RECIENTEMENTE GENERADO--------------------------
            //        DVHActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Fam_DVH").ToString;
            //        DVHCorrecto = ObtenerReg.ActualizarDV(StringFinal);
            //        // ----------------------------------------------------------------------------------------------------
            //        if (DVHActual == DVHCorrecto)
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //        else
            //        {
            //            DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //            RegistroAfectadoR(0) = "Familia";
            //            RegistroAfectadoR(1) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Fam_Id").ToString;
            //            RegistroAfectadoR(2) = DVHCorrecto;
            //            RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
            //        }
            //    }
            //}
            //else if (tabla == "Familia_Patente")
            //{
            //    DV ObtenerReg = new DV();
            //    // -----------------------------------------------------------------------------------------------------------------------
            //    // ///Comienzo de Digitoverificacion de REGISTROS para Tabla Bitacora
            //    DataTable ObtenerRegistrosUsuarioDT = new DataTable();
            //    ObtenerRegistrosUsuarioDT = ObtenerReg.Traer_DigitosverificadoresDB("Familia_Patente").Copy;
            //    ObtenerRegistrosUsuarioDT.Columns.Add("DV_CORRECTO");
            //    for (var r = 0; r <= ObtenerRegistrosUsuarioDT.Rows.Count - 1; r++) // --Ciclo que concatena tupla x tupla para luego obtener el dv de cada tupla
            //    {
            //        // ARMO UNA CADENA POR CADA TUPLA QUE ME SURGE DE LA CONSULTA (SELECT *) REALIZADA
            //        CadenaDVActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Pat_Id").ToString.Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Fam_Id").ToString().Trim;
            //        string[] CadenaFinal = new string[CadenaDVActual.Count().ToString() + 1];
            //        string valor;
            //        string StringFinal;
            //        StringFinal = null;
            //        for (int i = 0; i <= CadenaDVActual.Count().ToString() - 1; i++) // ciclo que cuenta la cant de caracteres de la CadenadeCaracteres
            //        {
            //            valor = CadenaDVActual[i]; // Separa el valor en particular de un caracter
            //            if (Information.IsNumeric(valor))
            //            {
            //                valor = CadenaDVActual[i]; // Pero pone ese valor numerico en la posición del vector correspondiente
            //                CadenaFinal[i] = valor; // Y por último en la CadenaFinal  
            //            }
            //            else
            //            {
            //                valor = Strings.Asc(valor);
            //                CadenaFinal[i] = valor; // Y lo coloco en la posición del vector que corresponda
            //            }
            //            StringFinal = Strings.Join(CadenaFinal, "");
            //        }
            //        // -----COMPARO EL DVH QUE ME TRAE LA CONSULTA CON EL RECIENTEMENTE GENERADO--------------------------
            //        DVHActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("FamPat_DVH").ToString;
            //        DVHCorrecto = ObtenerReg.ActualizarDV(StringFinal);
            //        // ----------------------------------------------------------------------------------------------------
            //        if (DVHActual == DVHCorrecto)
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //        else
            //        {
            //            DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //            RegistroAfectadoR(0) = "Familia_Patente";
            //            RegistroAfectadoR(1) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Pat_Id").ToString;
            //            RegistroAfectadoR(2) = DVHCorrecto;
            //            RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
            //        }
            //    }
            //}
            //else if (tabla == "Movimientos")
            //{
            //    DV ObtenerReg = new DV();
            //    // -----------------------------------------------------------------------------------------------------------------------
            //    // ///Comienzo de Digitoverificacion de REGISTROS para Tabla Bitacora
            //    DataTable ObtenerRegistrosUsuarioDT = new DataTable();
            //    ObtenerRegistrosUsuarioDT = ObtenerReg.Traer_DigitosverificadoresDB("Movimientos").Copy;
            //    ObtenerRegistrosUsuarioDT.Columns.Add("DV_CORRECTO");
            //    for (var r = 0; r <= ObtenerRegistrosUsuarioDT.Rows.Count - 1; r++) // --Ciclo que concatena tupla x tupla para luego obtener el dv de cada tupla
            //    {
            //        // ARMO UNA CADENA POR CADA TUPLA QUE ME SURGE DE LA CONSULTA (SELECT *) REALIZADA
            //        CadenaDVActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Mov_Desc").ToString.Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Bit_Id_Mov").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Usu_Id").ToString().Trim;
            //        string[] CadenaFinal = new string[CadenaDVActual.Count().ToString() + 1];
            //        string valor;
            //        string StringFinal;
            //        StringFinal = null;
            //        for (int i = 0; i <= CadenaDVActual.Count().ToString() - 1; i++) // ciclo que cuenta la cant de caracteres de la CadenadeCaracteres
            //        {
            //            valor = CadenaDVActual[i]; // Separa el valor en particular de un caracter
            //            if (Information.IsNumeric(valor))
            //            {
            //                valor = CadenaDVActual[i]; // Pero pone ese valor numerico en la posición del vector correspondiente
            //                CadenaFinal[i] = valor; // Y por último en la CadenaFinal  
            //            }
            //            else
            //            {
            //                valor = Strings.Asc(valor);
            //                CadenaFinal[i] = valor; // Y lo coloco en la posición del vector que corresponda
            //            }
            //            StringFinal = Strings.Join(CadenaFinal, "");
            //        }
            //        // -----COMPARO EL DVH QUE ME TRAE LA CONSULTA CON EL RECIENTEMENTE GENERADO--------------------------
            //        DVHActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Mov_DVH").ToString;
            //        DVHCorrecto = ObtenerReg.ActualizarDV(StringFinal);
            //        // ----------------------------------------------------------------------------------------------------
            //        if (DVHActual == DVHCorrecto)
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //        else
            //        {
            //            DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //            RegistroAfectadoR(0) = "Movimientos";
            //            RegistroAfectadoR(1) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Bit_Id_Mov").ToString;
            //            RegistroAfectadoR(2) = DVHCorrecto;
            //            RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
            //        }
            //    }
            //}
            //else if (tabla == "Patente")
            //{
            //    DV ObtenerReg = new DV();
            //    // -----------------------------------------------------------------------------------------------------------------------
            //    // ///Comienzo de Digitoverificacion de REGISTROS para Tabla Bitacora
            //    DataTable ObtenerRegistrosUsuarioDT = new DataTable();
            //    ObtenerRegistrosUsuarioDT = ObtenerReg.Traer_DigitosverificadoresDB("Patente").Copy;
            //    ObtenerRegistrosUsuarioDT.Columns.Add("DV_CORRECTO");
            //    for (var r = 0; r <= ObtenerRegistrosUsuarioDT.Rows.Count - 1; r++) // --Ciclo que concatena tupla x tupla para luego obtener el dv de cada tupla
            //    {
            //        // ARMO UNA CADENA POR CADA TUPLA QUE ME SURGE DE LA CONSULTA (SELECT *) REALIZADA
            //        CadenaDVActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Pat_Id").ToString.Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Pat_Desc").ToString().Trim;
            //        string[] CadenaFinal = new string[CadenaDVActual.Count().ToString() + 1];
            //        string valor;
            //        string StringFinal;
            //        StringFinal = null;
            //        for (int i = 0; i <= CadenaDVActual.Count().ToString() - 1; i++) // ciclo que cuenta la cant de caracteres de la CadenadeCaracteres
            //        {
            //            valor = CadenaDVActual[i]; // Separa el valor en particular de un caracter
            //            if (Information.IsNumeric(valor))
            //            {
            //                valor = CadenaDVActual[i]; // Pero pone ese valor numerico en la posición del vector correspondiente
            //                CadenaFinal[i] = valor; // Y por último en la CadenaFinal  
            //            }
            //            else
            //            {
            //                valor = Strings.Asc(valor);
            //                CadenaFinal[i] = valor; // Y lo coloco en la posición del vector que corresponda
            //            }
            //            StringFinal = Strings.Join(CadenaFinal, "");
            //        }
            //        // -----COMPARO EL DVH QUE ME TRAE LA CONSULTA CON EL RECIENTEMENTE GENERADO--------------------------
            //        DVHActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Pat_DVH").ToString;
            //        DVHCorrecto = ObtenerReg.ActualizarDV(StringFinal);
            //        // ----------------------------------------------------------------------------------------------------
            //        if (DVHActual == DVHCorrecto)
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //        else
            //        {
            //            DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //            RegistroAfectadoR(0) = "Patente";
            //            RegistroAfectadoR(1) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Pat_Id").ToString;
            //            RegistroAfectadoR(2) = DVHCorrecto;
            //            RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
            //        }
            //    }
            //}
            //else if (tabla == "Usuario_Familia")
            //{
            //    DV ObtenerReg = new DV();
            //    // -----------------------------------------------------------------------------------------------------------------------
            //    // ///Comienzo de Digitoverificacion de REGISTROS para Tabla Bitacora
            //    DataTable ObtenerRegistrosUsuarioDT = new DataTable();
            //    ObtenerRegistrosUsuarioDT = ObtenerReg.Traer_DigitosverificadoresDB("Usuario_Familia").Copy;
            //    ObtenerRegistrosUsuarioDT.Columns.Add("DV_CORRECTO");
            //    for (var r = 0; r <= ObtenerRegistrosUsuarioDT.Rows.Count - 1; r++) // --Ciclo que concatena tupla x tupla para luego obtener el dv de cada tupla
            //    {
            //        // ARMO UNA CADENA POR CADA TUPLA QUE ME SURGE DE LA CONSULTA (SELECT *) REALIZADA
            //        CadenaDVActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Usu_Id").ToString.Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Fam_Id").ToString().Trim;
            //        string[] CadenaFinal = new string[CadenaDVActual.Count().ToString() + 1];
            //        string valor;
            //        string StringFinal;
            //        StringFinal = null;
            //        for (int i = 0; i <= CadenaDVActual.Count().ToString() - 1; i++) // ciclo que cuenta la cant de caracteres de la CadenadeCaracteres
            //        {
            //            valor = CadenaDVActual[i]; // Separa el valor en particular de un caracter
            //            if (Information.IsNumeric(valor))
            //            {
            //                valor = CadenaDVActual[i]; // Pero pone ese valor numerico en la posición del vector correspondiente
            //                CadenaFinal[i] = valor; // Y por último en la CadenaFinal  
            //            }
            //            else
            //            {
            //                valor = Strings.Asc(valor);
            //                CadenaFinal[i] = valor; // Y lo coloco en la posición del vector que corresponda
            //            }
            //            StringFinal = Strings.Join(CadenaFinal, "");
            //        }
            //        // -----COMPARO EL DVH QUE ME TRAE LA CONSULTA CON EL RECIENTEMENTE GENERADO--------------------------
            //        DVHActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("UsuFam_DVH").ToString;
            //        DVHCorrecto = ObtenerReg.ActualizarDV(StringFinal);
            //        // ----------------------------------------------------------------------------------------------------
            //        if (DVHActual == DVHCorrecto)
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //        else
            //        {
            //            DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //            RegistroAfectadoR(0) = "Usuario_Familia";
            //            RegistroAfectadoR(1) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Usu_Id").ToString;
            //            RegistroAfectadoR(2) = DVHCorrecto;
            //            RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
            //        }
            //    }
            //}
            //else if (tabla == "Usuario_Patente")
            //{
            //    DV ObtenerReg = new DV();
            //    // -----------------------------------------------------------------------------------------------------------------------
            //    // ///Comienzo de Digitoverificacion de REGISTROS para Tabla Bitacora
            //    DataTable ObtenerRegistrosUsuarioDT = new DataTable();
            //    ObtenerRegistrosUsuarioDT = ObtenerReg.Traer_DigitosverificadoresDB("Usuario_Patente").Copy;
            //    ObtenerRegistrosUsuarioDT.Columns.Add("DV_CORRECTO");
            //    for (var r = 0; r <= ObtenerRegistrosUsuarioDT.Rows.Count - 1; r++) // --Ciclo que concatena tupla x tupla para luego obtener el dv de cada tupla
            //    {
            //        // ARMO UNA CADENA POR CADA TUPLA QUE ME SURGE DE LA CONSULTA (SELECT *) REALIZADA
            //        CadenaDVActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Pat_Id").ToString.Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Usu_Id").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("UsuPat_Descripción").ToString().Trim;
            //        string[] CadenaFinal = new string[CadenaDVActual.Count().ToString() + 1];
            //        string valor;
            //        string StringFinal;
            //        StringFinal = null;
            //        for (int i = 0; i <= CadenaDVActual.Count().ToString() - 1; i++) // ciclo que cuenta la cant de caracteres de la CadenadeCaracteres
            //        {
            //            valor = CadenaDVActual[i]; // Separa el valor en particular de un caracter
            //            if (Information.IsNumeric(valor))
            //            {
            //                valor = CadenaDVActual[i]; // Pero pone ese valor numerico en la posición del vector correspondiente
            //                CadenaFinal[i] = valor; // Y por último en la CadenaFinal  
            //            }
            //            else
            //            {
            //                valor = Strings.Asc(valor);
            //                CadenaFinal[i] = valor; // Y lo coloco en la posición del vector que corresponda
            //            }
            //            StringFinal = Strings.Join(CadenaFinal, "");
            //        }
            //        // -----COMPARO EL DVH QUE ME TRAE LA CONSULTA CON EL RECIENTEMENTE GENERADO--------------------------
            //        DVHActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("UsuPat_DVH").ToString;
            //        DVHCorrecto = ObtenerReg.ActualizarDV(StringFinal);
            //        // ----------------------------------------------------------------------------------------------------
            //        if (DVHActual == DVHCorrecto)
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //        else
            //        {
            //            DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //            RegistroAfectadoR(0) = "Usuario_Patente";
            //            RegistroAfectadoR(1) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Pat_Id").ToString;
            //            RegistroAfectadoR(2) = DVHCorrecto;
            //            RegistroAfectadoR(3) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Usu_Id").ToString;
            //            RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
            //        }
            //    }
            //}
            //else if (tabla == "Alumnos")
            //{
            //    // ---------------------Dim ObtenerReg As New DV
            //    // -----------------------------------------------------------------------------------------------------------------------
            //    // ///Comienzo de Digitoverificacion de REGISTROS para Tabla Alumnos
            //    // ---------------------Dim ObtenerRegistrosUsuarioDT As New DataTable
            //    DV ObtenerReg = new DV();
            //    DataTable ObtenerRegistrosUsuarioDT = new DataTable();
            //    ObtenerRegistrosUsuarioDT = ObtenerReg.Traer_DigitosverificadoresDBNeg("Alumnos").Copy;
            //    ObtenerRegistrosUsuarioDT.Columns.Add("DV_CORRECTO");
            //    for (var r = 0; r <= ObtenerRegistrosUsuarioDT.Rows.Count - 1; r++) // --Ciclo que concatena tupla x tupla para luego obtener el dv de cada tupla
            //    {
            //        // ARMO UNA CADENA POR CADA TUPLA QUE ME SURGE DE LA CONSULTA (SELECT *) REALIZADA
            //        CadenaDVActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Alu_Legajo").ToString.Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Alu_Nombre").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Alu_Apellido").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Alu_Dir").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Alu_Tel").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Loc_Id").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Est_Id").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Alu_DNI").ToString().Trim;
            //        string[] CadenaFinal = new string[CadenaDVActual.Count().ToString() + 1];
            //        string valor;
            //        string StringFinal;
            //        StringFinal = null;
            //        for (int i = 0; i <= CadenaDVActual.Count().ToString() - 1; i++) // ciclo que cuenta la cant de caracteres de la CadenadeCaracteres
            //        {
            //            valor = CadenaDVActual[i]; // Separa el valor en particular de un caracter
            //            if (Information.IsNumeric(valor))
            //            {
            //                valor = CadenaDVActual[i]; // Pero pone ese valor numerico en la posición del vector correspondiente
            //                CadenaFinal[i] = valor; // Y por último en la CadenaFinal  
            //            }
            //            else
            //            {
            //                valor = Strings.Asc(valor);
            //                CadenaFinal[i] = valor; // Y lo coloco en la posición del vector que corresponda
            //            }
            //            StringFinal = Strings.Join(CadenaFinal, "");
            //        }
            //        // -----COMPARO EL DVH QUE ME TRAE LA CONSULTA CON EL RECIENTEMENTE GENERADO--------------------------


            //        // aca explota VER
            //        DVHActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Alu_DVH").ToString;
            //        DVHCorrecto = ObtenerReg.ActualizarDV(StringFinal);
            //        // ----------------------------------------------------------------------------------------------------
            //        if (DVHActual == DVHCorrecto)
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //        else
            //        {
            //            DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //            RegistroAfectadoR(0) = "Alumnos";
            //            RegistroAfectadoR(1) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Alu_Legajo").ToString;
            //            RegistroAfectadoR(2) = DVHCorrecto;
            //            RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
            //        }
            //    }
            //}
            //else if (tabla == "Asistencia")
            //{
            //    // ---------------------Dim ObtenerReg As New DV
            //    // -----------------------------------------------------------------------------------------------------------------------
            //    // ///Comienzo de Digitoverificacion de REGISTROS para Tabla Asistencia
            //    // ---------------------Dim ObtenerRegistrosUsuarioDT As New DataTable
            //    DV ObtenerReg = new DV();
            //    DataTable ObtenerRegistrosUsuarioDT = new DataTable();
            //    ObtenerRegistrosUsuarioDT = ObtenerReg.Traer_DigitosverificadoresDBNeg("Asistencia").Copy;
            //    ObtenerRegistrosUsuarioDT.Columns.Add("DV_CORRECTO");
            //    for (var r = 0; r <= ObtenerRegistrosUsuarioDT.Rows.Count - 1; r++) // --Ciclo que concatena tupla x tupla para luego obtener el dv de cada tupla
            //    {
            //        // ARMO UNA CADENA POR CADA TUPLA QUE ME SURGE DE LA CONSULTA (SELECT *) REALIZADA
            //        CadenaDVActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Asis_Fecha") + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Alu_Legajo").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Mat_Id").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Asis_Estado").ToString().Trim;
            //        string[] CadenaFinal = new string[CadenaDVActual.Count().ToString() + 1];
            //        string valor;
            //        string StringFinal;
            //        StringFinal = null;
            //        for (int i = 0; i <= CadenaDVActual.Count().ToString() - 1; i++) // ciclo que cuenta la cant de caracteres de la CadenadeCaracteres
            //        {
            //            valor = CadenaDVActual[i]; // Separa el valor en particular de un caracter
            //            if (Information.IsNumeric(valor))
            //            {
            //                valor = CadenaDVActual[i]; // Pero pone ese valor numerico en la posición del vector correspondiente
            //                CadenaFinal[i] = valor; // Y por último en la CadenaFinal  
            //            }
            //            else
            //            {
            //                valor = Strings.Asc(valor);
            //                CadenaFinal[i] = valor; // Y lo coloco en la posición del vector que corresponda
            //            }
            //            StringFinal = Strings.Join(CadenaFinal, "");
            //        }
            //        // -----COMPARO EL DVH QUE ME TRAE LA CONSULTA CON EL RECIENTEMENTE GENERADO--------------------------
            //        DVHActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Asis_DVH").ToString;
            //        DVHCorrecto = ObtenerReg.ActualizarDV(StringFinal);
            //        // ----------------------------------------------------------------------------------------------------
            //        if (DVHActual == DVHCorrecto)
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //        else
            //        {
            //            DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //            RegistroAfectadoR(0) = "Asistencia";
            //            RegistroAfectadoR(1) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Asis_Id").ToString;
            //            RegistroAfectadoR(2) = DVHCorrecto;
            //            RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
            //        }
            //    }
            //}
            //else if (tabla == "Cajero")
            //{
            //    // ---------------------Dim ObtenerReg As New DV
            //    // -----------------------------------------------------------------------------------------------------------------------
            //    // ///Comienzo de Digitoverificacion de REGISTROS para Tabla Asistencia
            //    // ---------------------Dim ObtenerRegistrosUsuarioDT As New DataTable
            //    DV ObtenerReg = new DV();
            //    DataTable ObtenerRegistrosUsuarioDT = new DataTable();
            //    ObtenerRegistrosUsuarioDT = ObtenerReg.Traer_DigitosverificadoresDBNeg("Cajero").Copy;
            //    ObtenerRegistrosUsuarioDT.Columns.Add("DV_CORRECTO");
            //    for (var r = 0; r <= ObtenerRegistrosUsuarioDT.Rows.Count - 1; r++) // --Ciclo que concatena tupla x tupla para luego obtener el dv de cada tupla
            //    {
            //        // ARMO UNA CADENA POR CADA TUPLA QUE ME SURGE DE LA CONSULTA (SELECT *) REALIZADA
            //        CadenaDVActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Caj_Id").ToString.Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Loc_Id").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Caj_Nombre").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Caj_Apellido").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Caj_Dirección").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Caj_Tel").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Est_Id").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Caj_DNI").ToString().Trim;
            //        string[] CadenaFinal = new string[CadenaDVActual.Count().ToString() + 1];
            //        string valor;
            //        string StringFinal;
            //        StringFinal = null;
            //        for (int i = 0; i <= CadenaDVActual.Count().ToString() - 1; i++) // ciclo que cuenta la cant de caracteres de la CadenadeCaracteres
            //        {
            //            valor = CadenaDVActual[i]; // Separa el valor en particular de un caracter
            //            if (Information.IsNumeric(valor))
            //            {
            //                valor = CadenaDVActual[i]; // Pero pone ese valor numerico en la posición del vector correspondiente
            //                CadenaFinal[i] = valor; // Y por último en la CadenaFinal  
            //            }
            //            else
            //            {
            //                valor = Strings.Asc(valor);
            //                CadenaFinal[i] = valor; // Y lo coloco en la posición del vector que corresponda
            //            }
            //            StringFinal = Strings.Join(CadenaFinal, "");
            //        }
            //        // -----COMPARO EL DVH QUE ME TRAE LA CONSULTA CON EL RECIENTEMENTE GENERADO--------------------------
            //        DVHActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Caj_DVH").ToString;
            //        DVHCorrecto = ObtenerReg.ActualizarDV(StringFinal);
            //        // ----------------------------------------------------------------------------------------------------
            //        if (DVHActual == DVHCorrecto)
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //        else
            //        {
            //            DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //            RegistroAfectadoR(0) = "Cajero";
            //            RegistroAfectadoR(1) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Caj_Id").ToString;
            //            RegistroAfectadoR(2) = DVHCorrecto;
            //            RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
            //        }
            //    }
            //}
            //else if (tabla == "Carrera")
            //{
            //    // ---------------------Dim ObtenerReg As New DV
            //    // -----------------------------------------------------------------------------------------------------------------------
            //    // ///Comienzo de Digitoverificacion de REGISTROS para Tabla Asistencia
            //    // ---------------------Dim ObtenerRegistrosUsuarioDT As New DataTable
            //    DV ObtenerReg = new DV();
            //    DataTable ObtenerRegistrosUsuarioDT = new DataTable();
            //    ObtenerRegistrosUsuarioDT = ObtenerReg.Traer_DigitosverificadoresDBNeg("Carrera").Copy;
            //    ObtenerRegistrosUsuarioDT.Columns.Add("DV_CORRECTO");
            //    for (var r = 0; r <= ObtenerRegistrosUsuarioDT.Rows.Count - 1; r++) // --Ciclo que concatena tupla x tupla para luego obtener el dv de cada tupla
            //    {
            //        // ARMO UNA CADENA POR CADA TUPLA QUE ME SURGE DE LA CONSULTA (SELECT *) REALIZADA
            //        CadenaDVActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Carr_Id").ToString.Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Carr_Nombre").ToString().Trim;
            //        string[] CadenaFinal = new string[CadenaDVActual.Count().ToString() + 1];
            //        string valor;
            //        string StringFinal;
            //        StringFinal = null;
            //        for (int i = 0; i <= CadenaDVActual.Count().ToString() - 1; i++) // ciclo que cuenta la cant de caracteres de la CadenadeCaracteres
            //        {
            //            valor = CadenaDVActual[i]; // Separa el valor en particular de un caracter
            //            if (Information.IsNumeric(valor))
            //            {
            //                valor = CadenaDVActual[i]; // Pero pone ese valor numerico en la posición del vector correspondiente
            //                CadenaFinal[i] = valor; // Y por último en la CadenaFinal  
            //            }
            //            else
            //            {
            //                valor = Strings.Asc(valor);
            //                CadenaFinal[i] = valor; // Y lo coloco en la posición del vector que corresponda
            //            }
            //            StringFinal = Strings.Join(CadenaFinal, "");
            //        }
            //        // -----COMPARO EL DVH QUE ME TRAE LA CONSULTA CON EL RECIENTEMENTE GENERADO--------------------------
            //        DVHActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Carr_DVH").ToString;
            //        DVHCorrecto = ObtenerReg.ActualizarDV(StringFinal);
            //        // ----------------------------------------------------------------------------------------------------
            //        if (DVHActual == DVHCorrecto)
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //        else
            //        {
            //            DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //            RegistroAfectadoR(0) = "Carrera";
            //            RegistroAfectadoR(1) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Carr_Id").ToString;
            //            RegistroAfectadoR(2) = DVHCorrecto;
            //            RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
            //        }
            //    }
            //}
            //else if (tabla == "EstadoNeg")
            //{
            //    // ---------------------Dim ObtenerReg As New DV
            //    // -----------------------------------------------------------------------------------------------------------------------
            //    // ///Comienzo de Digitoverificacion de REGISTROS para Tabla Asistencia
            //    // ---------------------Dim ObtenerRegistrosUsuarioDT As New DataTable
            //    DV ObtenerReg = new DV();
            //    DataTable ObtenerRegistrosUsuarioDT = new DataTable();
            //    ObtenerRegistrosUsuarioDT = ObtenerReg.Traer_DigitosverificadoresDBNeg("Estado").Copy;
            //    ObtenerRegistrosUsuarioDT.Columns.Add("DV_CORRECTO");
            //    for (var r = 0; r <= ObtenerRegistrosUsuarioDT.Rows.Count - 1; r++) // --Ciclo que concatena tupla x tupla para luego obtener el dv de cada tupla
            //    {
            //        // ARMO UNA CADENA POR CADA TUPLA QUE ME SURGE DE LA CONSULTA (SELECT *) REALIZADA
            //        CadenaDVActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Est_Id").ToString.Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Est_Desc").ToString().Trim;
            //        string[] CadenaFinal = new string[CadenaDVActual.Count().ToString() + 1];
            //        string valor;
            //        string StringFinal;
            //        StringFinal = null;
            //        for (int i = 0; i <= CadenaDVActual.Count().ToString() - 1; i++) // ciclo que cuenta la cant de caracteres de la CadenadeCaracteres
            //        {
            //            valor = CadenaDVActual[i]; // Separa el valor en particular de un caracter
            //            if (Information.IsNumeric(valor))
            //            {
            //                valor = CadenaDVActual[i]; // Pero pone ese valor numerico en la posición del vector correspondiente
            //                CadenaFinal[i] = valor; // Y por último en la CadenaFinal  
            //            }
            //            else
            //            {
            //                valor = Strings.Asc(valor);
            //                CadenaFinal[i] = valor; // Y lo coloco en la posición del vector que corresponda
            //            }
            //            StringFinal = Strings.Join(CadenaFinal, "");
            //        }
            //        // -----COMPARO EL DVH QUE ME TRAE LA CONSULTA CON EL RECIENTEMENTE GENERADO--------------------------
            //        DVHActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Est_DVH").ToString;
            //        DVHCorrecto = ObtenerReg.ActualizarDV(StringFinal);
            //        // ----------------------------------------------------------------------------------------------------
            //        if (DVHActual == DVHCorrecto)
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //        else
            //        {
            //            DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //            RegistroAfectadoR(0) = "Estado_Negocio";
            //            RegistroAfectadoR(1) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Est_Id").ToString;
            //            RegistroAfectadoR(2) = DVHCorrecto;
            //            RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
            //        }
            //    }
            //}
            //else if (tabla == "Examen")
            //{
            //    // ---------------------Dim ObtenerReg As New DV
            //    // -----------------------------------------------------------------------------------------------------------------------
            //    // ///Comienzo de Digitoverificacion de REGISTROS para Tabla Asistencia
            //    // ---------------------Dim ObtenerRegistrosUsuarioDT As New DataTable
            //    DV ObtenerReg = new DV();
            //    DataTable ObtenerRegistrosUsuarioDT = new DataTable();
            //    ObtenerRegistrosUsuarioDT = ObtenerReg.Traer_DigitosverificadoresDBNeg("Examen").Copy;
            //    ObtenerRegistrosUsuarioDT.Columns.Add("DV_CORRECTO");
            //    for (var r = 0; r <= ObtenerRegistrosUsuarioDT.Rows.Count - 1; r++) // --Ciclo que concatena tupla x tupla para luego obtener el dv de cada tupla
            //    {
            //        // ARMO UNA CADENA POR CADA TUPLA QUE ME SURGE DE LA CONSULTA (SELECT *) REALIZADA
            //        CadenaDVActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Exa_Fecha") + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Alu_Legajo").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Mat_Id").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Profe_Id").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Exa_Nota").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Exa_Tipo").ToString().Trim;
            //        string[] CadenaFinal = new string[CadenaDVActual.Count().ToString() + 1];
            //        string valor;
            //        string StringFinal;
            //        StringFinal = null;
            //        for (int i = 0; i <= CadenaDVActual.Count().ToString() - 1; i++) // ciclo que cuenta la cant de caracteres de la CadenadeCaracteres
            //        {
            //            valor = CadenaDVActual[i]; // Separa el valor en particular de un caracter
            //            if (Information.IsNumeric(valor))
            //            {
            //                valor = CadenaDVActual[i]; // Pero pone ese valor numerico en la posición del vector correspondiente
            //                CadenaFinal[i] = valor; // Y por último en la CadenaFinal  
            //            }
            //            else
            //            {
            //                valor = Strings.Asc(valor);
            //                CadenaFinal[i] = valor; // Y lo coloco en la posición del vector que corresponda
            //            }
            //            StringFinal = Strings.Join(CadenaFinal, "");
            //        }
            //        // -----COMPARO EL DVH QUE ME TRAE LA CONSULTA CON EL RECIENTEMENTE GENERADO--------------------------
            //        DVHActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Exa_DVH").ToString;
            //        DVHCorrecto = ObtenerReg.ActualizarDV(StringFinal);
            //        // ----------------------------------------------------------------------------------------------------
            //        if (DVHActual == DVHCorrecto)
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //        else
            //        {
            //            DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //            RegistroAfectadoR(0) = "Examen";
            //            RegistroAfectadoR(1) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Exa_Id").ToString;
            //            RegistroAfectadoR(2) = DVHCorrecto;
            //            RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
            //        }
            //    }
            //}
            //else if (tabla == "Factura")
            //{
            //    // ---------------------Dim ObtenerReg As New DV
            //    // -----------------------------------------------------------------------------------------------------------------------
            //    // ///Comienzo de Digitoverificacion de REGISTROS para Tabla Asistencia
            //    // ---------------------Dim ObtenerRegistrosUsuarioDT As New DataTable
            //    DV ObtenerReg = new DV();
            //    DataTable ObtenerRegistrosUsuarioDT = new DataTable();
            //    ObtenerRegistrosUsuarioDT = ObtenerReg.Traer_DigitosverificadoresDBNeg("Factura").Copy;
            //    ObtenerRegistrosUsuarioDT.Columns.Add("DV_CORRECTO");
            //    for (var r = 0; r <= ObtenerRegistrosUsuarioDT.Rows.Count - 1; r++) // --Ciclo que concatena tupla x tupla para luego obtener el dv de cada tupla
            //    {
            //        // ARMO UNA CADENA POR CADA TUPLA QUE ME SURGE DE LA CONSULTA (SELECT *) REALIZADA
            //        CadenaDVActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Fac_NumFac").ToString.Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Fac_Fecha").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Caj_Id").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Alu_Legajo").ToString().Trim;
            //        string[] CadenaFinal = new string[CadenaDVActual.Count().ToString() + 1];
            //        string valor;
            //        string StringFinal;
            //        StringFinal = null;
            //        for (int i = 0; i <= CadenaDVActual.Count().ToString() - 1; i++) // ciclo que cuenta la cant de caracteres de la CadenadeCaracteres
            //        {
            //            valor = CadenaDVActual[i]; // Separa el valor en particular de un caracter
            //            if (Information.IsNumeric(valor))
            //            {
            //                valor = CadenaDVActual[i]; // Pero pone ese valor numerico en la posición del vector correspondiente
            //                CadenaFinal[i] = valor; // Y por último en la CadenaFinal  
            //            }
            //            else
            //            {
            //                valor = Strings.Asc(valor);
            //                CadenaFinal[i] = valor; // Y lo coloco en la posición del vector que corresponda
            //            }
            //            StringFinal = Strings.Join(CadenaFinal, "");
            //        }
            //        // -----COMPARO EL DVH QUE ME TRAE LA CONSULTA CON EL RECIENTEMENTE GENERADO--------------------------
            //        DVHActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Fac_DVH").ToString;
            //        DVHCorrecto = ObtenerReg.ActualizarDV(StringFinal);
            //        // ----------------------------------------------------------------------------------------------------
            //        if (DVHActual == DVHCorrecto)
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //        else
            //        {
            //            DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //            RegistroAfectadoR(0) = "Factura";
            //            RegistroAfectadoR(1) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Fac_NumFac").ToString;
            //            RegistroAfectadoR(2) = DVHCorrecto;
            //            RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
            //        }
            //    }
            //}
            //else if (tabla == "Localidad")
            //{
            //    // ---------------------Dim ObtenerReg As New DV
            //    // -----------------------------------------------------------------------------------------------------------------------
            //    // ///Comienzo de Digitoverificacion de REGISTROS para Tabla Asistencia
            //    // ---------------------Dim ObtenerRegistrosUsuarioDT As New DataTable
            //    DV ObtenerReg = new DV();
            //    DataTable ObtenerRegistrosUsuarioDT = new DataTable();
            //    ObtenerRegistrosUsuarioDT = ObtenerReg.Traer_DigitosverificadoresDBNeg("Localidad").Copy;
            //    ObtenerRegistrosUsuarioDT.Columns.Add("DV_CORRECTO");
            //    for (var r = 0; r <= ObtenerRegistrosUsuarioDT.Rows.Count - 1; r++) // --Ciclo que concatena tupla x tupla para luego obtener el dv de cada tupla
            //    {
            //        // ARMO UNA CADENA POR CADA TUPLA QUE ME SURGE DE LA CONSULTA (SELECT *) REALIZADA
            //        CadenaDVActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Loc_Id").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Loc_Nombre").ToString().Trim;
            //        string[] CadenaFinal = new string[CadenaDVActual.Count().ToString() + 1];
            //        string valor;
            //        string StringFinal;
            //        StringFinal = null;
            //        for (int i = 0; i <= CadenaDVActual.Count().ToString() - 1; i++) // ciclo que cuenta la cant de caracteres de la CadenadeCaracteres
            //        {
            //            valor = CadenaDVActual[i]; // Separa el valor en particular de un caracter
            //            if (Information.IsNumeric(valor))
            //            {
            //                valor = CadenaDVActual[i]; // Pero pone ese valor numerico en la posición del vector correspondiente
            //                CadenaFinal[i] = valor; // Y por último en la CadenaFinal  
            //            }
            //            else
            //            {
            //                valor = Strings.Asc(valor);
            //                CadenaFinal[i] = valor; // Y lo coloco en la posición del vector que corresponda
            //            }
            //            StringFinal = Strings.Join(CadenaFinal, "");
            //        }
            //        // -----COMPARO EL DVH QUE ME TRAE LA CONSULTA CON EL RECIENTEMENTE GENERADO--------------------------
            //        DVHActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Loc_DVH").ToString;
            //        DVHCorrecto = ObtenerReg.ActualizarDV(StringFinal);
            //        // ----------------------------------------------------------------------------------------------------
            //        if (DVHActual == DVHCorrecto)
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //        else
            //        {
            //            DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //            RegistroAfectadoR(0) = "Localidad";
            //            RegistroAfectadoR(1) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Loc_Id").ToString;
            //            RegistroAfectadoR(2) = DVHCorrecto;
            //            RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
            //        }
            //    }
            //}
            //else if (tabla == "Materia")
            //{
            //    // ---------------------Dim ObtenerReg As New DV
            //    // -----------------------------------------------------------------------------------------------------------------------
            //    // ///Comienzo de Digitoverificacion de REGISTROS para Tabla Asistencia
            //    // ---------------------Dim ObtenerRegistrosUsuarioDT As New DataTable
            //    DV ObtenerReg = new DV();
            //    DataTable ObtenerRegistrosUsuarioDT = new DataTable();
            //    ObtenerRegistrosUsuarioDT = ObtenerReg.Traer_DigitosverificadoresDBNeg("Materia").Copy;
            //    ObtenerRegistrosUsuarioDT.Columns.Add("DV_CORRECTO");
            //    for (var r = 0; r <= ObtenerRegistrosUsuarioDT.Rows.Count - 1; r++) // --Ciclo que concatena tupla x tupla para luego obtener el dv de cada tupla
            //    {
            //        // ARMO UNA CADENA POR CADA TUPLA QUE ME SURGE DE LA CONSULTA (SELECT *) REALIZADA
            //        CadenaDVActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Mat_Id").ToString.Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Mat_Nombre").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Mat_CargaHoraria").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Est_Id").ToString().Trim;
            //        string[] CadenaFinal = new string[CadenaDVActual.Count().ToString() + 1];
            //        string valor;
            //        string StringFinal;
            //        StringFinal = null;
            //        for (int i = 0; i <= CadenaDVActual.Count().ToString() - 1; i++) // ciclo que cuenta la cant de caracteres de la CadenadeCaracteres
            //        {
            //            valor = CadenaDVActual[i]; // Separa el valor en particular de un caracter
            //            if (Information.IsNumeric(valor))
            //            {
            //                valor = CadenaDVActual[i]; // Pero pone ese valor numerico en la posición del vector correspondiente
            //                CadenaFinal[i] = valor; // Y por último en la CadenaFinal  
            //            }
            //            else
            //            {
            //                valor = Strings.Asc(valor);
            //                CadenaFinal[i] = valor; // Y lo coloco en la posición del vector que corresponda
            //            }
            //            StringFinal = Strings.Join(CadenaFinal, "");
            //        }
            //        // -----COMPARO EL DVH QUE ME TRAE LA CONSULTA CON EL RECIENTEMENTE GENERADO--------------------------
            //        DVHActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Mat_DVH").ToString;
            //        DVHCorrecto = ObtenerReg.ActualizarDV(StringFinal);
            //        // ----------------------------------------------------------------------------------------------------
            //        if (DVHActual == DVHCorrecto)
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //        else
            //        {
            //            DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //            RegistroAfectadoR(0) = "Materia";
            //            RegistroAfectadoR(1) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Mat_Id").ToString;
            //            RegistroAfectadoR(2) = DVHCorrecto;
            //            RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
            //        }
            //    }
            //}
            //else if (tabla == "Planes")
            //{
            //    // ---------------------Dim ObtenerReg As New DV
            //    // -----------------------------------------------------------------------------------------------------------------------
            //    // ///Comienzo de Digitoverificacion de REGISTROS para Tabla Asistencia
            //    // ---------------------Dim ObtenerRegistrosUsuarioDT As New DataTable
            //    DV ObtenerReg = new DV();
            //    DataTable ObtenerRegistrosUsuarioDT = new DataTable();
            //    ObtenerRegistrosUsuarioDT = ObtenerReg.Traer_DigitosverificadoresDBNeg("Planes").Copy;
            //    ObtenerRegistrosUsuarioDT.Columns.Add("DV_CORRECTO");
            //    for (var r = 0; r <= ObtenerRegistrosUsuarioDT.Rows.Count - 1; r++) // --Ciclo que concatena tupla x tupla para luego obtener el dv de cada tupla
            //    {
            //        // ARMO UNA CADENA POR CADA TUPLA QUE ME SURGE DE LA CONSULTA (SELECT *) REALIZADA
            //        CadenaDVActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("ID_Plan").ToString.Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Carr_Id").ToString().Trim;
            //        string[] CadenaFinal = new string[CadenaDVActual.Count().ToString() + 1];
            //        string valor;
            //        string StringFinal;
            //        StringFinal = null;
            //        for (int i = 0; i <= CadenaDVActual.Count().ToString() - 1; i++) // ciclo que cuenta la cant de caracteres de la CadenadeCaracteres
            //        {
            //            valor = CadenaDVActual[i]; // Separa el valor en particular de un caracter
            //            if (Information.IsNumeric(valor))
            //            {
            //                valor = CadenaDVActual[i]; // Pero pone ese valor numerico en la posición del vector correspondiente
            //                CadenaFinal[i] = valor; // Y por último en la CadenaFinal  
            //            }
            //            else
            //            {
            //                valor = Strings.Asc(valor);
            //                CadenaFinal[i] = valor; // Y lo coloco en la posición del vector que corresponda
            //            }
            //            StringFinal = Strings.Join(CadenaFinal, "");
            //        }
            //        // -----COMPARO EL DVH QUE ME TRAE LA CONSULTA CON EL RECIENTEMENTE GENERADO--------------------------
            //        DVHActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Plan_DVH").ToString;
            //        DVHCorrecto = ObtenerReg.ActualizarDV(StringFinal);
            //        // ----------------------------------------------------------------------------------------------------
            //        if (DVHActual == DVHCorrecto)
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //        else
            //        {
            //            DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //            RegistroAfectadoR(0) = "Plan";
            //            RegistroAfectadoR(1) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("ID_Plan").ToString;
            //            RegistroAfectadoR(2) = DVHCorrecto;
            //            RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
            //        }
            //    }
            //}
            //else if (tabla == "Profesor")
            //{
            //    // ---------------------Dim ObtenerReg As New DV
            //    // -----------------------------------------------------------------------------------------------------------------------
            //    // ///Comienzo de Digitoverificacion de REGISTROS para Tabla Asistencia
            //    // ---------------------Dim ObtenerRegistrosUsuarioDT As New DataTable
            //    DV ObtenerReg = new DV();
            //    DataTable ObtenerRegistrosUsuarioDT = new DataTable();
            //    ObtenerRegistrosUsuarioDT = ObtenerReg.Traer_DigitosverificadoresDBNeg("Profesor").Copy;
            //    ObtenerRegistrosUsuarioDT.Columns.Add("DV_CORRECTO");
            //    for (var r = 0; r <= ObtenerRegistrosUsuarioDT.Rows.Count - 1; r++) // --Ciclo que concatena tupla x tupla para luego obtener el dv de cada tupla
            //    {
            //        // ARMO UNA CADENA POR CADA TUPLA QUE ME SURGE DE LA CONSULTA (SELECT *) REALIZADA
            //        CadenaDVActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Profe_Id").ToString.Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Profe_Nombre_y_Apellido").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Profe_Tel").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Loc_Id").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Est_Id").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Profe_DNI").ToString().Trim;
            //        string[] CadenaFinal = new string[CadenaDVActual.Count().ToString() + 1];
            //        string valor;
            //        string StringFinal;
            //        StringFinal = null;
            //        for (int i = 0; i <= CadenaDVActual.Count().ToString() - 1; i++) // ciclo que cuenta la cant de caracteres de la CadenadeCaracteres
            //        {
            //            valor = CadenaDVActual[i]; // Separa el valor en particular de un caracter
            //            if (Information.IsNumeric(valor))
            //            {
            //                valor = CadenaDVActual[i]; // Pero pone ese valor numerico en la posición del vector correspondiente
            //                CadenaFinal[i] = valor; // Y por último en la CadenaFinal  
            //            }
            //            else
            //            {
            //                valor = Strings.Asc(valor);
            //                CadenaFinal[i] = valor; // Y lo coloco en la posición del vector que corresponda
            //            }
            //            StringFinal = Strings.Join(CadenaFinal, "");
            //        }
            //        // -----COMPARO EL DVH QUE ME TRAE LA CONSULTA CON EL RECIENTEMENTE GENERADO--------------------------
            //        DVHActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Profe_DVH").ToString;
            //        DVHCorrecto = ObtenerReg.ActualizarDV(StringFinal);
            //        // ----------------------------------------------------------------------------------------------------
            //        if (DVHActual == DVHCorrecto)
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //        else
            //        {
            //            DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //            RegistroAfectadoR(0) = "Profesor";
            //            RegistroAfectadoR(1) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Profe_Id").ToString;
            //            RegistroAfectadoR(2) = DVHCorrecto;
            //            RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
            //        }
            //    }
            //}
            return RegistrosAfectadosDT;                
        }
    }
}


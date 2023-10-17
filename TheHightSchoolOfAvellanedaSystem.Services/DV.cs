using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace TheHightSchoolOfAvellanedaSystem.Services
{
    
    public class DV
    {
        public string ActualizarDV(string resultado)
        {
            return calcular(resultado, 10);
        }
        public string calcular(string numero, int basemax)
        {
            long código;
            string numero_al;
            numero_al = "";
            int i;
            for (i = 1; i <= Strings.Len(numero); i++)
            {
                string c; // Integer
                c = Strings.Mid(numero, i, 1);
                código = Strings.Asc(Strings.UCase(c));
                if (!(código >= 48 & código <= 57))
                    numero_al = numero_al + código;
                else
                    numero_al = numero_al + c;
            }
            int k, total;
            k = 2;
            total = 0;
            for (i = Strings.Len(numero_al); i >= 1; i += -1)
            {
                if ((k > basemax))
                    k = 2;
                int nuemro_aux;
                nuemro_aux = (int)Conversion.Val(Strings.Mid(numero_al, i, 1));
                total = total + (nuemro_aux * k);
                k = k + 1;
            }
            int resto, digito;
            resto = total % 10;
            if ((resto > 1))
                digito = 10 - resto;
            else
                digito = 0;
            //return calcular = digito;
            return digito.ToString();
        }

        //// FRAGMENTO DE CODIGO DE PRUEBA PARA REALIZAR LA COMPROBACIÓN DEL TOTAL DE LOS DIGITOVERIFICADORES
        //public DataTable VerificarIntegridadenBD(string tabla)
        //{
        //    // DECLARO LAS VARIABLES COMUNES PARA TODAS LAS TABLAS A VERIFICAR
        //    string CadenaDVActual;          // Declaro la cadena en la que voy a colocar todos los registros concatenados
        //    int DVHActual;              // Declaro una variable para cargar el DVH que me traere en una consulta 
        //    int DVHCorrecto;            // Declaro una variable para calcular el DVH y controlarlo con el traido de la consulta
        //    DataTable RegistrosAfectadosDT = new DataTable(); // Declaro un datatable para guardar los registros afectados en caso de 
        //    RegistrosAfectadosDT.Columns.Add("TABLA"); // que surjan errores en los DV
        //    RegistrosAfectadosDT.Columns.Add("ID_de_REGISTRO");
        //    RegistrosAfectadosDT.Columns.Add("DV_CORRECTO");
        //    // linea generada para comparar los DV generados y los existemtes en la BD 
        //    RegistrosAfectadosDT.Columns.Add("DV_DELABD");
        //    // ------------------------------------------------------------------------
        //    // AHORA HAGO LAS CONSULTAS CORRESPONDIENTES POR CADA UNA DE LAS TABLAS CON DV
        //    // -------------------------------------------------------------------------------------------------------------------
        //    // ---------------------------------------- COMIENZO POR LA DE USUARIOS ----------------------------------------------
        //    if (tabla == "Usuario")
        //    {
        //        // ---------------------Dim ObtenerReg As New DV
        //        // -----------------------------------------------------------------------------------------------------------------------
        //        // ///Comienzo de Digitoverificacion de REGISTROS para Tabla Usuario
        //        // ---------------------Dim ObtenerRegistrosUsuarioDT As New DataTable
        //        DV ObtenerReg = new DV();
        //        DataTable ObtenerRegistrosUsuarioDT = new DataTable();
        //    //    ObtenerRegistrosUsuarioDT = ObtenerReg.Traer_DigitosverificadoresDB("Usuario").Copy;
            //    ObtenerRegistrosUsuarioDT.Columns.Add("DV_CORRECTO");
            //    for (var r = 0; r <= ObtenerRegistrosUsuarioDT.Rows.Count - 1; r++) // --Ciclo que concatena tupla x tupla para luego obtener el dv de cada tupla
            //    {
            //        // ARMO UNA CADENA POR CADA TUPLA QUE ME SURGE DE LA CONSULTA (SELECT *) REALIZADA
            //        CadenaDVActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Usu_Id").ToString.Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Usu_NombreUsu").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Usu_Contraseña").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Usu_Nombre_y_Apellido").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Usu_Cont_Incorrectos").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Est_Id").ToString().Trim;
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
            //        DVHActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Usu_DVH").ToString;
            //        DVHCorrecto = ObtenerReg.ActualizarDV(StringFinal);
            //        // ----------------------------------------------------------------------------------------------------
            //        if (DVHActual == DVHCorrecto)
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //        else
            //        {
            //            DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //            RegistroAfectadoR(0) = "Usuario";
            //            RegistroAfectadoR(1) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Usu_Id").ToString;
            //            RegistroAfectadoR(2) = DVHCorrecto;
            //            RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
            //        }
            //    }
            //}
            //else if (tabla == "Bitacora")
            //{
            //    DV ObtenerReg = new DV();
            //    // -----------------------------------------------------------------------------------------------------------------------
            //    // ///Comienzo de Digitoverificacion de REGISTROS para Tabla Bitacora
            //    DataTable ObtenerRegistrosUsuarioDT = new DataTable();
            //    ObtenerRegistrosUsuarioDT = ObtenerReg.Traer_DigitosverificadoresDB("Bitacora").Copy;
            //    ObtenerRegistrosUsuarioDT.Columns.Add("DV_CORRECTO");
            //    for (var r = 0; r <= ObtenerRegistrosUsuarioDT.Rows.Count - 1; r++) // --Ciclo que concatena tupla x tupla para luego obtener el dv de cada tupla
            //    {
            //        // ARMO UNA CADENA POR CADA TUPLA QUE ME SURGE DE LA CONSULTA (SELECT *) REALIZADA
            //        CadenaDVActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Bit_Id").ToString.Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Usu_Id").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Bit_Fecha") + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Bit_Hora").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Bit_Criticidad").ToString().Trim + ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Est_Id").ToString().Trim;
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
            //        DVHActual = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Bit_DVH").ToString;
            //        DVHCorrecto = ObtenerReg.ActualizarDV(StringFinal);
            //        // ----------------------------------------------------------------------------------------------------
            //        if (DVHActual == DVHCorrecto)
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //        else
            //        {
            //            DataRow RegistroAfectadoR = RegistrosAfectadosDT.NewRow();
            //            ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("DV_CORRECTO") = DVHCorrecto;
            //            RegistroAfectadoR(0) = "Bitacora";
            //            RegistroAfectadoR(1) = ObtenerRegistrosUsuarioDT.Rows.Item(r).Item("Bit_Id").ToString;
            //            RegistroAfectadoR(2) = DVHCorrecto;
            //            RegistrosAfectadosDT.Rows.Add(RegistroAfectadoR);
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
        //    return RegistrosAfectadosDT;
        //}
        // 'CONSULTA QUE ME TRAE A LOS REGISTROS DE CADA TABLA DE LA BASE DE DATOS DEL NEGOCIO TOTALMENTE PARTAMETRIZADA 
        //public DataTable Traer_DigitosverificadoresDB(string tabla)
        //{
        //    string consulta = "";
        //    consulta = "Select * From " + tabla;
        //    Base_de_Datos oDatos = new Base_de_Datos();
        //    var ds = new DataTable();
        //    ds = oDatos.EjecutarConsultaSeg(consulta).Tables(0);
        //    return ds;
        //}
        //// 'CONSULTA QUE ME TRAE A LOS REGISTROS DE CADA TABLA DE LA BASE DE DATOS DE SEGURIDAD TOTALMENTE PARTAMETRIZADA
        //public DataTable Traer_DigitosverificadoresDBNeg(string tabla)
        //{
        //    string consulta = "";
        //    consulta = "Select * From " + tabla;
        //    Base_de_Datos oDatos = new Base_de_Datos();
        //    var ds = new DataTable();
        //    ds = oDatos.EjecutarConsultaNeg(consulta).Tables(0);
        //    return ds;
        //}
        //// 'CONSULTA QUE MODIFICA LOS DV DE CUALQUIER TABLA DE LA BASE SEGURIDAD, PARAMETRIZADA
        //public void ModificarDV(string tabla, string parametro, int dv, string parametro2, int id)
        //{
        //    string consulta = "";
        //    consulta = "Update " + tabla + " Set " + parametro + " = " + dv + " where " + parametro2 + " = " + id;
        //    Base_de_Datos oDatos = new Base_de_Datos();
        //    oDatos.EjecutarConsultaSeg(consulta);
        //}
        //// 'CONSULTA DE TABLAS COMPUESTAS, PARAMETRIZADA
        //public void ModificarDVTablaCompuesta(string tabla, string parametro, int dv, string parametro2, int id, string parametro3, int id2)
        //{
        //    string consulta = "";
        //    consulta = "Update " + tabla + " Set " + parametro + " = " + dv + " where " + parametro2 + " = " + id + " and " + parametro3 + " = " + id2;
        //    Base_de_Datos oDatos = new Base_de_Datos();
        //    oDatos.EjecutarConsultaSeg(consulta);
        //}
        //// 'CONSULTA QUE MODIFICA LOS DV DE CUALQUIER TABLA DE NEGOCIO, PARAMETRIZADA
        //public void ModificarDVNeg(string tabla, string parametro, int dv, string parametro2, int id)
        //{
        //    string consulta = "";
        //    consulta = "Update " + tabla + " Set " + parametro + " = " + dv + " where " + parametro2 + " = " + id;
        //    Base_de_Datos oDatos = new Base_de_Datos();
        //    oDatos.EjecutarConsultaNeg(consulta);
        //}
    }

}

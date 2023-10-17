using System;
using System.Collections.Generic;
using TheHightSchoolOfAvellanedaSystem.Domain;
using TheHightSchoolOfAvellanedaSystem.Repository;
using TheHightSchoolOfAvellanedaSystem.Services;

namespace TheHightSchoolOfAvellanedaSystem.AplicationService
{
    public class UsuarioAppService
    {
        private IUsuarioRepository _repo;
        private IBitacoraRepository _bitaRepo;
        private IDVRepository _dvRepo;
        private IMovimientosReposotory _movRepo;
        private IUsuarioFamiliaRepository _usufamRepo;

        public UsuarioAppService()
        {
            _repo = new UsuarioRepository();
            _bitaRepo = new BitacoraRepository();
            _dvRepo = new DVRepository();
            _movRepo = new MovimientosRepository();
            _usufamRepo = new UsuarioFamiliaRepository();
        }

       

        public Domain.Usuario ObtenerUsuarioPorId(int id)
        {
            return _repo.ObtenerUsuarioPorId(id);
        }
        public List<Domain.Usuario> GetAll()
        {
            return (List<Domain.Usuario>)_repo.GetAll();
        }
        public List<Domain.Usuario> GetAllUsuarios()
        {
            var listaUsiuarios = (List<Domain.Usuario>)_repo.GetAll();
            Encriptación usuarioDesencriptado = new Encriptación();
            foreach (var item in listaUsiuarios)
            {
               item.username = usuarioDesencriptado.Desencriptar(item.username, "Michael"); 
            }
            return listaUsiuarios;
        }

        public int UpdateDVH(int nuevoDVH, int Id)
        {
            return _repo.UpdateDVH(nuevoDVH, Id);
        }

        public List<Domain.Usuario> FindById(string filter)
        {
            return GetAllUsuarios().FindAll(u=> Convert.ToString(u.Id).Contains(filter) || u.nombre.Contains(filter) || u.apellido.Contains(filter) 
                                             || Convert.ToString(u.dni).Contains(filter) || u.username.Contains(filter));
        }

        public void updateUsuario(Domain.Usuario usuario, Domain.Usuario usuarioAnterior, int usuarioEnSesion, long dniusuarioEnSesion)
        {
            if (String.IsNullOrEmpty(Convert.ToString(usuario.dni)) || String.IsNullOrEmpty(usuario.nombre) || String.IsNullOrEmpty(usuario.apellido) ||
                //String.IsNullOrEmpty(usuario.calle) || String.IsNullOrEmpty(Convert.ToString(numero)) || String.IsNullOrEmpty(Convert.ToString(codigoPostal)) ||
                //String.IsNullOrEmpty(Convert.ToString(localidad)) || 
                //String.IsNullOrEmpty(Convert.ToString(email)) || String.IsNullOrEmpty(Convert.ToString(telefono)) ||
                String.IsNullOrEmpty(usuario.username) || String.IsNullOrEmpty(Convert.ToString(usuario.idIdioma)))
                throw new Exception("Por favor, llene todas las casillas de texto para hacer la operación.");
            if (usuario.estado == 3) { throw new Exception("No se puede modificar o anular a un usuario en estado de baja."); }
            else
            {
                Domain.Email usuarioEmail = new Domain.Email();
                //Solo para sacar el error luego poner el mail del Textbox (txtmail)
                usuarioEmail.email = "nanono.99@gmail.com";
                
                Domain.Usuario usuarioParaComprar = new Domain.Usuario(usuarioEmail);
                Encriptación usernameEncriptado = new Encriptación();
                string usuarioEncriptado = usernameEncriptado.Encriptar(usuario.username, "Michael");
                usuario.username = usuarioEncriptado;
                Services.Usuario.SetDVH(usuario);
                _repo.Update(usuario);
                ////Inserto las bitacoras y movimientos
                Domain.Bitacora bitacora = new Domain.Bitacora();
                bitacora.idUsuario = usuarioEnSesion;
                bitacora.dni = dniusuarioEnSesion;
                bitacora.idMovimiento = (int)Enum_Movimientos.Modificacion;
                bitacora.descripcion = Enum_Movimientos.Modificacion.ToString() + " usuario " + usuario.Id + ", nombre: " + usuario.nombre + " " + usuario.apellido + ", dni: " + usuario.dni;
                //bitacora.Bit_Criticidad = "Leve";
                string tabla = "Bitacora";
                Services.Bitacora.SetDVH(bitacora);
                _bitaRepo.Add(bitacora);
                int DVV = _dvRepo.ObtenerSumDVH("dvh", tabla);
                Digitoverificador dv = new Digitoverificador();
                dv.dvv = DVV;
                dv.tabla = tabla;
                _dvRepo.Update(dv);
                //actualizo los dvv usuarios
                string tablaUsers = "Usuario";
                int DVVUsers = _dvRepo.ObtenerSumDVH("dvh", tablaUsers);
                dv.dvv = DVVUsers;
                dv.tabla = tablaUsers;
                _dvRepo.Update(dv);
                //Cargo el movimiento en los controles de cambios
                ControlDeCambiosAppService control = new ControlDeCambiosAppService();
                control.UsuarioControlDeCambiosAdd(usuario, usuarioAnterior, usuarioEnSesion, dniusuarioEnSesion);
            }
        }

        public void updateUsuarioRevertido(Domain.Usuario usuario, int usuarioEnSesion, long DNIusuarioEnSesion, Domain.Usuario usuarioAnterior)
        {
            //if (String.IsNullOrEmpty(usuario.Username) || String.IsNullOrEmpty(usuario.Nombre_y_Apellido) || String.IsNullOrEmpty(usuario.Email) || String.IsNullOrEmpty(idioma)) throw new Exception("Por favor, llene todas las casillas de texto para hacer la operación.");
            //if (usuario.Estado)
            {
                Domain.Email usuarioEmail = new Domain.Email();
                //Solo para sacar el error luego poner el mail del Textbox (txtmail)
                usuarioEmail.email = "nanono.99@gmail.com";

                Domain.Usuario usuarioParaComprar = new Domain.Usuario(usuarioEmail);
                Encriptación usernameEncriptado = new Encriptación();
                string usuarioEncriptado = usernameEncriptado.Encriptar(usuario.username, "Michael");
                //usuarioParaComprar = _repo.ObtenerUsuarioPorUsuario(usuarioEncriptado);
                //if (usuarioParaComprar.Username != null) { throw new Exception("Imposible usar el nombre de usuario ingresado. Por favor, ingrese uno distinto."); }
                usuario.username = usuarioEncriptado;
                //if (usuario.State == EntityState.Deleted) { usuario.Estado = false; }
                Services.Usuario.SetDVH(usuario);
                _repo.Update(usuario);
                //int idIdioma = 0;
                //if (idioma == "Español") { idIdioma = 1; }
                //else { idIdioma = 2; }
                //_repo.updateUserLanguage(usuario.Id, idIdioma, idioma);
                //Inserto las bitacoras y movimientos
                Domain.Bitacora bitacora = new Domain.Bitacora();
                //bitacora.Id = _bitaRepo.GetLasBitacora() + 1;
                bitacora.idUsuario = usuarioEnSesion;
                bitacora.dni = DNIusuarioEnSesion;
                bitacora.idMovimiento = (int)Enum_Movimientos.Modificacion;
                bitacora.descripcion = Enum_Movimientos.Modificacion.ToString() + " usuario " + usuario.Id + ", dni: " + usuario.dni;
                //bitacora.Bit_Criticidad = "Critica";
                string tabla = "Bitacora";
                Services.Bitacora.SetDVH(bitacora);
                _bitaRepo.Add(bitacora);
                int DVV = _dvRepo.ObtenerSumDVH("dvh", tabla);
                Digitoverificador dv = new Digitoverificador();
                dv.dvv = DVV;
                dv.tabla = tabla;
                _dvRepo.Update(dv);
                //Domain.Movimientos movimiento = new Domain.Movimientos();
                //movimiento.Bit_Id_Mov = bitacora.Id;
                //movimiento.Usu_Id = bitacora.Usu_Id;
                //Encriptación movimientoEncriptado = new Encriptación();
                //if (usuario.State == EntityState.Deleted) { movimiento.Movimiento = movimientoEncriptado.Encriptar("Anulo usuario " + usuario.Id, "Tyson"); }
                //movimiento.Movimiento = movimientoEncriptado.Encriptar("Update usuario " + usuario.Id, "Tyson");
                //Services.Movimientos.SetDVH(movimiento);
                //_movRepo.Add(movimiento);
                //string tablaMov = "Movimientos";
                //int DVVMovimientos = _dvRepo.ObtenerSumDVH("Mov_DVH", tablaMov);
                //dv.Valor = DVVMovimientos;
                //dv.Tabla = tablaMov;
                //_dvRepo.Update(dv);
                //actualizo los dvv usuarios
                string tablaUsers = "Usuario";
                int DVVUsers = _dvRepo.ObtenerSumDVH("dvh", tablaUsers);
                dv.dvv = DVVUsers;
                dv.tabla = tablaUsers;
                _dvRepo.Update(dv);
                //Cargo el movimiento en los controles de cambios
                ControlDeCambiosAppService control = new ControlDeCambiosAppService();
                control.UsuarioControlDeCambiosAdd(usuario, usuarioAnterior, usuarioEnSesion, DNIusuarioEnSesion);
            }
            //else { throw new Exception("No se puede modificar o anular a un usuario en estado de baja."); }

        }

        public void usuarioInsert(string dni, string nombrePersona, string apellidoPersona, string calle, string numero, string codigoPostal, string localidad, 
                                  string email, string telefono, string username, string idioma, string familia, int usuarioEnSesion, long usuarioEnSesionDNI)
        {
            if (String.IsNullOrEmpty(Convert.ToString(dni)) || String.IsNullOrEmpty(nombrePersona) || String.IsNullOrEmpty(apellidoPersona) || 
                String.IsNullOrEmpty(calle) || String.IsNullOrEmpty(Convert.ToString(numero)) || String.IsNullOrEmpty(Convert.ToString(codigoPostal)) ||
                String.IsNullOrEmpty(Convert.ToString(localidad)) || String.IsNullOrEmpty(Convert.ToString(email)) || String.IsNullOrEmpty(Convert.ToString(telefono)) ||
                String.IsNullOrEmpty(username) || String.IsNullOrEmpty(Convert.ToString(idioma)) || String.IsNullOrEmpty(Convert.ToString(familia)))
                throw new Exception("Por favor, llene todas las casillas de texto para hacer la operación.");
            Domain.Email usuarioEmail = new Domain.Email();
            usuarioEmail.email = email;
            usuarioEmail.dni = Convert.ToInt64(dni);
            Domain.Usuario usuario = new Domain.Usuario(usuarioEmail);
            Encriptación usernameEncriptado = new Encriptación();
            string usuarioEncriptado = usernameEncriptado.Encriptar(username, "Michael");  
            usuario = _repo.ObtenerUsuarioPorUsuario(usuarioEncriptado);
            if (usuario.username != null) { throw new Exception("Imposible usar el nombre de usuario ingresado. Por favor, ingrese uno distinto."); }
            usuario.dni = Convert.ToInt64(dni);
            usuario.nombre = nombrePersona;
            usuario.apellido = apellidoPersona;
            usuario.username = usuarioEncriptado;
            string passPura = Services.Usuario.setPass();
            usuario.password = passPura;
            usuario.idIdioma = Convert.ToInt32(idioma);
            usuario.estado = (int)EntityState.Creado;
            //////////////////////////////////////
            Localidad loc = new Localidad();
            loc.Id = Convert.ToInt32(localidad);
            usuario.agregarDomicilio(calle, Convert.ToInt32(numero), Convert.ToInt32(codigoPostal), loc, Convert.ToInt32(dni), 1);
            //////////////////////////////////////
            usuario.email = email;
            usuario.calle = calle;
            usuario.numero = Convert.ToInt32(numero);
            usuario.codigoPostal = Convert.ToInt32(codigoPostal);
            usuario.localidad = Convert.ToInt32(localidad);
            Services.Usuario.setParameters(usuario);
            _repo.Add(usuario);
            Domain.Usuario userCreado = new Domain.Usuario(usuarioEmail);
            userCreado = _repo.ObtenerUsuarioPorUsuario(usuarioEncriptado);
            int idUserCreado = userCreado.Id;
            usuario.Id = idUserCreado;
            //Ahora debería insertar el USUARIO/FAMILIA
            UsuarioFamilia usuariofamilia = new UsuarioFamilia();
            usuariofamilia.idUsuario = usuario.Id;
            usuariofamilia.dniUsuario = usuario.dni;
            usuariofamilia.idFamilia = Convert.ToInt32(familia);
            _usufamRepo.Add(usuariofamilia);
            ////Inserto las bitacoras y movimientos
            Domain.Bitacora bitacora = new Domain.Bitacora();
            bitacora.idUsuario = usuarioEnSesion;
            bitacora.dni = usuarioEnSesionDNI;
            bitacora.idMovimiento = (int)Enum_Movimientos.Alta;
            bitacora.descripcion = Enum_Movimientos.Alta.ToString() + " usuario " + idUserCreado + ", nombre: " + nombrePersona + " " + apellidoPersona + ", dni: " + dni;
            //bitacora.Bit_Criticidad = "Leve";
            string tabla = "Bitacora";
            Services.Bitacora.SetDVH(bitacora);
            _bitaRepo.Add(bitacora);
            int DVV = _dvRepo.ObtenerSumDVH("dvh", tabla);
            Digitoverificador dv = new Digitoverificador();
            dv.dvv = DVV;
            dv.tabla = tabla;
            _dvRepo.Update(dv);
            //Domain.Movimientos movimiento = new Domain.Movimientos();
            //movimiento.Bit_Id_Mov = bitacora.Id;
            //movimiento.Usu_Id = bitacora.Usu_Id;
            //Encriptación movimientoEncriptado = new Encriptación();
            //movimiento.Movimiento = movimientoEncriptado.Encriptar("Alta usuario " + usuario.Id, "Tyson");
            //Services.Movimientos.SetDVH(movimiento);
            //_movRepo.Add(movimiento);
            //string tablaMov = "Movimientos";
            //int DVVMovimientos = _dvRepo.ObtenerSumDVH("Mov_DVH", tablaMov);
            //dv.Valor = DVVMovimientos;
            //dv.Tabla = tablaMov;
            //_dvRepo.Update(dv);
            //actualizo los dvv usuarios
            string tablaUsers = "Usuario";
            int DVVUsers = _dvRepo.ObtenerSumDVH("dvh", tablaUsers);
            dv.dvv = DVVUsers;
            dv.tabla = tablaUsers;
            _dvRepo.Update(dv);
            //Cargo el movimiento en los controles de cambios
            ControlDeCambiosAppService control = new ControlDeCambiosAppService();
            control.UsuarioControlDeCambiosAdd(usuario, usuarioEnSesion, usuarioEnSesionDNI);
            //Serialización del usuario y contraseña en un archivo txt
            string nombreTxt = usuario.nombre + usuario.apellido;
            Serializacion usuarioSerializado = new Serializacion(username, passPura, nombreTxt);
            usuarioSerializado.GenerarArchivo();
        }
        public int usuarioSelectLaguage(int idUsuario)
        {
            return _repo.getUserLanguage(idUsuario);
        }
    }
}

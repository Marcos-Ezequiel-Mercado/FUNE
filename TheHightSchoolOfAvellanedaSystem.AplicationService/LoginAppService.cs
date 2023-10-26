using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Abstraction;
using TheHightSchoolOfAvellanedaSystem.Domain;
using TheHightSchoolOfAvellanedaSystem.Repository;
using TheHightSchoolOfAvellanedaSystem.Services;
using Bitacora = TheHightSchoolOfAvellanedaSystem.Services.Bitacora;
using DV = TheHightSchoolOfAvellanedaSystem.Services.DV;
//MODIFICADO
namespace TheHightSchoolOfAvellanedaSystem.AplicationService
{
    public class LoginAppService
    {
        private IUsuarioRepository _repo;
        private IBitacoraRepository _bitaRepo;
        private IDVRepository _dvRepo;
        private IMovimientosReposotory _movRepo;
        public LoginAppService() 
        {
            _repo = new UsuarioRepository();
            _bitaRepo= new BitacoraRepository();
            _dvRepo= new DVRepository();
            _movRepo = new MovimientosRepository();
        }

        public void Logout()
        {
            ManejadorDeSesion.GetInstance.Logout();
        }

        public void Login(string username, string password)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password)) throw new Exception("Por favor, ingrese los datos requeridos.");
            try
            {
                //Encripto los datos
                string usuEncriptado, passEncriptada = "";
                Encriptación unUsuarioEncriptado = new Encriptación();
                usuEncriptado = unUsuarioEncriptado.Encriptar(username, "Michael");//Poner la clave de la encriptación en el archivo de configuración 
                passEncriptada = unUsuarioEncriptado.Encriptar(password, "Michael");

                //Ahora los busco en la base 
                Domain.Usuario usuario = _repo.ObtenerUsuarioPorUsernamePassword(usuEncriptado, passEncriptada);

                if (usuario.username == null)
                {
                    usuario = _repo.ObtenerUsuarioPorUsuario(usuEncriptado);
                    if (usuario.username == null) { throw new Exception("Usuario y contraseña incorrectos"); }                    
                }
                else
                {
                    if (usuario.cai >= 3) { throw new Exception("Usuario bloqueado, por favor comuiquese con el administrador del sistema."); }
                    else 
                    { 
                    usuario = _repo.ObtenerUsuarioPorUsuario(usuEncriptado);
                    Domain.Bitacora bitacora = new Domain.Bitacora();
                    //bitacora.Id = _bitaRepo.GetLasBitacora() + 1;
                    bitacora.idUsuario = usuario.Id;
                    bitacora.dni = usuario.dni;
                    bitacora.idMovimiento = (int)Enum_Movimientos.Login;
                    bitacora.descripcion = Enum_Movimientos.Login.ToString();
                    string tabla = "Bitacora";
                    Bitacora.SetDVH(bitacora);
                    _bitaRepo.Add(bitacora);
                    int DVV = _dvRepo.ObtenerSumDVH("dvh", tabla);
                    Digitoverificador dv = new Digitoverificador();
                    dv.dvv = DVV;
                    dv.tabla = tabla;
                    _dvRepo.Update(dv);
                    //Domain.Movimientos movimiento = new Domain.Movimientos();
                    //movimiento.Id = bitacora.Id;
                    //movimiento..Usu_Id = bitacora.Usu_Id;
                    //Encriptación movimientoEncriptado = new Encriptación();
                    //movimiento.Movimiento = movimientoEncriptado.Encriptar("Ingreso al sistema", "Tyson");
                    //Services.Movimientos.SetDVH(movimiento);
                    //_movRepo.Add(movimiento);
                    //string tablaMov = "Movimientos";
                    //int DVVMovimientos = _dvRepo.ObtenerSumDVH("Mov_DVH", tablaMov);
                    //dv.Valor = DVVMovimientos;
                    //dv.Tabla = tablaMov;
                    //_dvRepo.Update(dv);
                    if (usuario.cai > 0)
                    {
                        usuario.username = usuEncriptado;
                        usuario.cai = 0;
                        Services.Usuario.SetDVH(usuario);
                        _repo.Update(usuario);
                        string tablaUsers = "Usuario";
                        int DVVUsers = _dvRepo.ObtenerSumDVH("dvh", tablaUsers);
                        dv.dvv = DVVUsers;
                        dv.tabla = tablaUsers;
                        _dvRepo.Update(dv);
                        usuario.username = username;
                        //VER SI ES NECESARIO AGREGAR LA MODIFICACIÓN DEL USUARIO A LA BITACORA

                       //VER SI ES NECESARIO AGREGAR LA MODIFICACIÓN DEL USUARIO A LA BITACORA                        
                    }
                        
                    }
                }


                usuario = _repo.addPatentes(usuario);

                //luego juego con el manejador de session
                ManejadorDeSesion.GetInstance.Login(usuario);

            }
            catch (Exception ex)
            {
                throw ex;
            } 
            finally 
            {

            }
        }
    }
}

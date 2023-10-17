using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheHightSchoolOfAvellanedaSystem.Domain;
using TheHightSchoolOfAvellanedaSystem.Repository;
using TheHightSchoolOfAvellanedaSystem.Services;

namespace TheHightSchoolOfAvellanedaSystem.AplicationService
{
    public  class ControlDeCambiosAppService
    {
        private ControlDeCambiosRepository _repo;
        public ControlDeCambiosAppService()
        {
            _repo = new ControlDeCambiosRepository();
        }

        public List<Control_de_Cambios> GetAll(int idTabla)
        {
            var listaControl = _repo.GetAll(idTabla);
            return (List<Control_de_Cambios>)listaControl;
        }

        public List<Domain.Control_de_Cambios> FindByFilter(string filter, int idTabla)
        {
            return GetAll(idTabla).FindAll(c => Convert.ToString(c.idFila).Contains(filter) || c.propiedad.Contains(filter) || Convert.ToString(c.fechaHoraCambio).Contains(filter));
        }


        public void UsuarioControlDeCambiosAdd(Domain.Usuario datosActuales, int usuarioEjecutor, long dniUsuarioEjecutaor)
        {
            Control_de_Cambios usuarioInsertado = new Control_de_Cambios();
            usuarioInsertado.idUsuario = usuarioEjecutor;
            usuarioInsertado.dni = dniUsuarioEjecutaor;
            usuarioInsertado.idTabla = 1;
            usuarioInsertado.state = Convert.ToString(datosActuales.estado);
            usuarioInsertado.fechaHoraCambio =Convert.ToDateTime(DateTime.Now.ToString("g"));

            
            PropertyInfo[] lst = typeof(Domain.Usuario).GetProperties();
            foreach (PropertyInfo pi in lst)
            {
                if (pi.Name == "password") 
                { 
                    usuarioInsertado.propiedad = "contrasenia";
                    usuarioInsertado.valorAnterior = datosActuales.password;
                    usuarioInsertado.valorActual = datosActuales.password;
                    usuarioInsertado.idFila = datosActuales.Id;
                    _repo.Add(usuarioInsertado);
                }
                else if (pi.Name == "idIdioma")
                {
                    usuarioInsertado.propiedad = "idIdioma";
                    usuarioInsertado.valorAnterior = Convert.ToString(datosActuales.idIdioma);
                    usuarioInsertado.valorActual = Convert.ToString(datosActuales.idIdioma);
                    usuarioInsertado.idFila = datosActuales.Id;
                    _repo.Add(usuarioInsertado);
                }
                else if (pi.Name == "cai")
                {
                    usuarioInsertado.propiedad = "cai";
                    usuarioInsertado.valorAnterior = Convert.ToString(datosActuales.cai);
                    usuarioInsertado.valorActual = Convert.ToString(datosActuales.cai);
                    usuarioInsertado.idFila = datosActuales.Id;
                    _repo.Add(usuarioInsertado);
                }
                else if (pi.Name == "estado")
                {
                    usuarioInsertado.propiedad = "idEstado";
                    usuarioInsertado.valorAnterior = Convert.ToString(datosActuales.estado);
                    usuarioInsertado.valorActual = Convert.ToString(datosActuales.estado);
                    usuarioInsertado.idFila = datosActuales.Id;
                    _repo.Add(usuarioInsertado);
                }
            }
        }

        public void usuarioPreRevertir(Domain.Usuario usuarioActual, string propiedad, string valor, int usuarioEjecutor, long DNIusuarioEjecutor)
        {
            Email email = new Email();
            
            Domain.Usuario usuarioModificado = new Domain.Usuario(email);
            usuarioModificado.Id= usuarioActual.Id;
            usuarioModificado.dni= usuarioActual.dni;
            usuarioModificado.username = usuarioActual.username;
            //usuarioModificado.password = usuarioActual.password;
            usuarioModificado.primerAcceso = usuarioActual.primerAcceso;
            //usuarioModificado.estado = usuarioActual.estado;
            //usuarioModificado.cai = usuarioActual.cai;
            usuarioModificado.dvh = usuarioActual.dvh;

            if (propiedad == "contrasenia")
            {
                usuarioModificado.password= valor;
            }
            else if (propiedad == "cai")
            {
                usuarioModificado.cai = Convert.ToInt32(valor);
            }
            else if (propiedad == "idEstado")
            {
                usuarioModificado.estado = Convert.ToInt32(valor);
            }
            else if (propiedad == "idIdioma")
            {
                usuarioModificado.idIdioma = Convert.ToInt32(valor);
            }
            UsuarioAppService usuarioRevertido = new UsuarioAppService();
            usuarioRevertido.updateUsuarioRevertido(usuarioModificado, usuarioEjecutor, DNIusuarioEjecutor, usuarioActual);
            
        }


        public void UsuarioControlDeCambiosAdd(Domain.Usuario datosActuales, Domain.Usuario datosAnteriores, int usuarioEjecutor, long dniUsuarioEjecutor)
        {
            Control_de_Cambios usuarioInsertado = new Control_de_Cambios();
            usuarioInsertado.idUsuario = usuarioEjecutor;
            usuarioInsertado.dni = dniUsuarioEjecutor;
            usuarioInsertado.state = Convert.ToString(datosActuales.estado);
            usuarioInsertado.idTabla = 1;
            usuarioInsertado.fechaHoraCambio = Convert.ToDateTime(DateTime.Now.ToString("g"));
            //usuarioInsetado.state = Convert.ToString(datosActuales.State);

            PropertyInfo[] lst = typeof(Domain.Usuario).GetProperties();
            PropertyInfo[] lst2 = typeof(Domain.Usuario).GetProperties();
            foreach (PropertyInfo pi in lst)
            {
                foreach (PropertyInfo pi2 in lst2)
                {

                    if (pi.Name == "contrasenia" && pi2.Name == "contrasenia")
                        if (pi.GetValue(datosActuales).ToString() == pi.GetValue(datosAnteriores).ToString()) { }
                        else
                        {
                            usuarioInsertado.propiedad = "contrasenia";
                            usuarioInsertado.valorAnterior = datosAnteriores.password;
                            usuarioInsertado.valorActual = datosActuales.password;
                            usuarioInsertado.Id = datosAnteriores.Id;
                            _repo.Add(usuarioInsertado);
                        }
                    else if (pi.Name == "cai" && pi2.Name == "cai")
                        if (pi.GetValue(datosActuales).ToString() == pi.GetValue(datosAnteriores).ToString()) { }
                        else
                        {
                            usuarioInsertado.propiedad = "cai";
                            usuarioInsertado.valorAnterior = Convert.ToString(datosAnteriores.cai);
                            usuarioInsertado.valorActual = Convert.ToString(datosActuales.cai);
                            usuarioInsertado.Id = datosAnteriores.Id;
                            _repo.Add(usuarioInsertado);
                        }
                    else if (pi.Name == "idEstado" && pi2.Name == "idEstado")
                        if (pi.GetValue(datosActuales).ToString() == pi.GetValue(datosAnteriores).ToString()) { }
                        else
                        {
                            usuarioInsertado.propiedad = "idEstado";
                            usuarioInsertado.valorAnterior = Convert.ToString(datosAnteriores.estado);
                            usuarioInsertado.valorActual = Convert.ToString(datosActuales.estado);
                            usuarioInsertado.Id = datosAnteriores.Id;
                            _repo.Add(usuarioInsertado);
                        }
                    else if (pi.Name == "idIdioma" && pi2.Name == "idIdioma")
                        if (pi.GetValue(datosActuales).ToString() == pi.GetValue(datosAnteriores).ToString()) { }
                        else
                        {
                            usuarioInsertado.propiedad = "idIdioma";
                            usuarioInsertado.valorAnterior = Convert.ToString(datosAnteriores.idIdioma);
                            usuarioInsertado.valorActual = Convert.ToString(datosActuales.idIdioma);
                            usuarioInsertado.Id = datosAnteriores.Id;
                            _repo.Add(usuarioInsertado);
                        }
                }
            }
        }

        public void UsuarioControlDeCambiosRevertir(Domain.Usuario datosActuales, Domain.Usuario datosAnteriores, int usuarioEjecutor)
        {
            Control_de_Cambios usuarioInsetado = new Control_de_Cambios();
            usuarioInsetado.idUsuario = usuarioEjecutor;
            usuarioInsetado.idTabla = 1;
            usuarioInsetado.fechaHoraCambio = DateTime.Now;
            //usuarioInsetado.state = Convert.ToString(datosActuales.State);

            PropertyInfo[] lst = typeof(Domain.Usuario).GetProperties();
            PropertyInfo[] lst2 = typeof(Domain.Usuario).GetProperties();
            foreach (PropertyInfo pi in lst)
            {
                foreach (PropertyInfo pi2 in lst2)
                {

                    if (pi.Name == "nombre" && pi2.Name == "nombre")
                        if (pi.GetValue(datosActuales).ToString() == pi.GetValue(datosAnteriores).ToString()) { }
                        else
                        {
                            usuarioInsetado.propiedad = "nombre";
                            usuarioInsetado.valorAnterior = datosActuales.nombre;
                            usuarioInsetado.valorActual = datosAnteriores.nombre;
                            usuarioInsetado.Id = datosAnteriores.Id;
                            _repo.Add(usuarioInsetado);
                        }
                    //else if (pi.Name == "Email" && pi2.Name == "Email")
                    //    if (pi.GetValue(datosActuales).ToString() == pi.GetValue(datosAnteriores).ToString()) { }
                    //    else
                    //    {
                    //        usuarioInsetado.propiedad = "Usu_Email";
                    //        usuarioInsetado.valorAnterior = datosActuales.Email; 
                    //        usuarioInsetado.valorActual = datosAnteriores.Email;
                    //        usuarioInsetado.numeroFila = datosAnteriores.Id;
                    //        _repo.Add(usuarioInsetado);
                    //    }
                    else if (pi.Name == "estado" && pi2.Name == "estado")
                        if (pi.GetValue(datosActuales).ToString() == pi.GetValue(datosAnteriores).ToString()) { }
                        else
                        {
                            usuarioInsetado.propiedad = "Est_Id";
                            usuarioInsetado.valorAnterior = Convert.ToString(datosActuales.estado);
                            usuarioInsetado.valorActual = Convert.ToString(datosAnteriores.estado);
                            usuarioInsetado.Id = datosAnteriores.Id;
                            _repo.Add(usuarioInsetado);
                        }
                }
            }
        }


    }
}

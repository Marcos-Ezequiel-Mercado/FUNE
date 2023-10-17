using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHightSchoolOfAvellanedaSystem.Services
{
    [Serializable]
    public class Serializacion
    {
        private string _usuario;
        private string _contraseña;
        private string _nombreApellido;
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public Serializacion(string usuario, string contraseña, string nombreApellido) 
        {
            _usuario = usuario;
            _contraseña = contraseña;
            _nombreApellido = nombreApellido;
        }

        public void GenerarArchivo ()
        {
            FileStream archivo = new FileStream("C:\\" + _nombreApellido + ".txt", FileMode.Create);
            StreamWriter escritorArchivo = new StreamWriter(archivo);
            string reg = String.Format("Usuario: {0}; Contraseña: {1}", _usuario, _contraseña);
            escritorArchivo.WriteLine(reg);
            escritorArchivo.Close();
        }








    }
}

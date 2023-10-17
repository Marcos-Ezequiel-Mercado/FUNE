using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;


namespace TheHightSchoolOfAvellanedaSystem.Services
{
    
    public class Encriptación
    {
        public string Encriptar(string texto, string pass)
        {
            int i, c;
            string resultado = "";
            pass = Strings.UCase(pass);
            if (Convert.ToBoolean(Strings.Len(pass)))
            {
                for (i = 1; i <= Strings.Len(texto); i++)
                {
                    c = Strings.Asc(Strings.Mid(texto, i, 1));
                    c = c + Strings.Asc(Strings.Mid(pass, (i % Strings.Len(pass)) + 1, 1));
                    resultado = resultado + Strings.Chr(c & 0xFF);
                }
            }
            else
                resultado = texto;
            return resultado;
        }
        public string Desencriptar(string texto, string pass)
        {
            int i, c;
            string resultado = "";
            pass = Strings.UCase(pass);
            if (Convert.ToBoolean(Strings.Len(pass)))
            {
                for (i = 1; i <= Strings.Len(texto); i++)
                {
                    c = Strings.Asc(Strings.Mid(texto, i, 1));
                    c = c - Strings.Asc(Strings.Mid(pass, (i % Strings.Len(pass)) + 1, 1));
                    resultado = resultado + Strings.Chr(c & 0xFF);
                }
            }
            else
                resultado = texto;
            return resultado;
        }
    }
}

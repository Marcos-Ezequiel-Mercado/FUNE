using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Abstraction;
using TheHightSchoolOfAvellanedaSystem.Services;

namespace TheHightSchoolOfAvellanedaSystem.Domain
{

    //MODIFICADO
    public class Usuario : Persona, Entity, IUsuario
    {
      
        public Usuario() 
        { 
        
        }
        
        public Usuario(Email email) : base(email)
        {

        }
        


        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; } 
        public int cai { get; set; }
        public int estado { get; set; }
        public bool primerAcceso { get; set; }
        public int idIdioma { get; set; }
        public int dvh { get; set; }
        public string email { get; set; }
        public string calle { get; set; }
        public int numero { get; set; }
        public int codigoPostal { get; set; }
        public int localidad { get; set; }
        public List<string> patentes { get; set; }


    }
}

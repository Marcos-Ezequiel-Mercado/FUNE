using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHightSchoolOfAvellanedaSystem.Abstraction
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    public interface IUsuario : IPersona, IEntity 
    {
        string username { get; set; }

        string password { get; set; }

        int cai { get; set; }

        int estado { get; set; }
        bool primerAcceso { get; set; }

        int idIdioma { get; set; }
        int dvh { get; set; }

        List <string> patentes { get; set; }
    }
}

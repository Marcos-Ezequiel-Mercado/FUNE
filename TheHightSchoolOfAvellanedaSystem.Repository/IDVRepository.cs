using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Domain;

namespace TheHightSchoolOfAvellanedaSystem.Repository
{
    public interface IDVRepository:IGenericRepository<Digitoverificador>
    {
        int ActualizarDVV(string elemento, int dv_Valor, string tabla);
        int ObtenerSumDVH(string columna, string tabla);
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Domain;

namespace TheHightSchoolOfAvellanedaSystem.Repository
{
    public interface IMovimientosReposotory : IGenericRepository<Movimientos>
    {
        int UpdateDVH(int nuevoDVH, int Id);
    }
}

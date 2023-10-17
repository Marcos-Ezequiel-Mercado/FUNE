using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Domain;
using TheHightSchoolOfAvellanedaSystem.Repository;

namespace TheHightSchoolOfAvellanedaSystem.AplicationService
{
    public class MovimientosAppService
    {
        private IMovimientosReposotory _repo;

        public MovimientosAppService()
        {
            _repo = new MovimientosRepository();
        }

        public IEnumerable<Movimientos> GetAll()
        {
            return _repo.GetAll();
        }

        public int UpdateDVH(int nuevoDVH, int Id)
        {
            return _repo.UpdateDVH(nuevoDVH, Id);

        }
    }
}

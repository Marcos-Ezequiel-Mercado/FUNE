using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Domain;
using TheHightSchoolOfAvellanedaSystem.Repository;

namespace TheHightSchoolOfAvellanedaSystem.AplicationService
{
    public class FamiliaAppService
    {
        private IFamiliaRepository _repo;

        public FamiliaAppService()
        {
            _repo = new FamiliaRepository();
        }

        public List<Familia> GetAll()
        {
            return (List<Familia>)_repo.GetAll();
        }
    }
}

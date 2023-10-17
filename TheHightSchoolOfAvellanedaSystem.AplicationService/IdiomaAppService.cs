using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Domain;
using TheHightSchoolOfAvellanedaSystem.Repository;

namespace TheHightSchoolOfAvellanedaSystem.AplicationService
{
    public class IdiomaAppService
    {
        private IIdiomaRepository _repo;

        public IdiomaAppService()
        {
            _repo = new IdiomaRepository();
        }

        public List<Idioma> GetAll()
        {
            return (List<Idioma>)_repo.GetAll();
        }
    }
}

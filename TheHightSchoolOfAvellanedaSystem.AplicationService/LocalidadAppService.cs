using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Domain;
using TheHightSchoolOfAvellanedaSystem.Repository;

namespace TheHightSchoolOfAvellanedaSystem.AplicationService
{
    public class LocalidadAppService
    {
        private ILocalidadRepository _repo;

        public LocalidadAppService()
        {
            _repo = new LocalidadRepository();
        }

        public List<Localidad> GetAll()
        {
            return (List<Localidad>)_repo.GetAll();
        }
    }
}

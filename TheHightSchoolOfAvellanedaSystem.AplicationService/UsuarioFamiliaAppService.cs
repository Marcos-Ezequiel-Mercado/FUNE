using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Repository;

namespace TheHightSchoolOfAvellanedaSystem.AplicationService
{
    public class UsuarioFamiliaAppService
    {
        private IUsuarioFamiliaRepository _repo;

        public UsuarioFamiliaAppService()
        {
            _repo = new UsuarioFamiliaRepository();
        }
        public int add(Domain.UsuarioFamilia usuariofamilia)
        {
            return _repo.Add(usuariofamilia);
        }
    }
}

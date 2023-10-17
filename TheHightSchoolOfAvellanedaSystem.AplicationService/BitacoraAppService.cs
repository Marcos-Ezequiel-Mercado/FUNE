using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Domain;
using TheHightSchoolOfAvellanedaSystem.Repository;

namespace TheHightSchoolOfAvellanedaSystem.AplicationService
{
    public  class BitacoraAppService
    {
        private IBitacoraRepository _repo;

        public BitacoraAppService()
        {
            _repo = new BitacoraRepository();
        }

        public IEnumerable<Bitacora> GetAllWhitFilters(string fechaDesde, string fechaHasta, int usuario, string criticidad, bool formaAscendente)
        {
            if (fechaDesde.ToString() == "Seleccione") {fechaDesde = null;}
            if (fechaHasta.ToString() == "Seleccione") { fechaHasta = null; }
            if (usuario.ToString() == "Seleccione usuario") { Convert.ToInt16(usuario == 0); }
            if (criticidad.ToString() == "Seleccione criticidad") { criticidad = null; }
            return _repo.GetAllWhitFilters(Convert.ToDateTime(fechaDesde), Convert.ToDateTime(fechaHasta), usuario, criticidad, formaAscendente);
        }

        public IEnumerable<Bitacora> GetAll()
        {
            return _repo.GetAll();
        }

        public int UpdateDVH(int nuevoDVH, int Id)
        {
            return _repo.UpdateDVH(nuevoDVH, Id);

        }
    }
}

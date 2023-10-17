using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Domain;

namespace TheHightSchoolOfAvellanedaSystem.Repository
{
    public interface IBitacoraRepository:IGenericRepository<Domain.Bitacora>
    {
        IEnumerable<Bitacora> GetAllWhitFilters(DateTime? fechaDesde, DateTime? fechaHasta, int? usuario, string criticidad, bool? formaAscendente);

        int GetLasBitacora();

        int UpdateDVH(int nuevoDVH, int Id);
    }
}

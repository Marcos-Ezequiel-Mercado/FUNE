using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Repository;

namespace TheHightSchoolOfAvellanedaSystem.AplicationService
{
    public class RestoreAppService
    {
        private RestoreRepository _repoRestore;
        public RestoreAppService()
        {
            _repoRestore = new RestoreRepository();
        }

        public void RealizarRestore(string destino)
        {
            try
            {
                if (String.IsNullOrEmpty(destino)) { throw new Exception("Por favor, seleccione la ubicación del backup para realizar la restauración."); }
                string BaseSeg = "DER_SEGURIDAD";
                _repoRestore.RealizarRestore(BaseSeg, destino);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Repository;

namespace TheHightSchoolOfAvellanedaSystem.AplicationService
{
    public class BackupAppService
    {
        private BackupRepository _repoBackup;
        public BackupAppService() 
        {
            _repoBackup = new BackupRepository();
        }

        public void RealizarBU(string destino)
        {
            try
            {
                if (String.IsNullOrEmpty(destino)) { throw new Exception("Por favor, seleccione el destino del backup para realizar la operación."); }
                string BaseSeg = "DER_SEGURIDAD";
                //string BaseNeg = "DER_NEGOCIO";
                var MyDate = DateTime.Now;
                string MyString = MyDate.ToString("dd-MM-yyyy_hh-mm");
                string DestinoSeg = "";
                //string DestinoNeg = "";
                string NameBackSeg = "_BackUp_Total_Seguridad.bak";
                //string NameBackNeg = "_BackUp_Total_Negocio.bak";
                //DestinoNeg = destino + @"\" + MyString + NameBackNeg;
                DestinoSeg = destino + @"\" + MyString + NameBackSeg;

                _repoBackup.RealizarBU(BaseSeg, DestinoSeg);
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
    }
}

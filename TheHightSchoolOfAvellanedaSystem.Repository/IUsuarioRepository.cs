using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Domain;

namespace TheHightSchoolOfAvellanedaSystem.Repository
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        //ACÁ PUEDO TENER OTROS MÉTODOS APARTE DE LOS DEL CONTRATO CON LA INTERFAZ IGENERICREPOSITORY
        //Ejemplo la lista de usuarios que no esten dados de baja
        Usuario ObtenerUsuarioPorUsernamePassword(string username, string password);
        //IEnumerable<Usuario> ObtenerUsuarioPorUsernamePassword(string username, string password);
        Usuario ObtenerUsuarioPorId(int id);
        //IEnumerable<Usuario> ObtenerUsuarioPorId(Guid id);
        Usuario ObtenerUsuarioPorUsuario(string username);

        int UpdateDVH(int nuevoDVH, int Id);
        int selectLastUser();

        int isertLanguage(int idUsuario, int idIdioma, string descripcionIdioma);
        int getUserLanguage(int idUsuario);

        int updateUserLanguage(int idUsuario, int idIdioma, string descripcionIdioma);
        Usuario addPatentes(Usuario usuario);
    }
}

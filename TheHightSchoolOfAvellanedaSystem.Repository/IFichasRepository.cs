using System.Collections.Generic;
using TheHightSchoolOfAvellanedaSystem.Domain;

namespace TheHightSchoolOfAvellanedaSystem.Repository
{
    public interface IFichasRepository
    {
        List<Ficha> listarFichasSegunFiltro(Filtro filtro);
    }
}
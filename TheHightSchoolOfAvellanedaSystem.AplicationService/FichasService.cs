using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using TheHightSchoolOfAvellanedaSystem.Domain;
using TheHightSchoolOfAvellanedaSystem.Repository;

public class FichasService
{
	private FichasRepository repository;

	public FichasService()
	{
		repository = new FichasRepository();

    }

	public DataTable buscarConFiltro(Filtro filtro) {
		
            List<Ficha> resultados = repository.listarFichasSegunFiltro(filtro);

		if (resultados == null || !resultados.Any())
		{
			System.Windows.Forms.MessageBox.Show("No se encontraron resultados con esos datos");
		}
            return this.cargarDataTable(resultados);
		
	}

    public void editarFichaService(Ficha ficha)
    {
		repository.Update(ficha);
    }

	//=================
	// nuevo Matias.
	public void Baja(Ficha ficha, int idUsuario)
	{
		repository.Baja(ficha, idUsuario);
	}
	//=================

    private DataTable cargarDataTable(List<Ficha> resultados)
	{
        DataTable data = this.createDataTableDesdeUnaEntidad<Ficha>();

		foreach (var resultado in resultados)
		{
			DataRow row = data.NewRow();
			foreach (DataColumn colum in data.Columns)
			{
				PropertyInfo propertyInfo = resultado.GetType().GetProperty(colum.ColumnName);
				if (propertyInfo != null)
				{
					row[colum.ColumnName] = propertyInfo.GetValue(resultado, null);
				}
				            }
            data.Rows.Add(row);
        }
		return data;
    }

	private DataTable createDataTableDesdeUnaEntidad<T>()
	{
		DataTable dt = new DataTable();
		PropertyInfo[] propertyInfos = typeof(T).GetProperties();

		foreach (PropertyInfo propertyInfo in propertyInfos)
		{
			dt.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType);
		}

		return dt;
	}
}

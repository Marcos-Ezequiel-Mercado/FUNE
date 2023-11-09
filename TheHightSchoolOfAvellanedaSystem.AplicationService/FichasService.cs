using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using TheHightSchoolOfAvellanedaSystem.Domain;
using TheHightSchoolOfAvellanedaSystem.Repository;
using TheHightSchoolOfAvellanedaSystem.Services;

public class FichasService
{
	private FichasRepository repository;
    private TheHightSchoolOfAvellanedaSystem.Domain.Usuario usuario;
	public FichasService()
	{
		repository = new FichasRepository();
        usuario = capturarUsuarioLogueado();
    }

	public DataTable buscarConFiltro(Filtro filtro) {
		
            List<Ficha> resultados = repository.listarFichasSegunFiltro(filtro);

		if (resultados == null || !resultados.Any())
		{
			System.Windows.Forms.MessageBox.Show("No se encontraron resultados con esos datos");
		}
            return this.cargarDataTable(resultados);
		
	}

    // nuevo Matias.
    public DataTable vistaHistorico(string idRegistro)
    {
        List<Ficha> resultado = repository.Historico(idRegistro);

        if (resultado == null || !resultado.Any())
        {
            System.Windows.Forms.MessageBox.Show("No se encontraron resultados con este ID: " + idRegistro);
        }
        return this.cargarDataTable(resultado);
    }

    public bool editarFichaService(Ficha ficha)
    {
        try
        {
            if (ficha != null)
            {
                return repository.Update(ficha);
            }

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
        return false;

    }

    public bool eliminarFicha(string fichaId)
    {
        bool exito = false;
        try
        {
            if (fichaId != null)
            {
                return repository.Remove(usuario, fichaId);
            }
            return exito;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public bool guardarFicha(Ficha ficha, TheHightSchoolOfAvellanedaSystem.Domain.Usuario usuario)
    {
        bool exito = false;
        try
        {
            if (ficha != null && usuario != null)
            {
                return repository.Add(ficha,usuario);
            }
            return exito;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

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

    private TheHightSchoolOfAvellanedaSystem.Domain.Usuario capturarUsuarioLogueado()
    {
        TheHightSchoolOfAvellanedaSystem.Domain.Usuario usuario = new TheHightSchoolOfAvellanedaSystem.Domain.Usuario();
        usuario.Id = ManejadorDeSesion.GetInstance.Session.Id;
        usuario.nombre = ManejadorDeSesion.GetInstance.Session.nombre;
        usuario.apellido = ManejadorDeSesion.GetInstance.Session.apellido;
        usuario.dni = ManejadorDeSesion.GetInstance.Session.dni;
        usuario.username = ManejadorDeSesion.GetInstance.Session.username;

        return usuario;

    }

    public Ficha ultmaFicha()
    {
        Ficha ultmaFicha = repository.ultimaFicha();

        return ultmaFicha;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHightSchoolOfAvellanedaSystem.Abstraction;

namespace TheHightSchoolOfAvellanedaSystem.Domain
{
    public class Ficha : IEntity
    {
        private string total;
        private string nombre;
        private string sexo;
        private string fechaFalle;
        private string horaFalle;
        private string lugFalle;
        private string fechaNac;
        private string edad;
        private string estudios;
        private string estCivil;
        private string conyuge;
        private string padre;
        private string madre;
        private string domicilio;
        private string partido;
        private string nacional;
        private string provincia;
        private string documento;
        private string profesion;
        private string medico;
        private string diagnostic;
        private string regCivil;
        private string cementerio;
        private string edadMadre;
        private string embarazos;
        private string sitConyuga;
        private string vivos;
        private string muertos;
        private string pesoNacer;
        private string pesoMorir;
        private string responsable;
        private string direccion2;
        private string codPostal;
        private string documento2;
        private string observac;
        private string ataud;
        private string mortaja;
        private string funebres;
        private string velatorio;
        private string azafatas;
        private string lacayos;
        private string portac;
        private string remises;
        private string servre;
        private string anuncios;
        private string benefic;
        private string gastos;
        private string importe;
        private string horaInh;
        private string fechaInh;
        private string usuario;
        private string afin;
        private string fechaEliminacion;
        private string telResponsable;

        public Ficha()
        {
        }

        public Ficha(int id, string total, string nombre, string sexo, string fechaDeFallecimiento, string horaDeFallecimiento,
            string lugarDeFallecimiento, string fechaDeNacimiento, string edad, string estudios, string estadoCivil, string conyugue, string padre, 
            string madre, string domicilio, string partido, string nacionalidad, string provincia, string documento, string profesion, string medico,
            string diagnostico, string registroCivil, string cementerio, string edadMadre, string embarazos, string sitConyugal, string vivos, string muertos,
            string pesoNacer, string pesoMorir, string responsable, string domicilio2, string codigoPostal, string documento2, string observacion, string ataud, 
            string mortaja, string funebre, string velatorio, string azafata, string lacayos, string portac, string remises, string servre, string anuncios,
            string beneficios, string gastos, string importe, string horaInh, string fechaInh, string usuario, string afin, string fechaBaja, string telResponsable)
        {
            Id = id;
            Total = total;
            Nombre = nombre;
            Sexo = sexo;
            FechaDeFallecimiento = fechaDeFallecimiento;
            HoraDeFallecimiento = horaDeFallecimiento;
            LugarDeFallecimiento = lugarDeFallecimiento;
            FechaDeNacimiento = fechaDeNacimiento;
            Edad = edad;
            Estudios = estudios;
            EstadoCivil = estadoCivil;
            Conyugue = conyugue;
            Padre = padre;
            Madre = madre;
            Domicilio = domicilio;
            Partido = partido;
            Nacionalidad = nacionalidad;
            Provincia = provincia;
            Documento = documento;
            Profesion = profesion;
            Medico = medico;
            Diagnostico = diagnostico;
            RegistroCivil = registroCivil;
            Cementerio = cementerio;
            EdadMadre = edadMadre;
            Embarazos = embarazos;
            SitConyugal = sitConyugal;
            Vivos = vivos;
            Muertos = muertos;
            PesoNacer = pesoNacer;
            PesoMorir = pesoMorir;
            Responsable = responsable;
            DomicilioResponsable = domicilio2;
            CodigoPostal = codigoPostal;
            DocumentoResponsable = documento2;
            Observacion = observacion;
            Ataud = ataud;
            Mortaja = mortaja;
            Funebre = funebre;
            Velatorio = velatorio;
            Azafata = azafata;
            Lacayos = lacayos;
            Portac = portac;
            Remises = remises;
            Servre = servre;
            Anuncios = anuncios;
            Beneficios = beneficios;
            Gastos = gastos;
            Importe = importe;
            HoraInh = horaInh;
            FechaInh = fechaInh;
            Usuario = usuario;
            Afin = afin;
            FechaEliminacion = fechaBaja;
            TelResponsable = telResponsable;
        }

        public Ficha(int id, string nombre, string sexo, string fechaDeFallecimiento, string horaDeFallecimiento,
           string lugarDeFallecimiento, string fechaDeNacimiento, string edad, string estudios, string estadoCivil, string conyugue, string padre,
           string madre, string domicilio, string partido, string nacionalidad, string provincia, string documento, string profesion, string medico,
           string diagnostico, string registroCivil, string cementerio, string domicilioResponsable, string codigoPostal, string documentoResponsable,
           string beneficios, string gastos,  string horaInh,string fechaInh, string usuario, string afin,string responsable, string sitConyuga, string telResponsable)
        {
            Id = id;
            Nombre = nombre;
            Sexo = sexo;
            FechaDeFallecimiento = fechaDeFallecimiento;
            HoraDeFallecimiento = horaDeFallecimiento;
            LugarDeFallecimiento = lugarDeFallecimiento;
            FechaDeNacimiento = fechaDeNacimiento;
            Edad = edad;
            Estudios = estudios;
            EstadoCivil = estadoCivil;
            Conyugue = conyugue;
            Padre = padre;
            Madre = madre;
            Domicilio = domicilio;
            Partido = partido;
            Nacionalidad = nacionalidad;
            Provincia = provincia;
            Documento = documento;
            Profesion = profesion;
            Medico = medico;
            Diagnostico = diagnostico;
            RegistroCivil = registroCivil;
            Cementerio = cementerio;
            DomicilioResponsable = domicilioResponsable;
            CodigoPostal = codigoPostal;
            DocumentoResponsable = documentoResponsable;
            Beneficios = beneficios;
            Gastos = gastos;           
            HoraInh = horaInh;
            FechaInh = fechaInh;
            Usuario = usuario;
            Afin = afin;
            Responsable = responsable;
            SitConyugal = sitConyuga;
            TelResponsable = telResponsable;
        }

        public int Id { get ; set; }
        public string Total { get => total; set => total = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string FechaDeFallecimiento { get => fechaFalle; set => fechaFalle = value; }
        public string HoraDeFallecimiento { get => horaFalle; set => horaFalle = value; }
        public string LugarDeFallecimiento { get => lugFalle; set => lugFalle = value; }
        public string FechaDeNacimiento { get => fechaNac; set => fechaNac = value; }
        public string Edad { get => edad; set => edad = value; }
        public string Estudios { get => estudios; set => estudios = value; }
        public string EstadoCivil { get => estCivil; set => estCivil = value; }
        public string Conyugue { get => conyuge; set => conyuge = value; }
        public string Padre { get => padre; set => padre = value; }
        public string Madre { get => madre; set => madre = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Partido { get => partido; set => partido = value; }
        public string Nacionalidad { get => nacional; set => nacional = value; }
        public string Provincia { get => provincia; set => provincia = value; }
        public string Documento { get => documento; set => documento = value; }
        public string Profesion { get => profesion; set => profesion = value; }
        public string Medico { get => medico; set => medico = value; }
        public string Diagnostico { get => diagnostic; set => diagnostic = value; }
        public string RegistroCivil { get => regCivil; set => regCivil = value; }
        public string Cementerio { get => cementerio; set => cementerio = value; }
        public string EdadMadre { get => edadMadre; set => edadMadre = value; }
        public string Embarazos { get => embarazos; set => embarazos = value; }
        public string SitConyugal { get => sitConyuga; set => sitConyuga = value; }
        public string Vivos { get => vivos; set => vivos = value; }
        public string Muertos { get => muertos; set => muertos = value; }
        public string PesoNacer { get => pesoNacer; set => pesoNacer = value; }
        public string PesoMorir { get => pesoMorir; set => pesoMorir = value; }
        public string Responsable { get => responsable; set => responsable = value; }
        public string DomicilioResponsable { get => direccion2; set => direccion2 = value; }
        public string CodigoPostal { get => codPostal; set => codPostal = value; }
        public string DocumentoResponsable { get => documento2; set => documento2 = value; }
        public string Observacion { get => observac; set => observac = value; }
        public string Ataud { get => ataud; set => ataud = value; }
        public string Mortaja { get => mortaja; set => mortaja = value; }
        public string Funebre { get => funebres; set => funebres = value; }
        public string Velatorio { get => velatorio; set => velatorio = value; }
        public string Azafata { get => azafatas; set => azafatas = value; }
        public string Lacayos { get => lacayos; set => lacayos = value; }
        public string Portac { get => portac; set => portac = value; }
        public string Remises { get => remises; set => remises = value; }
        public string Servre { get => servre; set => servre = value; }
        public string Anuncios { get => anuncios; set => anuncios = value; }
        public string Beneficios { get => benefic; set => benefic = value; }
        public string Gastos { get => gastos; set => gastos = value; }
        public string Importe { get => importe; set => importe = value; }
        public string HoraInh { get => horaInh; set => horaInh = value; }
        public string FechaInh { get => fechaInh; set => fechaInh = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Afin { get => afin; set => afin = value; }
        public string FechaEliminacion { get => fechaEliminacion; set => fechaEliminacion = value; }
        public string TelResponsable { get => telResponsable; set => telResponsable = value; }
    }
}


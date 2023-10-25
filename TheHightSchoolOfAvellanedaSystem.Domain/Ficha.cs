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
        private string fechaDeFallecimiento;
        private string horaDeFallecimiento;
        private string lugarDeFallecimiento;
        private string fechaDeNacimiento;
        private string edad;
        private string estudios;
        private string estadoCivil;
        private string conyugue;
        private string padre;
        private string madre;
        private string domicilio;
        private string partido;
        private string nacionalidad;
        private string provincia;
        private string documento;
        private string profesion;
        private string medico;
        private string diagnostico;
        private string registroCivil;
        private string cementerio;
        private string edadMadre;
        private string embarazos;
        private string sitConyugal;
        private string vivos;
        private string muertos;
        private string pesoNacer;
        private string pesoMorir;
        private string apellido;
        private string domicilio2;
        private string codigoPostal;
        private string documento2;
        private string observacion;
        private string ataud;
        private string mortaja;
        private string funebre;
        private string velatorio;
        private string azafata;
        private string lacayos;
        private string portac;
        private string remises;
        private string servre;
        private string anuncios;
        private string beneficios;
        private string gastos;
        private string importe;
        private string horaInh;
        private string fechaInh;
        private string usuario;
        private string tipoAtaud;
        private string fechaBaja;

        
        public Ficha()
        {          
        }
        //===================
        // prueba.
        
        //======================
        public Ficha(int id, string total, string nombre, string sexo, string fechaDeFallecimiento, string horaDeFallecimiento,
            string lugarDeFallecimiento, string fechaDeNacimiento, string edad, string estudios, string estadoCivil, string conyugue, string padre, 
            string madre, string domicilio, string partido, string nacionalidad, string provincia, string documento, string profesion, string medico,
            string diagnostico, string registroCivil, string cementerio, string edadMadre, string embarazos, string sitConyugal, string vivos, string muertos,
            string pesoNacer, string pesoMorir, string apellido, string domicilio2, string codigoPostal, string documento2, string observacion, string ataud, 
            string mortaja, string funebre, string velatorio, string azafata, string lacayos, string portac, string remises, string servre, string anuncios,
            string beneficios, string gastos, string importe, string horaInh, string fechaInh, string usuario, string tipoAtaud, string fechaBaja)
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
            Apellido = apellido;
            Domicilio2 = domicilio2;
            CodigoPostal = codigoPostal;
            Documento2 = documento2;
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
            TipoAtaud = tipoAtaud;
            FechaBaja = fechaBaja;
        }

        public Ficha(int id, string nombre, string sexo, string fechaDeFallecimiento, string horaDeFallecimiento,
           string lugarDeFallecimiento, string fechaDeNacimiento, string edad, string estudios, string estadoCivil, string conyugue, string padre,
           string madre, string domicilio, string partido, string nacionalidad, string provincia, string documento, string profesion, string medico,
           string diagnostico, string registroCivil, string cementerio, string domicilio2, string codigoPostal, string documento2,
           string beneficios, string gastos,  string horaInh,  string usuario, string tipoAtaud)
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
            Domicilio2 = domicilio2;
            CodigoPostal = codigoPostal;
            Documento2 = documento2;
            Beneficios = beneficios;
            Gastos = gastos;           
            HoraInh = horaInh;            
            Usuario = usuario;
            TipoAtaud = tipoAtaud;     
        }

        public int Id { get ; set; }
        public string Total { get => total; set => total = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string FechaDeFallecimiento { get => fechaDeFallecimiento; set => fechaDeFallecimiento = value; }
        public string HoraDeFallecimiento { get => horaDeFallecimiento; set => horaDeFallecimiento = value; }
        public string LugarDeFallecimiento { get => lugarDeFallecimiento; set => lugarDeFallecimiento = value; }
        public string FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public string Edad { get => edad; set => edad = value; }
        public string Estudios { get => estudios; set => estudios = value; }
        public string EstadoCivil { get => estadoCivil; set => estadoCivil = value; }
        public string Conyugue { get => conyugue; set => conyugue = value; }
        public string Padre { get => padre; set => padre = value; }
        public string Madre { get => madre; set => madre = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Partido { get => partido; set => partido = value; }
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public string Provincia { get => provincia; set => provincia = value; }
        public string Documento { get => documento; set => documento = value; }
        public string Profesion { get => profesion; set => profesion = value; }
        public string Medico { get => medico; set => medico = value; }
        public string Diagnostico { get => diagnostico; set => diagnostico = value; }
        public string RegistroCivil { get => registroCivil; set => registroCivil = value; }
        public string Cementerio { get => cementerio; set => cementerio = value; }
        public string EdadMadre { get => edadMadre; set => edadMadre = value; }
        public string Embarazos { get => embarazos; set => embarazos = value; }
        public string SitConyugal { get => sitConyugal; set => sitConyugal = value; }
        public string Vivos { get => vivos; set => vivos = value; }
        public string Muertos { get => muertos; set => muertos = value; }
        public string PesoNacer { get => pesoNacer; set => pesoNacer = value; }
        public string PesoMorir { get => pesoMorir; set => pesoMorir = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Domicilio2 { get => domicilio2; set => domicilio2 = value; }
        public string CodigoPostal { get => codigoPostal; set => codigoPostal = value; }
        public string Documento2 { get => documento2; set => documento2 = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public string Ataud { get => ataud; set => ataud = value; }
        public string Mortaja { get => mortaja; set => mortaja = value; }
        public string Funebre { get => funebre; set => funebre = value; }
        public string Velatorio { get => velatorio; set => velatorio = value; }
        public string Azafata { get => azafata; set => azafata = value; }
        public string Lacayos { get => lacayos; set => lacayos = value; }
        public string Portac { get => portac; set => portac = value; }
        public string Remises { get => remises; set => remises = value; }
        public string Servre { get => servre; set => servre = value; }
        public string Anuncios { get => anuncios; set => anuncios = value; }
        public string Beneficios { get => beneficios; set => beneficios = value; }
        public string Gastos { get => gastos; set => gastos = value; }
        public string Importe { get => importe; set => importe = value; }
        public string HoraInh { get => horaInh; set => horaInh = value; }
        public string FechaInh { get => fechaInh; set => fechaInh = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string TipoAtaud { get => tipoAtaud; set => tipoAtaud = value; }
        public string FechaBaja { get => fechaBaja; set => fechaBaja = value; }
    }
}


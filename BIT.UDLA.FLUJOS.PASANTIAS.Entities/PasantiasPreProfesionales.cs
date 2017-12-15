using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Entities
{

    public enum HorarioTrabajo : int
    {
        None = 0,
        Invalid = 1,
        MedioTiempo = 2,
        TiempoCompleto = 4,
    }

    [Serializable]
    public class PasantiasPreProfesionales
    {

        public System.Nullable<System.DateTime> FechaInicio { set; get; }
        public System.Nullable<System.DateTime> FechaFin { set; get; }
        public string Empresa { set; get; }
        public string Carrera { set; get; }
        public string Materia { set; get; }
        public string Estado { set; get; }
        public string TipoPasantiaEnum { set; get; }
        public System.Nullable<bool> EsSeleccionado { get; set; }
        public System.Nullable<bool> FinPractica { get; set; }
        public System.Nullable<double> HorasAprobadasPorEmpresa { get; set; }
        public string  CedulaIdentidad{ get; set; }
        public string Cargo { set; get; }
        public string AreaTrabajo { set; get; }
        public string Funciones { set; get; }
        public System.Nullable<double> NumeroHorasEjecutadas { set; get; }
        public string Matricula { get; set; }
        public string NombreSaes { get; set; }
        public string NombreAlumno { get; set; }
        public string ApellidoAlumno { get; set; }
        public System.Nullable<double> IdEmpresa { get; set; }
        public string NombreSupervisor { get; set; }
        public string TelefonoSupervisor { get; set; }
        public string EmailSupervisor { get; set; }
        public System.Nullable<bool> AceptoConvenio { get; set; }
        public System.Nullable<System.DateTime> FechaInicioProceso { get; set; }
        public System.Nullable<bool> EvaluoEmpresa { get; set; }
        public System.Nullable<bool> EvaluoAlumno { get; set; }
        public System.Nullable<HorarioTrabajo> HorarioTrabajo { set; get; }
        public System.Nullable<int> SupervisorDeEmpresaIdentificador { get; set; }
        public string SupervisorDeEmpresaImnName { get; set; }
        public System.Nullable<int> DocenteIdentificador { get; set; }
        public string DocenteImnName { get; set; }
        public System.Nullable<int> TutorIdentificador { get; set; }
        public string TutorImnName { get; set; }
        public System.Nullable<int> AlumnoIdentificador { get; set; }
        public string AlumnoImnName { get; set; }
        public int? Id { get; set; }
      	public string ObservacionesDeRegistroDeHorasSAES{ get; set; }
		public System.Nullable<bool> GenerarCartaCompromiso{ get; set; }
		public System.Nullable<bool> ProblemaEnElSistemaSAES{ get; set; }
		public System.Nullable<System.DateTime> FechaDelProblema{ get; set; }
		public System.Nullable<double> HorasAprobadasTutor{ get; set; }
		public System.Nullable<System.DateTime> FechaAprobacionTutor{ get; set; }
		public System.Nullable<System.DateTime> FechaAprobacionEmpresa{ get; set; }
		public System.Nullable<System.DateTime> FechaAprobacionSupervisor{ get; set; }
		public System.Nullable<bool> AprobacionTutorIngresoHorasSAES{ get; set; }
		public System.Nullable<bool> FichaDeInscripcionAprobadaPorTutor{ get; set; }
		public System.Nullable<bool> FichaDeInscripcionAprobadaPorEmpresa{ get; set; }
		public System.Nullable<bool> AprobadoPorTutorParaRegistroEnSAES{ get; set; }
        public System.Nullable<double> HorasRevisadasTutor{ get; set; }
        public System.Nullable<System.DateTime> FechaFinalizacionTutor{ get; set; }
        public System.Nullable<double> Nivel{ get; set; }
        public string CodigoCarrera{ get; set; }
        public string CodigoDeMateria{ get; set; }
        public System.Nullable<double> HorasIngresadasSAES{ get; set; }
        public System.Nullable<System.DateTime> FechaDeIngresoEnElSistemaSAES{ get; set; }
        public System.Nullable<bool> CreacionDeCartaDeCompromiso{ get; set; }
        public System.Nullable<double> HorasActualesEnElSistemaSAES{ get; set; }
        public System.Nullable<bool> EsSeleccionadoPorDocente{ get; set; }
        public string NombreTutorSAES { get; set; }
        public string NombreDocenteSAES { get; set; }
        public string EmailAlumno { get; set; }
        public System.Nullable<bool> EsOfertaLaboral { get; set; }
        public string TelefonoAlumno { get; set; }
        public System.Nullable<double> PlanAlumno { get; set; }
        public string CodigoEspecialidad { get; set; }
        public string JornadaAlumno { get; set; }
        public string TelefonoCelularAlumno { get; set; }
        public string DireccionAlumno { get; set; }
        public string SexoAlumno { get; set; }
        public string CiudadNacimientoAlumno { get; set; }
        public string EstadoCivilAlumno { get; set; }
        public System.Nullable<double> IDOfertaLaboral { get; set; }
        public System.Nullable<double> PERID { get; set; }
        public System.Nullable<System.DateTime> FechaNacimientoAlumno { get; set; }
        public string Titulo { get; set; }
        public string Accion { get; set; }
        public string CedulaTutor { get; set; }
        public string CedulaDocente { get; set; }
        public DateTime? FechaFinProcesoPractica { get; set; }
        public string ObservacionError { get; set; }
        public double? MaximoHorasMateria { get; set; }
        public string Url { get; set; }
        public string TelefonoEmpresa { get; set; }
        public string DireccionEmpresa { get; set; }

     
    }
}
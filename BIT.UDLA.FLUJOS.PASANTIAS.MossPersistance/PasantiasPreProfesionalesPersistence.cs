using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Linq;
using Microsoft.SharePoint;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using BIT.UDLA.FLUJOS.PASANTIAS.Comun;
using db = BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance;
using System.Web;
using Microsoft.SharePoint.WebControls;

namespace BIT.UDLA.FLUJOS.PASANTIAS.MossPersistance
{
    public class PasantiasPreProfesionalesPersistence : LogicBase<PasantiasPreProfesionales, ListaPasantiasElemento>
    {
        public bool Insertar(PasantiasPreProfesionales item, out int? id)
        {
            bool result = false;
            int? auxId = 0;
            string strUrl = Properties.UdlaListDefinitions.Default.Url_Sitio;
            try
            {
                if (SPContext.Current != null)
                    HttpContext.Current = null;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite oSite = new SPSite(strUrl))
                    {
                        using (SPWeb oWeb = oSite.OpenWeb())
                        {

                            HttpRequest httpRequest = new HttpRequest("", oWeb.Url, "");
                            HttpContext.Current = new HttpContext(httpRequest, new HttpResponse(new System.IO.StringWriter()));
                            SPControl.SetContextWeb(HttpContext.Current, oWeb);
                            using (UdlaEntityDataContext context = new UdlaEntityDataContext(oWeb.Url))
                            {
                                EntityList<ListaPasantiasElemento> pasantias = context.GetList<ListaPasantiasElemento>(Properties.UdlaListDefinitions.Default.Lista_Pasantias);
                                var itemBase = MappeoMoss(item);
                                pasantias.InsertOnSubmit(itemBase);
                                context.SubmitChanges();
                                itemBase.Accion = string.Format(itemBase.Accion, itemBase.Identificador);
                                itemBase.Título = string.Format(itemBase.Título, itemBase.Identificador);
                                context.SubmitChanges();

                                auxId = itemBase.Identificador;
                                result = true;
                            }
                        }
                    }
                }
                  );
            }
            catch (Exception ex)
            {
                auxId = 0;
                Logger.ExLogger(ex);
                throw ex;
            }
            id = auxId;
            return result;
        }

        public PasantiasPreProfesionales Actualizar(PasantiasPreProfesionales item)
        {
            string strUrl = Properties.UdlaListDefinitions.Default.Url_Sitio;
            ListaPasantiasElemento pasantiasBase = null;
            PasantiasPreProfesionales pasantiaFinal = null;
            HttpContext backupCtxt = HttpContext.Current;
            try
            {

                if (SPContext.Current != null)
                    HttpContext.Current = null;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite oSite = new SPSite(strUrl))
                    {
                        using (SPWeb oWeb = oSite.OpenWeb())
                        {

                            HttpRequest httpRequest = new HttpRequest("", oWeb.Url, "");
                            HttpContext.Current = new HttpContext(httpRequest, new HttpResponse(new System.IO.StringWriter()));
                            SPControl.SetContextWeb(HttpContext.Current, oWeb);
                            using (UdlaEntityDataContext context = new UdlaEntityDataContext(oWeb.Url))
                            {
                                EntityList<ListaPasantiasElemento> pasantias = context.GetList<ListaPasantiasElemento>(Properties.UdlaListDefinitions.Default.Lista_Pasantias);
                                pasantiasBase = pasantias.Where(x => x.Identificador == item.Id).Take(1).ToList().First(); ;
                                if (pasantiasBase != null)
                                {
                                    pasantiasBase = MappeoMoss(item, pasantiasBase);
                                    context.SubmitChanges();
                                    pasantiaFinal = MappeoMoss(pasantiasBase);

                                }


                            }
                        }
                    }
                }
                  );
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
                throw ex;
            }
            return pasantiaFinal;
        }

        public  PasantiasPreProfesionales Seleccionar(PasantiasPreProfesionales item)
        {
            try
            {
                using (UdlaEntityDataContext context = new UdlaEntityDataContext(Properties.UdlaListDefinitions.Default.Url_Sitio))
                {
                    EntityList<ListaPasantiasElemento> pasantias = context.GetList<ListaPasantiasElemento>(Properties.UdlaListDefinitions.Default.Lista_Pasantias);
                    var pasantiasBase = pasantias.Where(x => x.Identificador == item.Id).Take(1).ToList().First(); ;
                    if (pasantiasBase != null)
                    {
                        return MappeoMoss(pasantiasBase);
                    }
                }
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
                throw ex;
            }
            return null;
        }

        public  PasantiasPreProfesionales SeleccionarPorId(int id)
        {
            try
            {
                using (UdlaEntityDataContext context = new UdlaEntityDataContext(Properties.UdlaListDefinitions.Default.Url_Sitio))
                {
                    EntityList<ListaPasantiasElemento> pasantias = context.GetList<ListaPasantiasElemento>(Properties.UdlaListDefinitions.Default.Lista_Pasantias);
                    var pasantiasBase = pasantias.Where(x => x.Identificador == id).Take(1).ToList().First(); ;
                    if (pasantiasBase != null)
                    {
                        return MappeoMoss(pasantiasBase);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
                throw ex;
            }
            return null;
        }

        public List<PasantiasPreProfesionales> SeleccionarAlumnosParaEmpresa(string estado)
        {
            try
            {
                using (UdlaEntityDataContext context = new UdlaEntityDataContext(Properties.UdlaListDefinitions.Default.Url_Sitio))
                {
                    EntityList<ListaPasantiasElemento> pasantias = context.GetList<ListaPasantiasElemento>(Properties.UdlaListDefinitions.Default.Lista_Pasantias);
                    List<ListaPasantiasElemento> data = new List<ListaPasantiasElemento>();
                    data = pasantias.Where(x => x.Estado == estado &&
                        ( x.SupervisorDeEmpresaIdentificador == SPContext.Current.Web.CurrentUser.ID)).ToList();
                    if (data != null)
                    {
                        List<PasantiasPreProfesionales> pasantiasItems= new List<PasantiasPreProfesionales>();
                        data.ForEach(x => pasantiasItems.Add(MappeoMoss(x)));
                        return pasantiasItems;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
                throw ex;
            }
            return null;
        }

        public List<PasantiasPreProfesionales> SeleccionarPasantiasActivas()
        {
            try
            {
                using (UdlaEntityDataContext context = new UdlaEntityDataContext(Properties.UdlaListDefinitions.Default.Url_Proceso))
                {
                    EntityList<ListaPasantiasElemento> pasantias = context.GetList<ListaPasantiasElemento>(Properties.UdlaListDefinitions.Default.Lista_Pasantias);
                    List<ListaPasantiasElemento> data = new List<ListaPasantiasElemento>();
                    data = pasantias.Where(x => x.Estado != Constants.Properties.Flujo.Default.CANCELADO &&
                                                x.Estado != Constants.Properties.Flujo.Default.FINALIZACION).ToList();
                    if (data != null)
                    {
                        List<PasantiasPreProfesionales> pasantiasItems = new List<PasantiasPreProfesionales>();
                        data.ForEach(x => pasantiasItems.Add(MappeoMoss(x)));
                        return pasantiasItems;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
                throw ex;
            }
            return null;
        }

        public List<PasantiasPreProfesionales> SeleccionarPasantiasConProblemaSAES(int startRowIndex, int maximumRows, string estado, out int itemsCount)
        {
            try
            {
                using (UdlaEntityDataContext context = new UdlaEntityDataContext(Properties.UdlaListDefinitions.Default.Url_Proceso))
                {
                    EntityList<ListaPasantiasElemento> pasantias = context.GetList<ListaPasantiasElemento>(Properties.UdlaListDefinitions.Default.Lista_Pasantias);
                    List<ListaPasantiasElemento> itemsData = new List<ListaPasantiasElemento>();
                    itemsData = pasantias.Where(x => x.Estado !=  Constants.Properties.Flujo.Default.CANCELADO &&
                                                x.Estado != Constants.Properties.Flujo.Default.FINALIZACION &&
                                                x.ProblemaEnElSistemaSAES == true).ToList();

                    itemsCount = itemsData.Count;
                    var data = itemsData.Skip(startRowIndex * maximumRows).Take(maximumRows);

                    if (data != null)
                    {
                        List<PasantiasPreProfesionales> pasantiasItems = new List<PasantiasPreProfesionales>();
                        data.ToList().ForEach(x => pasantiasItems.Add(MappeoMoss(x)));
                        return pasantiasItems;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
                throw ex;
            }
            return null;
        }

        public  ListaPasantiasElemento MappeoMoss(PasantiasPreProfesionales item)
        {
            ListaPasantiasElemento itemBase = new ListaPasantiasElemento();
            return MappeoMoss( item,itemBase);
       
        }


        public PasantiasPreProfesionales MappeoMoss(ListaPasantiasElemento item)
        {
            var itemBase = new PasantiasPreProfesionales();

            
            return MappeoOrigen(item,itemBase);
        }

        public  ListaPasantiasElemento MappeoMoss(PasantiasPreProfesionales item, ListaPasantiasElemento itemBase)
        {
            itemBase.AceptoConvenio = item.AceptoConvenio;
            itemBase.AlumnoIdentificador = item.AlumnoIdentificador;
            itemBase.AlumnoImnName = item.AlumnoImnName;
            itemBase.AreaDeTrabajo = item.AreaTrabajo;
            itemBase.Cargo = item.Cargo;
            itemBase.Carrera = item.Carrera;
            itemBase.DocenteIdentificador = item.DocenteIdentificador;
            itemBase.DocenteImnName = item.DocenteImnName;
            itemBase.EmailSupervisor = item.EmailSupervisor;
            itemBase.Empresa = item.Empresa;
            itemBase.EsSeleccionado = item.EsSeleccionado;
            itemBase.Estado = item.Estado;
            itemBase.EvaluoAlumno = item.EvaluoAlumno;
            itemBase.EvaluoEmpresa = item.EvaluoEmpresa;
            itemBase.FechaInicio = item.FechaInicio;
            itemBase.FechaFin = item.FechaFin;
            itemBase.FinDePractica = item.FinPractica;
            itemBase.FechaInicioProceso = item.FechaInicioProceso;
            itemBase.Funciones = item.Funciones;
            if (item.HorarioTrabajo.HasValue)
            itemBase.HorarioDeTrabajo = (HorarioDeTrabajo)item.HorarioTrabajo;
            itemBase.HorasAprobadasPorEmpresa = item.HorasAprobadasPorEmpresa;
            itemBase.Identificador = item.Id;
            itemBase.IdEmpresa = item.IdEmpresa;
            itemBase.Identificacion = item.CedulaIdentidad;
            itemBase.Materia = item.Materia;
            itemBase.Matricula = item.Matricula;
            itemBase.NombreAlumnoSAES = item.NombreSaes;
            itemBase.NombreAlumno = item.NombreAlumno;
            itemBase.ApellidoAlumno = item.ApellidoAlumno;
            itemBase.NumeroDeHorasEjecutadas = item.NumeroHorasEjecutadas;
            itemBase.NombreSupervisor = item.NombreSupervisor;
            itemBase.SupervisorDeEmpresaIdentificador = item.SupervisorDeEmpresaIdentificador;
            itemBase.SupervisorDeEmpresaImnName = item.SupervisorDeEmpresaImnName;
            itemBase.TelefonoSupervisor = item.TelefonoSupervisor;
            itemBase.TipoPasantia = item.TipoPasantiaEnum;
            itemBase.TutorIdentificador = item.TutorIdentificador;
            itemBase.TutorImnName = item.TutorImnName;
            itemBase.ObservacionesDeRegistroDeHorasSAES = item.ObservacionesDeRegistroDeHorasSAES;
            itemBase.GenerarCartaCompromiso = item.GenerarCartaCompromiso;
            itemBase.GenerarCartaCompromiso = item.GenerarCartaCompromiso;
            itemBase.FechaDelProblema = item.FechaDelProblema;
            itemBase.HorasAprobadasTutor = item.HorasAprobadasTutor;
            itemBase.FechaAprobacionTutor = item.FechaAprobacionTutor;
            itemBase.FechaAprobacionEmpresa = item.FechaAprobacionEmpresa;
            itemBase.FechaAprobacionSupervisor = item.FechaAprobacionSupervisor;
            itemBase.AprobacionTutorIngresoHorasSAES = item.AprobacionTutorIngresoHorasSAES;
            itemBase.FichaDeInscripcionAprobadaPorTutor = item.FichaDeInscripcionAprobadaPorTutor;
            itemBase.FichaDeInscripcionAprobadaPorEmpresa = item.FichaDeInscripcionAprobadaPorEmpresa;
            itemBase.AprobadoPorTutorParaRegistroEnSAES = item.AprobadoPorTutorParaRegistroEnSAES;
            itemBase.HorasRevisadasTutor = item.HorasRevisadasTutor;
            itemBase.FechaFinalizacionTutor = item.FechaFinalizacionTutor;
            itemBase.Nivel = item.Nivel;
            itemBase.CodigoCarrera = item.CodigoCarrera;
            itemBase.CodigoDeMateria = item.CodigoDeMateria;
            itemBase.HorasIngresadasSAES = item.HorasIngresadasSAES;
            itemBase.FechaDeIngresoEnElSistemaSAES = item.FechaDeIngresoEnElSistemaSAES;
            itemBase.CreacionDeCartaDeCompromiso = item.CreacionDeCartaDeCompromiso;
            itemBase.HorasActualesEnElSistemaSAES = item.HorasActualesEnElSistemaSAES;
            itemBase.EsSeleccionadoPorDocente = item.EsSeleccionadoPorDocente;
            itemBase.Accion = item.Accion;
            itemBase.Título = item.Titulo;
            itemBase.NombreTutorSAES = item.NombreTutorSAES;
            itemBase.NombreDocenteSAES = item.NombreDocenteSAES;
            itemBase.EmailAlumno = item.EmailAlumno;
            itemBase.EsOfertaLaboral = item.EsOfertaLaboral;
            itemBase.TelefonoAlumno = item.TelefonoAlumno;
            itemBase.PlanAlumno = item.PlanAlumno;
            itemBase.CodigoEspecialidad = item.CodigoEspecialidad;
            itemBase.Materia = item.Materia;
            itemBase.TelefonoCelularAlumno = item.TelefonoCelularAlumno;
            itemBase.DireccionDeAlumno = item.DireccionAlumno;
            itemBase.SexoAlumno = item.SexoAlumno;
            itemBase.CiudadDeNacimientoDelAlumno = item.CiudadNacimientoAlumno;
            itemBase.EstadoCivilAlumno = item.EstadoCivilAlumno;
            itemBase.IDOfertaLabora = item.IDOfertaLaboral    ;
            itemBase.PERID = item.PERID;
            itemBase.FechaDeNacimientoAlumno = item.FechaNacimientoAlumno;
            itemBase.IdentificacionDocente = item.CedulaDocente;
            itemBase.IdentificacionTutor = item.CedulaTutor;
            itemBase.MaximoHorasMateria = item.MaximoHorasMateria;
            itemBase.FechaFinProcesoPractica = item.FechaFinProcesoPractica;
            itemBase.ProblemaEnElSistemaSAES = item.ProblemaEnElSistemaSAES;
            itemBase.TelefonoEmpresa = item.TelefonoEmpresa;
            itemBase.DireccionEmpresa = item.DireccionEmpresa;
            itemBase.MotivoCancelacion = item.ObservacionError;
            return itemBase;
        }

        public PasantiasPreProfesionales MappeoOrigen(ListaPasantiasElemento item, PasantiasPreProfesionales itemBase)
        {
            itemBase.AceptoConvenio = item.AceptoConvenio;
            itemBase.AlumnoIdentificador = item.AlumnoIdentificador;
            itemBase.AlumnoImnName = item.AlumnoImnName;
            itemBase.AreaTrabajo = item.AreaDeTrabajo;
            itemBase.Cargo = item.Cargo;
            itemBase.Carrera = item.Carrera;
            itemBase.DocenteIdentificador = item.DocenteIdentificador;
            itemBase.DocenteImnName = item.DocenteImnName;
            itemBase.EmailSupervisor = item.EmailSupervisor;
            itemBase.Empresa = item.Empresa;
            itemBase.EsSeleccionado = item.EsSeleccionado;
            itemBase.Estado = item.Estado;
            itemBase.EvaluoAlumno = item.EvaluoAlumno;
            itemBase.EvaluoEmpresa = item.EvaluoEmpresa;
            itemBase.FechaInicio = item.FechaInicio;
            itemBase.FechaFin = item.FechaFin;
            itemBase.FinPractica = item.FinDePractica;
            itemBase.FechaInicioProceso = item.FechaInicioProceso;
            itemBase.Funciones = item.Funciones;
            if (item.HorarioDeTrabajo.HasValue)
                itemBase.HorarioTrabajo = (HorarioTrabajo)item.HorarioDeTrabajo;
            itemBase.HorasAprobadasPorEmpresa = item.HorasAprobadasPorEmpresa;
            itemBase.Id = item.Identificador;
            itemBase.IdEmpresa = item.IdEmpresa;
            itemBase.CedulaIdentidad = item.Identificacion;
            itemBase.Materia = item.Materia;
            itemBase.Matricula = item.Matricula;
            itemBase.NombreSaes = item.NombreAlumnoSAES;
            itemBase.NombreAlumno = item.NombreAlumno;
            itemBase.ApellidoAlumno = item.ApellidoAlumno;
            itemBase.NumeroHorasEjecutadas = item.NumeroDeHorasEjecutadas;
            itemBase.NombreSupervisor = item.NombreSupervisor;
            itemBase.SupervisorDeEmpresaIdentificador = item.SupervisorDeEmpresaIdentificador;
            itemBase.SupervisorDeEmpresaImnName = item.SupervisorDeEmpresaImnName;
            itemBase.TelefonoSupervisor = item.TelefonoSupervisor;
            itemBase.TipoPasantiaEnum = item.TipoPasantia;
            itemBase.TutorIdentificador = item.TutorIdentificador;
            itemBase.TutorImnName = item.TutorImnName;
            itemBase.ObservacionesDeRegistroDeHorasSAES = item.ObservacionesDeRegistroDeHorasSAES;
            itemBase.GenerarCartaCompromiso = item.GenerarCartaCompromiso;
            itemBase.GenerarCartaCompromiso = item.GenerarCartaCompromiso;
            itemBase.FechaDelProblema = item.FechaDelProblema;
            itemBase.HorasAprobadasTutor = item.HorasAprobadasTutor;
            itemBase.FechaAprobacionTutor = item.FechaAprobacionTutor;
            itemBase.FechaAprobacionEmpresa = item.FechaAprobacionEmpresa;
            itemBase.FechaAprobacionSupervisor = item.FechaAprobacionSupervisor;
            itemBase.AprobacionTutorIngresoHorasSAES = item.AprobacionTutorIngresoHorasSAES;
            itemBase.FichaDeInscripcionAprobadaPorTutor = item.FichaDeInscripcionAprobadaPorTutor;
            itemBase.FichaDeInscripcionAprobadaPorEmpresa = item.FichaDeInscripcionAprobadaPorEmpresa;
            itemBase.AprobadoPorTutorParaRegistroEnSAES = item.AprobadoPorTutorParaRegistroEnSAES;
            itemBase.HorasRevisadasTutor = item.HorasRevisadasTutor;
            itemBase.FechaFinalizacionTutor = item.FechaFinalizacionTutor;
            itemBase.Nivel = item.Nivel;
            itemBase.CodigoCarrera = item.CodigoCarrera;
            itemBase.CodigoDeMateria = item.CodigoDeMateria;
            itemBase.HorasIngresadasSAES = item.HorasIngresadasSAES;
            itemBase.FechaDeIngresoEnElSistemaSAES = item.FechaDeIngresoEnElSistemaSAES;
            itemBase.CreacionDeCartaDeCompromiso = item.CreacionDeCartaDeCompromiso;
            itemBase.HorasActualesEnElSistemaSAES = item.HorasActualesEnElSistemaSAES;
            itemBase.EsSeleccionadoPorDocente = item.EsSeleccionadoPorDocente;
            itemBase.Accion = item.Accion;
            itemBase.Titulo = item.Título;
            itemBase.NombreTutorSAES = item.NombreTutorSAES;
            itemBase.NombreDocenteSAES = item.NombreDocenteSAES;
            itemBase.EmailAlumno = item.EmailAlumno;
            itemBase.EsOfertaLaboral = item.EsOfertaLaboral;
            itemBase.TelefonoAlumno = item.TelefonoAlumno;
            itemBase.PlanAlumno = item.PlanAlumno;
            itemBase.CodigoEspecialidad = item.CodigoEspecialidad;
            itemBase.TelefonoCelularAlumno = item.TelefonoCelularAlumno;
            itemBase.DireccionAlumno = item.DireccionDeAlumno;
            itemBase.SexoAlumno = item.SexoAlumno;
            itemBase.CiudadNacimientoAlumno = item.CiudadDeNacimientoDelAlumno;
            itemBase.FechaNacimientoAlumno = item.FechaDeNacimientoAlumno;
            itemBase.EstadoCivilAlumno = item.EstadoCivilAlumno;
            itemBase.IDOfertaLaboral = item.IDOfertaLabora;
            itemBase.PERID = item.PERID;
            itemBase.CedulaDocente = item.IdentificacionDocente;
            itemBase.CedulaTutor = item.IdentificacionTutor;
            itemBase.MaximoHorasMateria = item.MaximoHorasMateria;
            itemBase.FechaFinProcesoPractica = item.FechaFinProcesoPractica;
            itemBase.ProblemaEnElSistemaSAES = item.ProblemaEnElSistemaSAES;
            itemBase.ObservacionError = item.MotivoCancelacion;
            itemBase.Url = item.RutaDeAcceso;
            itemBase.TelefonoEmpresa = item.TelefonoEmpresa;
            itemBase.DireccionEmpresa = item.DireccionEmpresa;
            return itemBase;
        }

        ListaPasantiasElemento MappeoMossEstado(string estado, ListaPasantiasElemento itemBase)
        {
            itemBase.Estado = estado.ToUpper();
            return itemBase;
        }
        public bool CambiarEstado(int id, string estado)
        {


            string strUrl = Properties.UdlaListDefinitions.Default.Url_Sitio;
            bool val = false;
            HttpContext backupCtxt = HttpContext.Current;
            try
            {

                if (SPContext.Current != null)
                    HttpContext.Current = null;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite oSite = new SPSite(strUrl))
                    {
                        using (SPWeb oWeb = oSite.OpenWeb())
                        {

                            HttpRequest httpRequest = new HttpRequest("", oWeb.Url, "");
                            HttpContext.Current = new HttpContext(httpRequest, new HttpResponse(new System.IO.StringWriter()));
                            SPControl.SetContextWeb(HttpContext.Current, oWeb);
                            using (UdlaEntityDataContext context = new UdlaEntityDataContext(oWeb.Url))
                            {
                                var pasantiasBase = context.ListaPasantias.Where(x => x.Identificador == id).Take(1).ToList().First(); ;
                                if (pasantiasBase != null)
                                {
                                    pasantiasBase = MappeoMossEstado(estado, pasantiasBase);
                                    context.SubmitChanges();
                                    val= true;
                                }
                            }
                        }
                    }
                }
                  );
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
                throw ex;
            }
            return val;
        }

        public List<PasantiasPreProfesionales> SeleccionarAlumnosParaEmpresa(int startRowIndex, int maximumRows, string estado, out int itemsCount)
        {
            itemsCount = 0;

            using (UdlaEntityDataContext context = new UdlaEntityDataContext(Properties.UdlaListDefinitions.Default.Url_Sitio))
            {
                EntityList<ListaPasantiasElemento> pasantias = context.GetList<ListaPasantiasElemento>(Properties.UdlaListDefinitions.Default.Lista_Pasantias);
                var itemsData = pasantias.Where(x => x.SupervisorDeEmpresaIdentificador == SPContext.Current.Web.CurrentUser.ID && x.Estado==estado);
                itemsCount = itemsData.Count();
                var data = itemsData.Skip(startRowIndex * maximumRows).Take(maximumRows);
               
                
                if (data != null)
                {
                    List<PasantiasPreProfesionales> pasantiasItems = new List<PasantiasPreProfesionales>();
                    data.ToList().ForEach(x => pasantiasItems.Add(MappeoMoss(x)));
                    return pasantiasItems;
                }
            }
            return null;
        }

        public List<PasantiasPreProfesionales> SeleccionarAlumnosParaDocente(int startRowIndex, int maximumRows, string estado, out int itemsCount)
        {
            itemsCount = 0;

            using (UdlaEntityDataContext context = new UdlaEntityDataContext(Properties.UdlaListDefinitions.Default.Url_Sitio))
            {
                EntityList<ListaPasantiasElemento> pasantias = context.GetList<ListaPasantiasElemento>(Properties.UdlaListDefinitions.Default.Lista_Pasantias);
                var itemsData = pasantias.Where(x => x.DocenteIdentificador == SPContext.Current.Web.CurrentUser.ID && x.Estado == estado);
                itemsCount = itemsData.Count();
                var data = itemsData.Skip(startRowIndex * maximumRows).Take(maximumRows);


                if (data != null)
                {
                    List<PasantiasPreProfesionales> pasantiasItems = new List<PasantiasPreProfesionales>();
                    data.ToList().ForEach(x => pasantiasItems.Add(MappeoMoss(x)));
                    return pasantiasItems;
                }
            }
            return null;
        }

        public List<PasantiasPreProfesionales> SeleccionarPreCancelados(int startRowIndex, int maximumRows,  out int itemsCount,string cancelado)
        {
            itemsCount = 0;

            using (UdlaEntityDataContext context = new UdlaEntityDataContext(Properties.UdlaListDefinitions.Default.Url_Sitio))
            {
                EntityList<ListaPasantiasElemento> pasantias = context.GetList<ListaPasantiasElemento>(Properties.UdlaListDefinitions.Default.Lista_Pasantias);
                var itemsData = pasantias.Where(x => x.ProblemaEnElSistemaSAES==true && x.Estado != cancelado );
                itemsCount = itemsData.Count();
                var data = itemsData.Skip(startRowIndex * maximumRows).Take(maximumRows);
                if (data != null)
                {
                    List<PasantiasPreProfesionales> pasantiasItems = new List<PasantiasPreProfesionales>();
                    data.ToList().ForEach(x => pasantiasItems.Add(MappeoMoss(x)));
                    return pasantiasItems;
                }
            }
            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="estado"></param>
        /// <param name="esSeleccionado"></param>
        /// <returns></returns>
        public bool CambiarEstadoSeleccionadoAlumnoEmpresa(int id, string estado, bool esSeleccionado)
        {
            string strUrl = Properties.UdlaListDefinitions.Default.Url_Sitio;
            bool val = false ;
            HttpContext backupCtxt = HttpContext.Current;
            try
            {

                if (SPContext.Current != null)
                    HttpContext.Current = null;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite oSite = new SPSite(strUrl))
                    {
                        using (SPWeb oWeb = oSite.OpenWeb())
                        {

                            HttpRequest httpRequest = new HttpRequest("", oWeb.Url, "");
                            HttpContext.Current = new HttpContext(httpRequest, new HttpResponse(new System.IO.StringWriter()));
                            SPControl.SetContextWeb(HttpContext.Current, oWeb);
                            using (UdlaEntityDataContext context = new UdlaEntityDataContext(oWeb.Url))
                            {
                                var pasantiasBase = context.ListaPasantias.Where(x => x.Identificador == id).Take(1).ToList().First(); ;
                                if (pasantiasBase != null)
                                {
                                    pasantiasBase.EsSeleccionado = esSeleccionado;
                                    pasantiasBase.Estado = estado;
                                    context.SubmitChanges();
                                    val = true;
                                }
                            }
                        }
                    }
                }
                  );
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
                throw ex;
            }
            return val;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="estado"></param>
        /// <param name="esSeleccionado"></param>
        /// <returns></returns>
        public bool CambiarEstadoSeleccionadoAlumnoDocente(int id, string estado, bool esSeleccionado)
        {

            string strUrl = Properties.UdlaListDefinitions.Default.Url_Sitio;
            bool val = false;
            HttpContext backupCtxt = HttpContext.Current;
            try
            {

                if (SPContext.Current != null)
                    HttpContext.Current = null;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite oSite = new SPSite(strUrl))
                    {
                        using (SPWeb oWeb = oSite.OpenWeb())
                        {

                            HttpRequest httpRequest = new HttpRequest("", oWeb.Url, "");
                            HttpContext.Current = new HttpContext(httpRequest, new HttpResponse(new System.IO.StringWriter()));
                            SPControl.SetContextWeb(HttpContext.Current, oWeb);
                            using (UdlaEntityDataContext context = new UdlaEntityDataContext(oWeb.Url))
                            {
                                var pasantiasBase = context.ListaPasantias.Where(x => x.Identificador == id).Take(1).ToList().First(); ;
                                if (pasantiasBase != null)
                                {
                                    pasantiasBase.EsSeleccionadoPorDocente = esSeleccionado;
                                    pasantiasBase.EsSeleccionado = esSeleccionado;
                                    pasantiasBase.Estado = estado;
                                    context.SubmitChanges();
                                    val= true;
                                }
                            }
                        }
                    }
                }
                  );
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
                throw ex;
            }
            return val;
        }
        public string GetEstado(int id)
        {
            try
            {
                using (UdlaEntityDataContext context = new UdlaEntityDataContext(Properties.UdlaListDefinitions.Default.Url_Sitio))
                {
                    EntityList<ListaPasantiasElemento> pasantias = context.GetList<ListaPasantiasElemento>(Properties.UdlaListDefinitions.Default.Lista_Pasantias);
                    var pasantiasBase = context.ListaPasantias.Where(x => x.Identificador == id).Take(1).ToList().First(); ;
                    if (pasantiasBase != null)
                        return pasantiasBase.Estado;
                }
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
                throw ex;
            }
            return string.Empty;
        }

    }
}
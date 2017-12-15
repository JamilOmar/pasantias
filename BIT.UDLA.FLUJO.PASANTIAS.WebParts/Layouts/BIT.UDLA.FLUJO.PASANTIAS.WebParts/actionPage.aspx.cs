using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using System.Linq;
namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.Layouts.BIT.UDLA.FLUJO.PASANTIAS.WebParts
{
    public partial class actionPage : LayoutsPageBase
    {
        PasantiasPreprofesionalesLogic pasantiasLogic = new PasantiasPreprofesionalesLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = GetPasantiaQueryString();
            if (id.HasValue)
            {
                var item = pasantiasLogic.SeleccionarPorId(id.Value);
                if(item!=null)
                Tipo(item);
            }
        }

        public void Ira(string url, int? id)
        {
            if (id.HasValue)
            {


                Response.Redirect(FormUrl(url) + "?IdPasantia=" + id.Value.ToString());
            }
            else
            {
                Response.Redirect(FormUrl(url));
            }
        }
        public string FormUrl(string url)
        {
            return string.Format("~/{0}", url);
        }
        public int? GetPasantiaQueryString()
        {
            var result = (Request["idpasantia"] != null) ? Request["idpasantia"] : string.Empty;
           
            if (!string.IsNullOrEmpty(result))
            {
               
                int id = 0;
                if (int.TryParse(result, out id))
                {
                    return id;
                }
            }
            return null;

        }



        void Tipo(PasantiasPreProfesionales pasantia)
        {
            SeleccionComun(pasantia.Estado, pasantia.Id.Value,pasantia);
            switch (pasantia.TipoPasantiaEnum)
            {

                case FLUJOS.PASANTIAS.Constants.FlujoConstantes.CON_TRABAJO:
                    Contrabajo(pasantia.Estado, pasantia.Id.Value,pasantia);
                    break;
                case FLUJOS.PASANTIAS.Constants.FlujoConstantes.CON_SUPERVISION:
                    ConSupervision(pasantia.Estado, pasantia.Id.Value,pasantia);
                    break;
                case FLUJOS.PASANTIAS.Constants.FlujoConstantes.SIN_SUPERVISION:
                    SinSupervision(pasantia.Estado, pasantia.Id.Value,pasantia);
                    break;
                default:
               
                    break;

            }
            Ira(Properties.Pages.Default.EnProceso, pasantia.Id.Value);
        
        }

        void SeleccionComun(string estado, int id,PasantiasPreProfesionales pasantia )
        {
            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.INICIO))
            {
                Ira(Properties.Pages.Default.SeleccionPractica, id);

            }
            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.FINALIZACION))
            {
                Ira(Properties.Pages.Default.Finalizada, id);

            }
            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.CANCELADO))
            {
                Ira(Properties.Pages.Default.Finalizada, id);

            }
            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.SELECCION_PRACTICA))
            {
                Ira(Properties.Pages.Default.HojaDeVida, id);

            }
            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.ACTUALIZACION_HOJA_DE_VIDA))
            {
     
                 Ira(Properties.Pages.Default.Empresas, id);

            }
        }
        void Contrabajo(string estado, int id,PasantiasPreProfesionales pasantia )
        {
            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.SELECCION_USUARIO_EMPRESA))
            {
                Ira(Properties.Pages.Default.SeleccionUsuarioEmpresa, id);
            }
            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.ASIGNACION_EMPRESA))
            {
                Ira(Properties.Pages.Default.FichaRegistroEmpresa, id);
            }
            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.REGISTRO_TUTOR))
            {
                if (pasantia.EvaluoAlumno.HasValue && pasantia.EvaluoEmpresa.HasValue
                     && pasantia.EvaluoEmpresa.Value && pasantia.EvaluoAlumno.HasValue)
                {
                    Ira(Properties.Pages.Default.EvaluacionFinal, id);
                }
                if  (pasantia.AlumnoIdentificador == SPContext.Current.Web.CurrentUser.ID)
                {
                    Ira(Properties.Pages.Default.EvaluacionEmpresa, id);

                }
                if (pasantia.SupervisorDeEmpresaIdentificador == SPContext.Current.Web.CurrentUser.ID)
                {
                    Ira(Properties.Pages.Default.EvaluacionEstudiante, id);
                }
            }
          
        }

        void SinSupervision(string estado, int id, PasantiasPreProfesionales pasantia)
        {

            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.SELECCION_USUARIO_EMPRESA))
            {
                Ira(Properties.Pages.Default.SeleccionUsuarioEmpresa, id);
            }
            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.ACEPTACION_ESTUDIANTE_EMPRESA))
            {
                Ira(Properties.Pages.Default.SeleccionAlumnosEmpresa, id);
            }
            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.ASIGNACION_EMPRESA))
            {
                Ira(Properties.Pages.Default.FichaRegistroEmpresa, id);
            }
            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.REVISION_TUTOR))
            {
                Ira(Properties.Pages.Default.FichaRegistroTutor, id);
            }
            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.CONFIRMACION_EMPRESA))
            {
                Ira(Properties.Pages.Default.FichaRegistroConfirmacionEmpresa, id);
            }

            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.REGISTRO_TUTOR))
            {
                if (pasantia.EvaluoAlumno.HasValue && pasantia.EvaluoEmpresa.HasValue
                     && pasantia.EvaluoEmpresa.Value && pasantia.EvaluoAlumno.HasValue)
                {
                    Ira(Properties.Pages.Default.EvaluacionFinal, id);
                }
                if (pasantia.AlumnoIdentificador == SPContext.Current.Web.CurrentUser.ID)
                {
                    Ira(Properties.Pages.Default.EvaluacionEmpresa, id);

                }
                if (pasantia.SupervisorDeEmpresaIdentificador == SPContext.Current.Web.CurrentUser.ID)
                {
                    Ira(Properties.Pages.Default.EvaluacionEstudiante, id);
                }
            }
        }
        void ConSupervision(string estado, int id, PasantiasPreProfesionales pasantia)
        {

            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.SELECCION_MATERIA))
            {
                Ira(Properties.Pages.Default.SeleccionMateria, id);
            }

            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.SELECCION_USUARIO_DOCENTE))
            {
                Ira(Properties.Pages.Default.SeleccionAlumnosDocente, id);
            }
            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.SELECCION_USUARIO_EMPRESA))
            {
                Ira(Properties.Pages.Default.SeleccionUsuarioEmpresa, id);
            }
            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.ACEPTACION_ESTUDIANTE_EMPRESA))
            {
                Ira(Properties.Pages.Default.SeleccionAlumnosEmpresa, id);
            }

            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.ASIGNACION_EMPRESA))
            {
                Ira(Properties.Pages.Default.FichaRegistroEmpresa, id);
            }

            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.REVISION_TUTOR))
            {
                Ira(Properties.Pages.Default.FichaRegistroTutor, id);
            }
            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.CONFIRMACION_EMPRESA))
            {
                if (pasantia.AlumnoIdentificador == SPContext.Current.Web.CurrentUser.ID)
                {
                    Ira(Properties.Pages.Default.ConSupervision, id);

                }
                else
                    if (pasantia.DocenteIdentificador == SPContext.Current.Web.CurrentUser.ID)
                    {
                        Ira(Properties.Pages.Default.ConSupervision, id);

                    }
                    else
                        Ira(Properties.Pages.Default.RouterPagina, id);
            }
            if (estado.Equals(global::BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.REGISTRO_TUTOR))
            {
                if (pasantia.EvaluoAlumno.HasValue && pasantia.EvaluoEmpresa.HasValue
                     && pasantia.EvaluoEmpresa.Value && pasantia.EvaluoAlumno.HasValue)
                {
                    Ira(Properties.Pages.Default.EvaluacionFinal, id);
                }
                if (pasantia.AlumnoIdentificador == SPContext.Current.Web.CurrentUser.ID)
                {
                    Ira(Properties.Pages.Default.EvaluacionEmpresa, id);

                }
                if (pasantia.SupervisorDeEmpresaIdentificador == SPContext.Current.Web.CurrentUser.ID)
                {
                    Ira(Properties.Pages.Default.EvaluacionEstudiante, id);
                }
            }
        }

    }
}

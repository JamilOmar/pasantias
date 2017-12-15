using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using Microsoft.SharePoint;
using System.Web.UI.WebControls.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using Microsoft.SharePoint.Utilities;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts
{
    public abstract class wpUsrControl:UserControl
    {
        public PasantiasPreprofesionalesLogic pasantiasLogic = new PasantiasPreprofesionalesLogic();
        public PasantiasPreProfesionales itemPasantias
        {
            set
            {
                ViewState["itemPasantias"] = value;
            }
            get
            {
                return (PasantiasPreProfesionales)ViewState["itemPasantias"];
            }

        } 
     
        protected override void OnLoad(EventArgs e)
        {
             
                base.OnLoad(e);
                if (!PaginaRecargada)
                    PaginaRecargada = true;
        }
        public bool PaginaRecargada
        {
            set
            {
                ViewState["PaginaRecargada"] = value;
            }
            get
            {
                return ViewState["PaginaRecargada"] == null ? false : Convert.ToBoolean(ViewState["PaginaRecargada"]);
            }
        }
 

        public string UserID
        {
            get
            {

                return this.Page.User.Identity.Name;
            }
        }

        public int UserMossID
        {
            get
            {

                return SPContext.Current.Web.CurrentUser.ID;
            }
        }
        public bool IsSiteAdmin
        {
            get
            {

                return SPContext.Current.Web.CurrentUser.IsSiteAdmin;
            }
        }


        public int? GetPersonaQueryString()
        {
            var result = (Request["idpersona"] != null) ? Request["idpersona"] : string.Empty;
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

        public bool? IsNewCursoQueryString()
        {
            var result = (Request["New"] != null) ? Request["New"] : string.Empty;
            if (!string.IsNullOrEmpty(result))
            {
                bool id =false;
                if (bool.TryParse(result, out id))
                {
                    return id;
                }
            }
            return null;
        }


        public int? GetCursoQueryString()
        {
            var result = (Request["idcurso"] != null) ? Request["idcurso"] : string.Empty;
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
        public int? GetDynamicQueryStringIntValue(string idQueryString)
        {
            var result = (Request[idQueryString] != null) ? Request[idQueryString] : string.Empty;
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
        public string GetDynamicQueryStringValue(string idQueryString)
        {
            var result = (Request[idQueryString] != null) ? Request[idQueryString] : string.Empty;
            if (!string.IsNullOrEmpty(result))
            {


                return result;

            }
            return null;

        }
        public bool IsNewItem()
        {
            var result = (Request["New"] != null) ? Request["New"] : string.Empty;
            if (!string.IsNullOrEmpty(result))
            {
                bool isNew = false;
                if (bool.TryParse(result, out isNew))
                {
                    return isNew;
                }
            }
            return true;

        }
        public void ValidateState(string origen, string destino)
        {
            if (origen==null &&!origen.Equals(destino))
            {
                Response.Redirect("/default.aspx");
            }
        }
        public static string ToDateTimeFormat(object date)
        {
            var dateFinal = (date as DateTime?);
            if (dateFinal.HasValue)
                return dateFinal.Value.ToShortDateString();
            else
                return string.Empty;
        }
        public void Ira(string url, int? id)
        {
            if (id.HasValue)
            {
               
              
                Response.Redirect(FormUrl(url)+ "?IdPasantia=" + id.Value.ToString(),false);
            }
            else 
            {
                Response.Redirect(FormUrl(url),false);
            }
        }
        public void Ira(string url,string parametros,bool endReponse)
        {
           


                Response.Redirect(FormUrl(url) + parametros, endReponse);
           
        }
        public string FormUrl(string url)
        {
            string urlTest = "http://" + Request.Url.Authority + "/";
            return urlTest + url;
        }
        public bool ValidarUsuario(PasantiasPreProfesionales item, bool alumno, bool docente, bool tutor, bool empresa)
        {
            int currentUserId = UserMossID;

            if (IsSiteAdmin)
                return true;
            if (alumno)
            {
                if(item.AlumnoIdentificador.HasValue)
                    return item.AlumnoIdentificador.Value == currentUserId;
            }
            if (docente)
            {
                if (item.DocenteIdentificador.HasValue)
                    return item.DocenteIdentificador.Value == currentUserId;

            }
            if (tutor)
            {
                if (item.TutorIdentificador.HasValue)
                    return item.TutorIdentificador.Value == currentUserId;
            }
            if (empresa)
            {
                if (item.SupervisorDeEmpresaIdentificador.HasValue)
                    return item.SupervisorDeEmpresaIdentificador.Value == currentUserId;
            }
            return false;
        }



        public void ManejarError(Exception ex)
        { 
            

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                //Response.Redirect(SPContext.Current.Site.Url+Properties.Pages.Default.Error);
           
        }
        public void CancelarFlujo(bool esTutor, int id,string mensaje)
        {
            var item = pasantiasLogic.SeleccionarPorId(id);
            if (esTutor)
                item.FechaFinalizacionTutor = DateTime.Now;
            item.FechaFinProcesoPractica = DateTime.Now;
            item.Estado = BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.CANCELADO;
            item.FechaDelProblema = DateTime.Now;
            item.ObservacionError = mensaje;
            pasantiasLogic.Actualizar(item);
        }
        public void CancelarFlujo(bool esTutor,string mensaje)
        {
            itemPasantias = pasantiasLogic.SeleccionarPorId(itemPasantias.Id.Value);
            if (esTutor)
                itemPasantias.FechaFinalizacionTutor = DateTime.Now;
            itemPasantias.FechaFinProcesoPractica = DateTime.Now;
            itemPasantias.Estado = BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.CANCELADO;
            itemPasantias.FechaDelProblema = DateTime.Now;
            itemPasantias.ObservacionError = mensaje;
            pasantiasLogic.Actualizar(itemPasantias);
         
        
        
        }
        public void CancelarFlujo(string descripcion)
        {
            itemPasantias = pasantiasLogic.SeleccionarPorId(itemPasantias.Id.Value);
            itemPasantias.ObservacionError = descripcion;
            itemPasantias.FechaFinProcesoPractica = DateTime.Now;
            itemPasantias.Estado = BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.CANCELADO;
            itemPasantias.FechaDelProblema = DateTime.Now;
            pasantiasLogic.Actualizar(itemPasantias);



        }
        public void ManejarErrorNoRedirect(Exception ex)
        {


            BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);

        }
      

    }
}

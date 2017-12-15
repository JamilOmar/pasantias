using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using Microsoft.SharePoint;
using System.Linq;
namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpConSupervision
{
    public partial class wpConSupervisionUserControl :wpUsrControl
    {
              
        #region Properties
		       ActividadesLogic actividadesLogic = new ActividadesLogic();
        VisitasLogic visitasLogic = new VisitasLogic();

      
        private UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrPager PaginadorActividades
        {
            get
            {
                return (usrPagerActividades as UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrPager);
            }
        }
        private UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrPager PaginadorVisitas
        {
            get
            {
                return (usrPagerVisitas as UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrPager);
            }
        }
 
	#endregion        

        #region Load

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var id = GetPasantiaQueryString();
                    if (id.HasValue)
                    {
                        itemPasantias = pasantiasLogic.SeleccionarPorId(id.Value);
                        RecargarActividades();
                        RecargarVisitas();
                        CrearLinks(); EnableItem();
                    }
                }
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }

        } 
        #endregion

        #region Methods



        void CrearLinksEmpresa()
        {
            lnkGeneral.Visible = true;
            lnkGeneral.Text = BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Mensajes.Default.TextoIrAEmpresa;
            lnkGeneral.PostBackUrl = FormUrl(Properties.Pages.Default.IrAEmpresa);
        }
        void CrearLinksDocente()
        {
            lnkGeneral.Visible = true;
            lnkGeneral.Text = BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Mensajes.Default.TextoIrADocente;
            lnkGeneral.PostBackUrl = FormUrl(Properties.Pages.Default.IrADocente);
        }

        void EnableItem()
        {
            try
            {
                var estudiante = ValidarUsuario(itemPasantias, true, false, false, false);
                var docente = ValidarUsuario(itemPasantias, false, true, false, false);
                var tutor = ValidarUsuario(itemPasantias, false, false, true, false);
                var empresa = ValidarUsuario(itemPasantias, false, false, false, true);
                hlNuevaAsistencia.Visible = estudiante;
                if (estudiante || empresa)
                {

                    trVisitasGrid.Visible = false;
                    trVisitasInsert.Visible = false;
                    if (empresa)
                        CrearLinksEmpresa();

                }
                else
                    if (docente)
                    {
                        trVisitasGrid.Visible = true;
                        trVisitasInsert.Visible = true;
                        CrearLinksDocente();
                    }
                    else
                        if (tutor)
                        {
                            trAsistenciaInsert.Visible = false;
                            trVisitasGrid.Visible = true;
                            trVisitasInsert.Visible = false;

                        }
                titulo.Visible = trVisitasGrid.Visible;

            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }


        }
        public void CrearLinks()
        {
            try
            {
                this.hlNuevaAsistencia.Attributes.Add("onClick", string.Format("javascript:OpenDialog('{0}','{1}' );", string.Format("{0}?IdPasantia={1}", FormUrl(Properties.Pages.Default.RegistroActividades), itemPasantias.Id), FormUrl(Properties.Pages.Default.ConSupervision) + "?IdPasantia=" + itemPasantias.Id.ToString()));
                this.hlNuevaVisita.Attributes.Add("onClick", string.Format("javascript:OpenDialog('{0}','{1}');", string.Format("{0}?IdPasantia={1}", FormUrl(Properties.Pages.Default.RegistroVisitas), itemPasantias.Id), FormUrl(Properties.Pages.Default.ConSupervision) + "?IdPasantia=" + itemPasantias.Id.ToString()));
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }
        public string ObtenerLinkVisitas(object idActividad)
        {
            try
            {
                return string.Format("{0}?IdPasantia={1}&IdActividad={2}&New=false", FormUrl(Properties.Pages.Default.RegistroVisitas), itemPasantias.Id, idActividad);
            }
            catch (Exception ex)
            {
                ManejarError(ex);
                return null;

            }
        }
        public string ObtenerLinkAsistencia(object id)
        {
            try
            {
                var s = string.Format("javascript:OpenDialog('{0}','{1}' );", string.Format("{0}?IdPasantia={1}&IdActividad={2}&New=false", FormUrl(Properties.Pages.Default.RegistroActividades), itemPasantias.Id, id), string.Empty);
                return s;
            }
            catch (Exception ex)
            {
                ManejarError(ex);
                return null;
            }
        }
        public string ObtenerLinkVisita(object id)
        {
            try
            {
                var s = string.Format("javascript:OpenDialog('{0}','{1}' );", string.Format("{0}?IdPasantia={1}&IdActividad={2}&New=false", FormUrl(Properties.Pages.Default.RegistroVisitas), itemPasantias.Id, id), string.Empty);
                return s;
            }
            catch (Exception ex)
            {
                ManejarError(ex);
                return null;
            }
        }
        protected void lnkAtras_Click(object sender, EventArgs e)
        {
            try
            {
                if (PaginadorActividades.PaginaActual > 0)
                {
                    PaginadorActividades.PaginaActual -= 1;
                    CargarActividades();

                }
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }

        }
        protected void lnkAdelante_Click(object sender, EventArgs e)
        {
            try
            {
                PaginadorActividades.PaginaActual += 1;
                CargarActividades();
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }



        }
        protected void lnkAtrasVisita_Click(object sender, EventArgs e)
        {
            try
            {
                if (PaginadorVisitas.PaginaActual > 0)
                {
                    PaginadorVisitas.PaginaActual -= 1;
                    CargarVisitas();

                }
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }

        }
        protected void lnkAdelanteVisita_Click(object sender, EventArgs e)
        {
            try
            {
                PaginadorVisitas.PaginaActual += 1;
                CargarVisitas();
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }



        }
        public void CargarActividades()
        {
            try
            {
                var aux = 0;
                this.grdAsistencia.DataSource = actividadesLogic.SeleccionarPaginado(PaginadorActividades.PaginaActual, PaginadorActividades.NumeroItemsPorPagina, itemPasantias.Id.Value, out aux); ;
                this.grdAsistencia.DataBind();
                PaginadorActividades.MaximoNumeroItems = aux;
                PaginadorActividades.Cargar();
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }
        public void RecargarActividades()
        {
            try
            {
                PaginadorActividades.PaginaActual = 0;
                PaginadorActividades.MaximoNumeroItems = 0;
                CargarActividades();
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }

        }
        public void CargarVisitas()
        {
            try
            {
                var aux = 0;

                this.grdVisitas.DataSource = visitasLogic.SeleccionarPaginado(PaginadorVisitas.PaginaActual, PaginadorVisitas.NumeroItemsPorPagina, itemPasantias.Id.Value, out aux);
                this.grdVisitas.DataBind();
                PaginadorVisitas.MaximoNumeroItems = aux;
                PaginadorVisitas.Cargar();
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }
        public void RecargarVisitas()
        {
            try
            {
                PaginadorVisitas.PaginaActual = 0;
                PaginadorVisitas.MaximoNumeroItems = 0;
                CargarVisitas();
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }

        }
        
        #endregion

       
       
    }
}

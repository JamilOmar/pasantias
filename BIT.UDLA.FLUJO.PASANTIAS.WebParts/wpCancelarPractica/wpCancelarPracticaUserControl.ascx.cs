using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using System.Collections.Generic;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpCancelarPractica
{
    public partial class wpCancelarPracticaUserControl : wpUsrControl
    {


        #region Properties
        public List<PasantiasPreProfesionales> ListaPasantias
        {
            set
            {

                ViewState["ListaPasantias"] = value;
            }
            get
            {
                return (List<PasantiasPreProfesionales>)ViewState["ListaPasantias"];
            }

        }
        private UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrPager Paginador
        {
            get
            {
                return (usrPager1 as UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrPager);
            }
        }

        #endregion

        #region Load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!PaginaRecargada)
                {
                    Recargar();
                }
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }

        }
        #endregion

        #region Events

        void Volver(int id)
        {
            Ira(Properties.Pages.Default.CancelarPractica, id);
        }
     
        protected void lnkAtras_Click(object sender, EventArgs e)
        {
            try
            {
                if (Paginador.PaginaActual > 0)
                {
                    Paginador.PaginaActual -= 1;
                    Cargar();

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
                if (Paginador.PaginaActual < Paginador.NumeroTotalPaginas())
                {
                    Paginador.PaginaActual += 1;
                    Cargar();
                }
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }



        }
        #endregion

        #region Methods
        public void Cargar()
        {
            var aux = 0;
            ListaPasantias = null;
            ListaPasantias = pasantiasLogic.SeleccionarPreCancelados(Paginador.PaginaActual, Paginador.NumeroItemsPorPagina, out aux, BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.CANCELADO);
            this.grdPasantias.DataSource = null;
            this.grdPasantias.DataSource = ListaPasantias;
            this.grdPasantias.DataBind();
            Paginador.MaximoNumeroItems = aux;
            Paginador.Cargar();
        }
        public string ObtenerLink(object id)
        {
            try
            {
                var s = string.Format("javascript:OpenDialog('{0}','{1}');", string.Format("{0}?idPasantia={1}", FormUrl(Properties.Pages.Default.ConfirmarCancelacion),
                  id), FormUrl(Properties.Pages.Default.CancelarPractica) );
                return s;
            }
            catch (Exception ex)
            {
                ManejarError(ex);
                return null;
            }
        }
        public void Recargar()
        {
            Paginador.PaginaActual = 0;
            Paginador.MaximoNumeroItems = 0;
            Cargar();

        }
        #endregion




    }
}

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;

using Microsoft.SharePoint;
using System.Linq;
using System.Collections.Generic;
namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpSeleccionAlumnosEmpresa
{
    public partial class wpSeleccionAlumnosEmpresaUserControl : wpUsrControl
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
            Ira(Properties.Pages.Default.SeleccionAlumnosEmpresa, id);
        }
        protected void btnCancelar_Command(object sender, CommandEventArgs e)
        {
            try
            {

                CancelarFlujo(false, int.Parse(e.CommandArgument.ToString()), BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Mensajes.Default.MensajeCanceladoEmpresa);
                Volver(int.Parse(e.CommandArgument.ToString()));
               
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }

        protected void btnAceptar_Command(object sender, CommandEventArgs e)
        {
            try
            {


                pasantiasLogic.CambiarEstadoSeleccionadoAlumnoEmpresa(int.Parse(e.CommandArgument.ToString()), BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.CARTA_DE_COMPROMISO, true);
                Volver(int.Parse(e.CommandArgument.ToString()));
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }

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
                Paginador.PaginaActual += 1;
                Cargar();
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
            ListaPasantias = pasantiasLogic.SeleccionarAlumnosParaEmpresa(Paginador.PaginaActual, Paginador.NumeroItemsPorPagina, BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.ACEPTACION_ESTUDIANTE_EMPRESA, out aux);
            this.grdPasantias.DataSource = ListaPasantias;
            this.grdPasantias.DataBind();
            Paginador.MaximoNumeroItems = aux;
            Paginador.Cargar();
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

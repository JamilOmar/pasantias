using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using System.Collections.Generic;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpSeleccionAlumnosDocente
{
    public partial class wpSeleccionAlumnosDocenteUserControl : wpUsrControl
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
            Ira(Properties.Pages.Default.SeleccionAlumnosDocente, id);
        }
        protected void btnCancelar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                //itemPasantias.EsSeleccionadoPorDocente = false;
                CancelarFlujo(false, int.Parse(e.CommandArgument.ToString()), BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Mensajes.Default.MensajeCanceladoDocente);
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
                //pasantiasLogic.CambiarEstadoSeleccionadoAlumnoDocente(int.Parse(e.CommandArgument.ToString()), Properties.Flujo.Default.SELECCION_USUARIO_EMPRESA, true);
                pasantiasLogic.CambiarEstadoSeleccionadoAlumnoDocente(int.Parse(e.CommandArgument.ToString()), BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.NOTIFICAR_DOCENTE, true);
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
            ListaPasantias = pasantiasLogic.SeleccionarAlumnosParaDocente(Paginador.PaginaActual, Paginador.NumeroItemsPorPagina, BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.SELECCION_USUARIO_DOCENTE, out aux);
            this.grdPasantias.DataSource = null;
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

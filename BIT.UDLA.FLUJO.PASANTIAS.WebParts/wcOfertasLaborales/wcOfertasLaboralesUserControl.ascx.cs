using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.wcOfertasLaborales
{
    public partial class wcOfertasLaboralesUserControl : wpUsrControl
    {
        #region Properties
        public int? IdPeticion
        {
            set
            {
                ViewState["IdPeticion"] = value;
            }
            get
            {
                return (int?)ViewState["IdPeticion"];
            }
        }
        OfertaLogic ofertasLogic = new OfertaLogic();

        private UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrPager PaginadorActividades
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
                    IdPeticion = GetPasantiaQueryString();
                    if (IdPeticion.HasValue)
                    {
                        itemPasantias = pasantiasLogic.SeleccionarPorId(IdPeticion.Value);
                    }
                    RecargarActividades();
                }
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        } 
        #endregion

        #region Methods
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
        public void CargarActividades()
        {
            try
            {
                var aux = 0;
                empresasListRepeater.DataSource = ofertasLogic.SeleccionarListaOfertas(PaginadorActividades.NumeroItemsPorPagina, PaginadorActividades.PaginaActual + 1, out aux);
                empresasListRepeater.DataBind();
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
        #endregion

    }
}

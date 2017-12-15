using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpListaEmpresas
{
    public partial class wpListaEmpresasUserControl : wpUsrControl
    {
        #region Properties
        EmpresaLogic empresaLogic = new EmpresaLogic();
        private UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrPager PaginadorActividades
        {
            get
            {
                return (usrPager1 as UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrPager);
            }
        }
        
        public BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrBuscador Buscador
        {
          

            get
            {
                return (usrBuscador as BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrBuscador);
            }
        } 
        
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
                        if (itemPasantias.IdEmpresa.HasValue && itemPasantias.IdEmpresa.Value != 0)
                            Ira(Properties.Pages.Default.InformacionEmpresas, "?ide=" + itemPasantias.IdEmpresa.Value.ToString() + "&modo=select&idPasantia=" + IdPeticion.ToString(),false);
                        hpNuevo.HRef = CrearLinkNuevo();
                        Buscador.Criterio = "A";
                        CargarActividades();
                    }
                 
                }
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }

       public  void Buscador_OnBuscar(object sender, EventArgs e)
        {
            RecargarActividades();
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
                empresasListRepeater.DataSource = empresaLogic.SeleccionarListaEmpresas(Buscador.Criterio,PaginadorActividades.NumeroItemsPorPagina, PaginadorActividades.PaginaActual, out aux);
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
        public string CrearLink(object id)
        {
            return FormUrl( Properties.Pages.Default.InformacionEmpresas) + "?ide=" + id.ToString() + "&modo=select&idPasantia=" + IdPeticion.ToString();
        }
        public string CrearLinkNuevo()
        {
            return  FormUrl(Properties.Pages.Default.NuevaEmpresa) + "?idPasantia=" + IdPeticion.ToString();
        }
        #endregion



    }
}

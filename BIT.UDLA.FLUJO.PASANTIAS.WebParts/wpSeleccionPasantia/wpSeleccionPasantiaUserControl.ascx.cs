using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.Constants;
using System.Collections.Generic;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpSeleccionPasantia
{
    public partial class wpSeleccionPasantiaUserControl  : wpUsrControl
    {
     

        #region Load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!PaginaRecargada)
                {

                    var id = GetPasantiaQueryString();
                    if (id.HasValue)
                    {
                        List<string> options = new List<string>()
                        {FLUJOS.PASANTIAS.Constants.FlujoConstantes.CON_TRABAJO, 
                            FLUJOS.PASANTIAS.Constants.FlujoConstantes.CON_SUPERVISION , 
                            FLUJOS.PASANTIAS.Constants.FlujoConstantes.SIN_SUPERVISION};
                        this.ddlPractica.DataSource = options;
                        this.ddlPractica.DataBind();
                      
                        itemPasantias = pasantiasLogic.SeleccionarPorId(id.Value);

                    }
                }
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        } 
        #endregion

        #region Mappers
        PasantiasPreProfesionales MapToEntity()
        {
            itemPasantias.TipoPasantiaEnum = ddlPractica.SelectedValue.ToUpper();
            if(itemPasantias.TipoPasantiaEnum == BIT.UDLA.FLUJOS.PASANTIAS.Constants.FlujoConstantes.CON_SUPERVISION)
                itemPasantias.Estado = BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.SELECCION_MATERIA;
            else
            itemPasantias.Estado =BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.SELECCION_PRACTICA;
            return itemPasantias;
        } 
        #endregion

        #region Methods
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                pasantiasLogic.Actualizar(MapToEntity());
                if (itemPasantias.TipoPasantiaEnum == BIT.UDLA.FLUJOS.PASANTIAS.Constants.FlujoConstantes.CON_SUPERVISION)
                    Ira(Properties.Pages.Default.SeleccionMateria, itemPasantias.Id);
                else
                Ira(Properties.Pages.Default.HojaDeVida, itemPasantias.Id);
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }

        /// <summary>
        /// Metodo que cancela la practica preprofesional
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Ira(Properties.Pages.Default.Home, null);
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        } 
        #endregion
    }
}

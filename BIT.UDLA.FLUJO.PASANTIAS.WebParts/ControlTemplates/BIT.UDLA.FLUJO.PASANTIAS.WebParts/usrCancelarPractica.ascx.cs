using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts
{
    public partial class usrCancelarPractica  : wpUsrControl
    {

        public event EventHandler Aceptar;
        public event EventHandler Cancelar;
       
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!PaginaRecargada)
            {
                var id = GetPasantiaQueryString();

                if (id.HasValue)
                {
                    itemPasantias = pasantiasLogic.SeleccionarPorId(id.Value);

                }

            }
        }
       
         void MapToEntity()
        {
            if (Opciones.SelectedValue == "SI")
            {
                itemPasantias.ProblemaEnElSistemaSAES = true;
                itemPasantias.FechaDelProblema = DateTime.Now;
                CancelarFlujo(descipcionTextBox.Text);
            }
            else
            {
                itemPasantias.ProblemaEnElSistemaSAES = false;
                pasantiasLogic.Actualizar(itemPasantias);
            }

        }
       
        protected void aceptarButton_Click(object sender, EventArgs e)
        {
            try
            {

                MapToEntity();

                if (Aceptar != null)
                {
                    Aceptar(this, e);
                }


            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        protected void cancelarButton_Click(object sender, EventArgs e)
        {
            try
            {
              
                if (Cancelar != null)
                {
                    Cancelar(this, e);
                }else
                    Ira(Properties.Pages.Default.Error, itemPasantias.Id.Value);
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }
      
     
     
 
        protected void Opciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            descipcionTextBox.Text = string.Empty;
            rfvFunciones.Enabled= descipcionTextBox.Enabled = Opciones.SelectedValue == "SI";
        }
    }
}

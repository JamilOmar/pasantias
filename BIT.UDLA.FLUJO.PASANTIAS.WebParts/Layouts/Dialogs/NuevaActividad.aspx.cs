using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.Layouts.Dialogs
{
    public partial class NuevaActividad : DialogLayoutsPageBage
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
          
          
        }
      

        public void NuevaActividad_Cancelar(object sender, EventArgs e)
        {
           
                    Web.Update(); EndOperation(1, "null");
             
        }
        public void NuevaActividad_Aceptar(object sender, EventArgs e)
        {
            if (IsValid)
            {
                {
                    Web.Update(); EndOperation(1);
                }
            }
        }

    
    }
}

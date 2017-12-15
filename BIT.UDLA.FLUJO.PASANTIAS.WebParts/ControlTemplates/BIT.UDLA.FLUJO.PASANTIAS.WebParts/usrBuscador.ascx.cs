using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts
{
    public partial class usrBuscador : wpUsrControl
    {
        #region Propiedades

        public string Titulo { get { return this.lblBuscar.Text; } set { lblBuscar.Text = value; } }

        //Helper
        public class usrBuscadorIngreso : EventArgs
        {
            public string Criterio { get; set; }
        }
        public string Criterio
        {
            set
            {
                ViewState["Criterio"] = value;
            }
            get
            {
                if (ViewState["Criterio"] == null)
                    ViewState["Criterio"] = string.Empty;
                return ViewState["Criterio"].ToString();
            }
        } 
        #endregion

        #region Eventos Publicos
		   public event EventHandler OnBuscar;
 
    	#endregion      
        
        #region Eventos Privados

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!PaginaRecargada)
            {
               // Criterio = string.Empty;
 
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Criterio = txtBuscador.Text;
            if (OnBuscar != null)
                OnBuscar(this, new usrBuscadorIngreso { Criterio =Criterio });
        } 
    
	#endregion  

        
    }
}

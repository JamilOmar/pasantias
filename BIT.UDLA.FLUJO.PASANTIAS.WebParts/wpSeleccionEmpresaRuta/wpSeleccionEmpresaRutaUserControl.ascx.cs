using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpSeleccionEmpresaRuta
{
    public partial class wpSeleccionEmpresaRutaUserControl : wpUsrControl   
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                    if (!PaginaRecargada)
                {
                    var id = GetPasantiaQueryString();
                    this.hpActividades.NavigateUrl = FormUrl(Properties.Pages.Default.ConSupervision) + "?IdPasantia=" + id.ToString();
                    this.hpFicha.NavigateUrl = FormUrl(Properties.Pages.Default.FichaRegistroConfirmacionEmpresa) + "?IdPasantia=" + id.ToString();
                }
        }
    }
}

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpSeleccionOfertaEmpresaRuta
{
    public partial class wpSeleccionOfertaEmpresaRutaUserControl: wpUsrControl   
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                    if (!PaginaRecargada)
                {
                    var id = GetPasantiaQueryString();
                    this.hpEmpresas.NavigateUrl = FormUrl(Properties.Pages.Default.Empresas) + "?IdPasantia=" + id.ToString();
                    this.hpOfertas.NavigateUrl = FormUrl(Properties.Pages.Default.Ofertas) + "?IdPasantia=" + id.ToString();
                }
        }
    }
}
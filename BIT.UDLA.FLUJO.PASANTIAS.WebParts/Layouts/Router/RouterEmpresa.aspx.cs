using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Utilities;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.Layouts.Router
{
    public partial class RouterEmpresa :UnsecuredLayoutsPageBase
    {
        protected override bool AllowAnonymousAccess { get { return true; } }
        protected void Page_Load(object sender, EventArgs e)
        {
        
            Response.Redirect(Properties.Pages.Default.EmpresasPuerto, false);
        }
    }
}

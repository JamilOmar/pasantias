using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint;
using System.Globalization;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts
{
   
    public abstract class DialogLayoutsPageBage : LayoutsPageBase {   
        
        protected string PageToRedirectOnOK { get; set; }    
        protected void EndOperation()     {         EndOperation(1);     }    
        protected void EndOperation(int result)     {         EndOperation(result, PageToRedirectOnOK);     }       
        protected void EndOperation(int result, string returnValue)     {                   Page.Response.Clear();             Page.Response.Write(String.Format(CultureInfo.InvariantCulture, "<script type=\"text/javascript\">window.frameElement.commonModalDialogClose({0}, {1});</script>", new object[] { result, String.IsNullOrEmpty(returnValue) ? "null" : String.Format("\"{0}\"", returnValue) }));            
        } }   
   

}

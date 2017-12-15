using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.IdentityModel;
using Microsoft.SharePoint.IdentityModel.Pages;
using Microsoft.SharePoint.Administration;
using System.Web;
using Microsoft.SharePoint.Utilities;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.Layouts.Login
{
    public partial class LoginPage :System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
          //  imgEstudiante.Click += new System.Web.UI.ImageClickEventHandler(imgEstudiante_Click);
           
        }
        protected void Button1_Click(object sender, EventArgs e)

        {

            bool status = SPClaimsUtility.AuthenticateFormsUser(Context.Request.UrlReferrer, txtUserName.Text, txtPassword.Text);
  
            if (!status)

            {

                lblError.Text = "Error en password o nombre de usuario.";

            }

            else

            {

                if (Context.Request.QueryString.Keys.Count > 1)

                {

                    Response.Redirect(Context.Request.QueryString["Source"].ToString());

                }

                else

                    Response.Redirect(Context.Request.QueryString["ReturnUrl"].ToString());

            }

        }

    
        //void imgEstudiante_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    if (null != SPContext.Current && null != SPContext.Current.Site)
        //    {
        //        SPIisSettings iisSettings = SPContext.Current.Site.WebApplication.IisSettings[SPUrlZone.Default];
        //        if (null != iisSettings && iisSettings.UseWindowsClaimsAuthenticationProvider)
        //        {
        //            SPAuthenticationProvider provider = iisSettings.WindowsClaimsAuthenticationProvider;
    
        //            RedirectToLoginPage(provider);
        //        }
        //    }
        //}

        private void RedirectToLoginPage(SPAuthenticationProvider provider)
        {
            string components = HttpContext.Current.Request.Url.GetComponents(UriComponents.Query, UriFormat.SafeUnescaped);
            string url = provider.AuthenticationRedirectionUrl.ToString();
            if (provider is SPWindowsAuthenticationProvider)
            {
                components = EnsureUrlSkipsFormsAuthModuleRedirection(components, true);
            }
            SPUtility.Redirect(url, SPRedirectFlags.Default, this.Context, components);
        }

   
        private string EnsureUrlSkipsFormsAuthModuleRedirection(string url, bool urlIsQueryStringOnly)
        {
            if (!url.Contains("ReturnUrl="))
            {
                if (urlIsQueryStringOnly)
                {
                    url = url + (string.IsNullOrEmpty(url) ? "" : "&");
                }
                else
                {
                    url = url + ((url.IndexOf('?') == -1) ? "?" : "&");
                }
                url = url + "ReturnUrl=";
            }
            return url;
        }




      
        

    }
}

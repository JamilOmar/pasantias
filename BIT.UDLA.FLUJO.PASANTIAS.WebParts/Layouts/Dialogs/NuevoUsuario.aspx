<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuevoUsuario.aspx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.Layouts.Dialogs.NuevoUsuario" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Register src="~/_controltemplates/BIT.UDLA.FLUJO.PASANTIAS.WebParts/usrAgregarUsuario.ascx" tagname="usrAgregarUsuario" tagprefix="uc1" %>
<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script type="text/javascript">
        function ValidateLines(e, max, chrln) {
            var text = e.value; //.replace(/\s+$/g,"");
            var split = e.value.split("\n");

            if (max == 0)
                max = split.length;
            if (chrln == 0)
                chrln = text.length + 1;

            if (split.length <= max && text.length + 1 <= chrln) {
                return true;
            }
            else if (split.length >= max || e.value.length >= chrln) {
                return false;
            }
        }  
 </script>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<uc1:usrAgregarUsuario ID="usrAgregarUsuario" runat="server" OnAceptar="NuevaActividad_Aceptar" OnCancelar="NuevaActividad_Cancelar" />
</asp:Content>
<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Administración de Usuarios
</asp:Content>
<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
</asp:Content>
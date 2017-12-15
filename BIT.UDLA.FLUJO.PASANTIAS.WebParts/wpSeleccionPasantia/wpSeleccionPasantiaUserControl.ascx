<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpSeleccionPasantiaUserControl.ascx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpSeleccionPasantia.wpSeleccionPasantiaUserControl" %>
<%@ Register src="../usrCommand.ascx" tagname="usrCommand" tagprefix="uc1" %>

<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {}
</style>

<table class="style1">
    <tr>
       
        <td>
            <asp:DropDownList ID="ddlPractica" runat="server">
               
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
       
        <td>
            <uc1:usrCommand ID="usrCommand1" runat="server"   OnOnCancelar="btnCancelar_Click" 
                                    OnOnGuardar="btnAceptar_Click" BotonAceptarTexto="CONTINUAR" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>


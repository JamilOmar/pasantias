<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usrBuscador.ascx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrBuscador" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 69px;
    }
    .style3
    {
    }
</style>

<table class="style1">
    <tr>
        <td class="style2">
            <asp:Label ID="lblBuscar" runat="server" Text="lblGenerico"></asp:Label>
        </td>
        <td class="style3">
            <asp:TextBox ID="txtBuscador" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                Text="Buscar" ValidationGroup="wsBuscador" BackColor="Maroon" ForeColor="White" style="font-weight: 700" />
        </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style3" colspan="2">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtBuscador" Display="Dynamic" 
                ErrorMessage="Debe ingresar un criterio de búsqueda." 
                ValidationGroup="wsBuscador">Debe ingresar un criterio de búsqueda.</asp:RequiredFieldValidator>
        </td>
    </tr>
</table>


<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usrCommand.ascx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrCommand" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>
<table class="style1">
    <tr>
        <td>
            <asp:Button ID="btnGuardar" runat="server" onclick="btnGuardar_Click" 
                Text="APROBAR" ValidationGroup="practicas"   BackColor="Maroon" ForeColor="White" style="font-weight: 700" />
        </td>
        <td>
            <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" 
                onclick="btnCancelar_Click" Text="REGRESAR"   BackColor="Maroon" ForeColor="White" style="font-weight: 700" />
        </td>
        <td runat="server" id="tdEliminar" visible="False">
            <asp:Button ID="btnEliminar" runat="server" CausesValidation="False" 
                onclick="btnEliminar_Click" Text="RECHAZAR"    BackColor="Maroon" ForeColor="White" style="font-weight: 700" />
        </td>
    </tr>
</table>


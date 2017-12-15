<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usrPager.ascx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrPager" %>
<table >
    <tr>
        <td>
            &nbsp;</td>
        <td >
            <asp:LinkButton ID="lnkAtras" runat="server" onclick="lnkAtras_Click">&lt;</asp:LinkButton>
            <asp:Label ID="lblPaginas" runat="server"></asp:Label>
                  <asp:LinkButton ID="lnkAdelante" runat="server" onclick="lnkAdelante_Click">&gt;</asp:LinkButton>
        </td>
        <td>
        </td>
    </tr>
</table>


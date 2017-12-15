<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpSeleccionMateriaUserControl.ascx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpSeleccionMateria.wpSeleccionMateriaUserControl" %>
<%@ Register src="../usrCommand.ascx" tagname="usrCommand" tagprefix="uc1" %>
<style type="text/css">

    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 34px;
    }
</style>

<table class="style1">
    <tr>
        <td class="style2">
            <asp:Label ID="lblMateria" runat="server" Text="Materia:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlMateria" runat="server" 
                onselectedindexchanged="ddlMateria_SelectedIndexChanged" 
                AutoPostBack="True">
                <asp:ListItem>QUIMICA</asp:ListItem>
                <asp:ListItem>FINANZAS</asp:ListItem>
                <asp:ListItem>HISTORIA</asp:ListItem>
            </asp:DropDownList>
            <asp:CompareValidator ID="cmpMateria" runat="server" 
                ControlToValidate="ddlMateria" Display="Dynamic" 
                ErrorMessage="Debe Seleccionar una materia" 
                Operator="NotEqual" ValueToCompare="-1" ValidationGroup="practicas">*</asp:CompareValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="lblMateriaDocente" runat="server" Text="Docente:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblMateriaName" runat="server"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            <asp:Label ID="lblError" runat="server" style="color: #FF0000" 
                Text="Docente No Valido." Visible="False"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            <asp:ValidationSummary ID="valSumario" runat="server" 
                ValidationGroup="practicas" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            <uc1:usrCommand ID="usrCommand1" runat="server" 
                OnOnCancelar="cancelarButton_Click" OnOnGuardar="aceptarButton_Click"  
                OnOnEliminar="btnCancelarFlujo_Click" EliminarVisible="False" 
                BotonAceptarTexto="ACEPTAR"  />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    
</table>


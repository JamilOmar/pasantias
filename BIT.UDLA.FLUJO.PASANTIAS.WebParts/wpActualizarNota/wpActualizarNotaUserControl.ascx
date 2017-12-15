<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" namespace="Microsoft.SharePoint.WebControls" tagprefix="cc1" %>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpActualizarNotaUserControl.ascx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpActualizarNota.wpActualizarNotaUserControl" %>
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
        <!-- sin supervision -->
            <asp:DropDownList ID="ddlMateria" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlMateria_SelectedIndexChanged">
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
            <asp:Label ID="lblNota" runat="server" Text="Hora:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtNota" runat="server" MaxLength="5"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtNota" Display="Dynamic" 
                ErrorMessage="Debe ingresar las horas necesarias" ValidationGroup="practicas">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                ControlToValidate="txtNota" Display="Dynamic" 
                ErrorMessage="Debe ser Mayor que 0" Operator="GreaterThan" Type="Integer" 
                ValidationGroup="practicas" ValueToCompare="0">*</asp:CompareValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label2" runat="server" Text="Máximo de Horas:" Width="120px"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblMaximoHoras" runat="server"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
   <tr>
        <td class="style2">
            <asp:Label ID="Label1" runat="server" Text="Observación:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtObservacion" runat="server" MaxLength="95" Width="384px" ></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            <asp:Label ID="lblError" runat="server" EnableViewState="False" 
                style="color: #FF0000" Visible="False"></asp:Label>
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
            <uc1:usrCommand ID="usrCommand1" runat="server" OnOnCancelar="cancelarButton_Click" OnOnGuardar="aceptarButton_Click" EliminarVisible="true" OnOnEliminar="btnCancelarFlujo_Click" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    
</table>


<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usrRegistroVisitas.ascx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrRegistroVisitas" %>
<%@ Register src="usrCommand.ascx" tagname="usrCommand" tagprefix="uc2" %>
<%@ Register assembly="BIT.UDLA.FLUJOS.PASANTIAS.Comun, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7bf52b8cf62fe4fe" namespace="WimdowsControls.Web.UI" tagprefix="cc1" %>

<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        height: 23px;
    }
    .style3
    {
        font-weight: bold;
    }
</style>

<h3>
    Registro de Visitas</h3>

<table class="style1">
    <tr>
        <td class="style2">
                <asp:Label ID="Label5" runat="server" Text="Estudiante:" CssClass="style3"></asp:Label>
            </td>
        <td class="style2">
            <asp:Label ID="lblUsuario" runat="server"></asp:Label>
        </td>
        <td class="style2">
        </td>
    </tr>
    <tr>
        <td>
                <asp:Label ID="Label4" runat="server" Text="Fecha Visita:" CssClass="style3"></asp:Label>
            </td>
        <td>
                <SharePoint:DateTimeControl  runat="server" ID="fechaFinCalendar" 
                DateOnly="true" ErrorMessage="" IsRequiredField="False" IsValid="True" />
            </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
                <asp:Label ID="Label3" runat="server" Text="Descripción:" CssClass="style3"></asp:Label>
            </td>
        <td>
                  <cc1:RequiredTextBox ID="cargoTextBox" runat="server" Text="" TextMode="MultiLine" 
                    Height="90px" Width="291px" Rows="6" MaxLines="6"  />
                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" 
                    ControlToValidate="cargoTextBox" ErrorMessage="*" ValidationGroup="practicas">*</asp:RequiredFieldValidator>
            </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
                <asp:Label ID="lblError" runat="server" 
                    EnableViewState="False" style="color: #FF0000" 
                    Text="Verifique la Fechas Ingresada" Visible="False"></asp:Label>
            </td>
        <td>
                &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
                <uc2:usrCommand ID="procesarUsrCommand" runat="server" OnOnCancelar="cancelarButton_Click" OnOnGuardar="aceptarButton_Click" BotonAceptarTexto="GUARDAR" BotonCancelarTexto="CERRAR"/>
            </td>
        <td>
            &nbsp;</td>
    </tr>
</table>


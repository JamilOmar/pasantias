<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usrRegistroActividades.ascx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrRegistroActividades" %>
<%@ Register src="usrCommand.ascx" tagname="usrCommand" tagprefix="uc2" %>
<%@ Register assembly="BIT.UDLA.FLUJOS.PASANTIAS.Comun, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7bf52b8cf62fe4fe" namespace="WimdowsControls.Web.UI" tagprefix="cc1" %>

<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 132px;
    }
    .style3
    {}
    .style4
    {
        width: 132px;
        height: 22px;
    }
    .style5
    {
        height: 22px;
    }
    .style6
    {
        font-weight: bold;
    }
</style>

<h3>
    Registro de Actividades</h3>

<table class="style1">
    <tr>
        <td class="style2">
            <asp:Label ID="Label1" runat="server" Text="Fecha Inicio:" CssClass="style6"></asp:Label>
        </td>
        <td class="style3">
                <SharePoint:DateTimeControl ID="fechaInicioCalendar" runat="server" 
                    DateOnly="True" ErrorMessage="*" IsRequiredField="True" IsValid="True" />
            </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label2" runat="server" Text="Fecha Fin:" CssClass="style6"></asp:Label>
        </td>
        <td class="style3">
                <SharePoint:DateTimeControl ID="fechaFinCalendar" runat="server" 
                    DateOnly="True" ErrorMessage="*" IsRequiredField="True" IsValid="True"/>
            </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label3" runat="server" Text="Actividades:" CssClass="style6"></asp:Label>
        </td>
        <td class="style3">
                <cc1:RequiredTextBox ID="ActividadesTextBox" runat="server" Text=""  
                TextMode="MultiLine" Height="90px" Width="291px" Rows="6" MaxLines="6"  />
                <asp:RequiredFieldValidator ID="rfvActividades" runat="server" 
                    ControlToValidate="ActividadesTextBox" ErrorMessage="*" 
                    ValidationGroup="practicas">*</asp:RequiredFieldValidator>
            </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label4" runat="server" Text="Horas:" CssClass="style6"></asp:Label>
        </td>
        <td class="style3">
                <asp:TextBox ID="numeroHorasEjecutadasTextBox" runat="server" Text="0" 
                    MaxLength="4"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDescripcionHoras" runat="server" 
                    ControlToValidate="numeroHorasEjecutadasTextBox" ErrorMessage="*" 
                    ValidationGroup="practicas">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cmpValidador" runat="server" 
                    ControlToValidate="numeroHorasEjecutadasTextBox" Display="Dynamic" 
                    ErrorMessage="*" Operator="DataTypeCheck" Type="Integer" 
                    ValidationGroup="practica">Solo números.</asp:CompareValidator>
                </td>
        <td>
                &nbsp;</td>
    </tr>
    <tr runat="server" id="trEmpresa">
        <td class="style2">
            <asp:Label ID="Label6" runat="server" Text="Observación Empresa/Institución:" 
                CssClass="style6"></asp:Label>
        </td>
        <td class="style3">
                    <cc1:RequiredTextBox ID="DescripcionEmpresaTextBox" runat="server" Text=""  
                TextMode="MultiLine" Height="90px" Width="291px" MaxLines="6"  />
            </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr runat="server" id="trDocente">
        <td class="style2">
            <asp:Label ID="Label5" runat="server" Text="Observación Docente:" 
                CssClass="style6"></asp:Label>
        </td>
        <td class="style3">
                <cc1:RequiredTextBox ID="DescripcionDocenteTextbox" runat="server" Text=""  
                TextMode="MultiLine" Height="90px" Width="291px" MaxLines="6"  />
            </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style4">
                <asp:Label ID="lblError" runat="server" 
                    EnableViewState="False" style="color: #FF0000" 
                    Text="Verifique las Fechas Ingresadas" Visible="False"></asp:Label>
        </td>
        <td class="style5" colspan="2">
                &nbsp;</td>
    </tr>
    <tr>
        <td class="style4">
        </td>
        <td class="style5" colspan="2">
                <uc2:usrCommand ID="procesarUsrCommand" runat="server" OnOnCancelar="cancelarButton_Click" OnOnGuardar="aceptarButton_Click" BotonAceptarTexto="GUARDAR" BotonCancelarTexto="CERRAR"/>
            </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style3">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>


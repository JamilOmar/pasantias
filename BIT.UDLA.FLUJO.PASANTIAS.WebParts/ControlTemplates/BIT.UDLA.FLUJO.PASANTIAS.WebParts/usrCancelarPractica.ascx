<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usrCancelarPractica.ascx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrCancelarPractica" %>
<%@ Register src="usrCommand.ascx" tagname="usrCommand" tagprefix="uc1" %>
<%@ Register assembly="BIT.UDLA.FLUJOS.PASANTIAS.Comun, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7bf52b8cf62fe4fe" namespace="WimdowsControls.Web.UI" tagprefix="cc1" %>





<style type="text/css">
    .style3
    {
        font-weight: bold;
    }
</style>




<h3>
    Cancelación de&nbsp; Flujo
</h3>

<table class="style1">
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Cancelar el Flujo?" 
                CssClass="style3"></asp:Label>
        </td>
        <td>
            <asp:RadioButtonList ID="Opciones" runat="server" AutoPostBack="True" 
                onselectedindexchanged="Opciones_SelectedIndexChanged" 
                RepeatDirection="Horizontal">
                <asp:ListItem>SI</asp:ListItem>
                <asp:ListItem Selected="True">NO</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label6" runat="server" Text="Descripción:" CssClass="style3"></asp:Label>
        </td>
        <td>
             <cc1:RequiredTextBox ID="descipcionTextBox" runat="server" TextMode="MultiLine" Height="103px"
                Width="293px" MaxLines="6" Enabled="False" ValidationGroup="practicas"   />
                <asp:RequiredFieldValidator ID="rfvFunciones" runat="server" 
                    ControlToValidate="descipcionTextBox" ErrorMessage="Ingrese &quot;Descripción&quot;." 
                    ValidationGroup="practicas" Display="Dynamic" Enabled="False">*</asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="3">
                        <span class="nav2">
                            <uc1:usrCommand ID="usrCommand1" runat="server" OnOnGuardar="aceptarButton_Click"  OnOnCancelar="cancelarButton_Click" BotonAceptarTexto="GUARDAR" BotonCancelarTexto="CERRAR"/>
                            
                            </span>
                    </td>
    </tr>
</table>


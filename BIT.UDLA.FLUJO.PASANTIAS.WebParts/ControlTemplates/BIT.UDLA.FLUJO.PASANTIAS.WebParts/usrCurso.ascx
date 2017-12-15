<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usrCurso.ascx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrCurso" %>
<%@ Register src="usrCommand.ascx" tagname="usrCommand" tagprefix="uc1" %>





<%@ Register assembly="BIT.UDLA.FLUJOS.PASANTIAS.Comun, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7bf52b8cf62fe4fe" namespace="WimdowsControls.Web.UI" tagprefix="cc1" %>





<style type="text/css">
    .style3
    {
        font-weight: bold;
    }
</style>




<h3>
Cursos Realizados
</h3>

<table class="style1">
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Nombre:" CssClass="style3"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="nombreTextBox" runat="server" size="60" Style="width: 290px" MaxLength="60" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="*" ControlToValidate="nombreTextBox" Display="Dynamic" 
                ValidationGroup="practicas"></asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="País:" CssClass="style3"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="paisDropDownList" runat="server" class="textoayuda" Style="width: 110px">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Institución/Dictado por:" 
                CssClass="style3"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="institucionTextBox" runat="server" size="60" Style="width: 290px" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Fecha:" CssClass="style3"></asp:Label>
        </td>
        <td>
            
            <SharePoint:DateTimeControl ID="fechaDateTime" runat="server" DateOnly="true" />
          
            </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label5" runat="server" Text="Duración(Horas):" CssClass="style3"></asp:Label>
        </td>
        <td>
            <span class="textotablas">
                <asp:TextBox ID="duracionTextBox" runat="server" class="textoayuda" Style="width: 70px">0</asp:TextBox>
            </span>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="El valor debe estar entre 0 - 64"
                ControlToValidate="duracionTextBox" MaximumValue="64" MinimumValue="1" 
                Display="Dynamic" ValidationGroup="practicas" Type="Integer"></asp:RangeValidator><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" 
                ControlToValidate="duracionTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
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
                Width="293px" MaxLength="255"   />
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


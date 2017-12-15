<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usrAgregarUsuario.ascx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrAgregarUsuario" %>
<%@ Register src="usrBuscador.ascx" tagname="usrBuscador" tagprefix="uc2" %>
<%@ Register src="usrCommand.ascx" tagname="usrCommand" tagprefix="uc1" %>

<style type="text/css">

    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 129px;
    }
    .style3
    {
        font-weight: bold;
    }
    .style4
    {
    }
    .style5
    {
    }
    .style6
    {
        width: 220px;
    }
    .style7
    {
        width: 100%;
    }
    .style8
    {
        width: 150px;
    }
</style>

<h3>
    Registro de Usuarios</h3>

<table class="style1">
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <table class="style1">
                <tr>
                    <td class="style5" colspan="2">
                        <table class="style7" runat="server" id="trInformacion" visible=false>
                            <tr>
                                <td class="style8">
                        <asp:Label ID="Label1" runat="server" CssClass="style3" Text="Nombre Original:"></asp:Label>
                                </td>
                                <td>
                        <asp:Label ID="lblNombreOriginal" runat="server" CssClass="style3"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style8">
                        <asp:Label ID="Label2" runat="server" CssClass="style3" 
                            Text="Teléfono Original:"></asp:Label>
                                </td>
                                <td>
                        <asp:Label ID="lblTelefonoOriginal" runat="server" CssClass="style3"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style8">
                        <asp:Label ID="Label3" runat="server" CssClass="style3" Text="Email Original:"></asp:Label>
                                </td>
                                <td>
                        <asp:Label ID="lblEmailOriginal" runat="server" CssClass="style3"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        </td>
                    <td>
                        </td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="style3"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtNombre" runat="server" Width="150px" MaxLength="50"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" 
                            ErrorMessage="Ingrese el Nombre." 
                            ControlToValidate="txtNombre" ValidationGroup="practicas">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblApellido" runat="server" Text="Apellido:" CssClass="style3"></asp:Label>
                    </td>
                    <td class="style2">
                     <asp:TextBox ID="txtApellido" runat="server"  Width="150px" MaxLength="50"></asp:TextBox></td>
                    <td>
                     <asp:RequiredFieldValidator ID="rfvApellido" runat="server" 
                            ErrorMessage="Ingrese el Apellido" 
                            ControlToValidate="txtApellido" ValidationGroup="practicas">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblUserName" runat="server" Text="Username(mínimo 8 chr.):" 
                            CssClass="style3"></asp:Label>
                    </td>
                    <td class="style2">
                         <asp:TextBox ID="txtUserName" runat="server"  Width="150px" MaxLength="10"></asp:TextBox></td>
                    <td>
                         <asp:RequiredFieldValidator ID="rfvUsername" runat="server" 
                            ErrorMessage="Ingrese Username" 
                             ControlToValidate="txtUserName" ValidationGroup="practicas">*</asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                             ControlToValidate="txtUserName" Display="Dynamic" 
                             ErrorMessage="Ingrese solo  letras y  números  para el username." 
                             ValidationExpression="^[a-zA-Z0-9]{8,10}$" ValidationGroup="practicas">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblPassword" runat="server" Text="Password:" CssClass="style3"></asp:Label>
                    </td>
                    <td class="style2">
                         <asp:TextBox ID="txtPassword" runat="server"  Width="150px" MaxLength="25" 
                             TextMode="Password"></asp:TextBox></td>
                    <td>
                          <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                            ErrorMessage="Ingrese Password" 
                              ControlToValidate="txtPassword" ValidationGroup="practicas">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:" CssClass="style3"></asp:Label>
                    </td>
                    <td class="style2">
                         <asp:TextBox ID="txtTelefono" runat="server"  Width="150px" MaxLength="30"></asp:TextBox></td>
                    <td>
                     <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" 
                            ErrorMessage="Ingrese el Teléfono" 
                            ControlToValidate="txtTelefono" ValidationGroup="practicas">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail0" runat="server" 
                            ErrorMessage="El teléfono es inválido." 
                            ControlToValidate="txtTelefono" Display="Dynamic" 
                            ValidationExpression="\d+" 
                            ValidationGroup="practicas">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblEmail" runat="server" Text="Email:" CssClass="style3"></asp:Label>
                    </td>
                    <td class="style2">
                          <asp:TextBox ID="txtEmail" runat="server"  Width="150px" MaxLength="30"></asp:TextBox></td>
                    <td>
                          <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                            ErrorMessage="Ingrese el Email." 
                              ControlToValidate="txtEmail" ValidationGroup="practicas">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                            ErrorMessage="El correo es inválido." 
                            ControlToValidate="txtEmail" Display="Dynamic" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            ValidationGroup="practicas">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblValido" runat="server" Text="Habilitado:" CssClass="style3"></asp:Label>
                    </td>
                    <td class="style2">
                          <asp:CheckBox ID="chckValido" Checked=true runat="server" />
                    </td>
                    <td>
                          <asp:Button ID="btnHabilitar" runat="server" onclick="btnHabilitar_Click" 
                              Text="Cambiar Estado"  BackColor="Maroon" ForeColor="White" 
                              style="font-weight: 700" />
                    </td>
                </tr>
                <tr>
                    <td class="style4" colspan="2">
                        <br />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                            ValidationGroup="practicas" />
                    </td>
                    <td>
                          &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblError" runat="server" ForeColor="Red" 
                            Text="Email o Username existentes." Visible="False"></asp:Label>
                        </td>
                    <td class="style2">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        &nbsp;</td>
                    <td class="style2">
                        <uc1:usrCommand ID="usrCommand1" runat="server" OnOnGuardar="aceptarButton_Click"  OnOnCancelar="cancelarButton_Click" BotonAceptarTexto="GUARDAR" BotonCancelarTexto="CERRAR"/>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="3">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>



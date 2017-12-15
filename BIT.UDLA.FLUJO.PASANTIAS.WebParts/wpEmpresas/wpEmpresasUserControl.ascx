<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpEmpresasUserControl.ascx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpEmpresas.wpEmpresasUserControl" %>
<%@ Register src="../usrBuscador.ascx" tagname="usrBuscador" tagprefix="uc1" %>
<%@ Register src="../usrCommand.ascx" tagname="usrCommand" tagprefix="uc2" %>
<style type="text/css">

    .style1
    {
        width: 92%;
    }
    .style2
    {
        width: 150px;
    }
    .style4
    {
    }
    .style5
    {
        font-weight: bold;
    }
    .style6
    {
        width: 526px;
    }
    .style7
    {
        width: 23px;
    }
    .style8
    {
        font-weight: bold;
    }
</style>


<table style="width:500px;">
    <tr >
        <td>
            <table style="width:500px;">
                <tr id="trOfertas" runat="server" visible="false">
                    <td class="style4" colspan="3">
                  <table style="width:500px; height: 134px;">
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="Label1" runat="server" Text="Oferta:" CssClass="style5"></asp:Label>
                                </td>
                                <td class="style8">
                                    <asp:Label ID="lblOferta" runat="server" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="Label2" runat="server" Text="Modalidad:" CssClass="style5"></asp:Label>
                                </td>
                                <td class="style8">
                                    <asp:Label ID="lblModalidad" runat="server" Height="100%" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="Label3" runat="server" Text="Ciudad:" CssClass="style5"></asp:Label>
                                </td>
                                <td class="style8">
                                    <asp:Label ID="lblCiudad" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="Label5" runat="server" Text="Descripción del Cargo:" 
                                        CssClass="style5"></asp:Label>
                                </td>
                                <td class="style8">
                                    <asp:Label ID="lblDescripcion" runat="server" Height="100%" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="Label6" runat="server" Text="Perfil del Aspirante:" 
                                        CssClass="style5"></asp:Label>
                                </td>
                                <td class="style8">
                                    <asp:Label ID="lblPerfil" runat="server" Height="100%" Width="100%"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
              <%--  <tr>
                    <td class="style6">
                        <asp:Label ID="lblRuc" runat="server" Text="Ruc:" CssClass="style5"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:label ID="rucTextBox" runat="server" Width="267px" ReadOnly="True"></asp:label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblRazonSocial" runat="server" Text="Razon Social:" 
                            CssClass="style5"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:label ID="razonSocialTextBox" runat="server" Width="267px"></asp:label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>--%>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblNombreComercial" runat="server" Text="Razón Social:" 
                            CssClass="style5"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:label ID="nombreComercialTextBox" runat="server" Width="267px"></asp:label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
          <%--      <tr>
                    <td class="style6">
                        <asp:Label ID="lblRepresentanteLegal" runat="server" 
                            Text="Representante Legal:" CssClass="style5"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:label ID="representanteLegalTextBox" runat="server" Width="267px"></asp:label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblDireccion" runat="server" Text="Direccion:" CssClass="style5"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:label ID="direccionTextBox" runat="server" TextMode="MultiLine" Width="267px"></asp:label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblTelefono" runat="server" Text="Telefono:" CssClass="style5"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:label ID="telefonoTextBox" runat="server" Width="267px" MaxLength="20"></asp:label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>--%>



                <tr>
                    <td class="style6">
                        <asp:Label ID="areaLabel" runat="server" Text="Área de Práctica:" CssClass="style5"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="areaTextBox" runat="server" Width="267px" MaxLength="25"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="areaTextBox"
                          ErrorMessage="*" 
                            ValidationGroup="practicas" Display="Dynamic">*</asp:RequiredFieldValidator>
                    </td>
                </tr>



                <tr>
                    <td class="style6">
                        <asp:Label ID="lblNombreSupervisor" runat="server" 
                            Text="Nombre del Supervisor:" CssClass="style5"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="nombreSupervisorTextBox" runat="server" Width="267px" 
                            MaxLength="60"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvNombreSupervisor" runat="server" ControlToValidate="nombreSupervisorTextBox"
                         ErrorMessage="*" 
                            ValidationGroup="practicas" Display="Dynamic">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblTelefonoSupervisor" runat="server" 
                            Text="Teléfono Supervisor:" CssClass="style5"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="telefonoSupervisorTextBox" runat="server" Width="267px" 
                            MaxLength="15"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvTelefonoSupervisor" runat="server" ControlToValidate="telefonoSupervisorTextBox"
                           ErrorMessage="*" 
                            ValidationGroup="practicas" Display="Dynamic">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail0" runat="server" 
                            ErrorMessage="El teléfono es inválido." 
                            ControlToValidate="telefonoSupervisorTextBox" Display="Dynamic" 
                            ValidationExpression="\d+" 
                            ValidationGroup="practicas">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblEmailSupervisor" runat="server" Text="Email Supervisor:" 
                            CssClass="style5"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="emailSupervisorTextBox" runat="server" Width="267px" 
                            MaxLength="25"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvEmailSupervisor" runat="server" ControlToValidate="emailSupervisorTextBox"
                           ErrorMessage="*" 
                            ValidationGroup="practicas" Display="Dynamic">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                            ErrorMessage="El correo es inválido." 
                            ControlToValidate="emailSupervisorTextBox" Display="Dynamic" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            ValidationGroup="practicas">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        &nbsp;
                    </td>
                    <td class="style2">
                        <uc2:usrCommand ID="usrCommand1" runat="server" OnOnCancelar="btnCancelar_Click" BotonAceptarTexto ="APLICAR"
                            OnOnEliminar="btnEliminar_Click" OnOnGuardar="btnGuardar_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </td>
    </tr>
   
</table>




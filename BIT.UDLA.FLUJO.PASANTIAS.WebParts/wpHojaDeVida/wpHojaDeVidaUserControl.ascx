<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpHojaDeVidaUserControl.ascx.cs"
    Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpHojaDeVida.wpHojaDeVidaUserControl" %>
<%@ Register Src="../usrCommand.ascx" TagName="usrCommand" TagPrefix="uc1" %>
<%@ Register assembly="BIT.UDLA.FLUJOS.PASANTIAS.Comun, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7bf52b8cf62fe4fe" namespace="WimdowsControls.Web.UI" tagprefix="cc1" %>
<style type="text/css">
    .cedulamatrilog
    {
        font-family: Verdana, Arial, Helvetica, sans-serif;
        font-size: 12px;
        font-style: normal;
        line-height: normal;
        font-weight: bold;
        color: #800000;
        text-decoration: none;
        text-align: center;
        margin: 0px;
        padding: 0px;
    }
    
    .textoinstructivo
    {
        font-family: Verdana, Arial, Helvetica, sans-serif;
        font-size: 11px;
        font-style: normal;
        line-height: normal;
        font-weight: normal;
        color: #333333;
        text-decoration: none;
    }
    .link
    {
        font-family: Verdana, Arial, Helvetica, sans-serif;
        font-size: 11px;
        color: #666666;
        text-decoration: none;
    }
    .style2
    {
    }
    .style3
    {
    }
    .style4
    {
    }
    .style5
    {
        width: 107px;
    }
    .style6
    {
        width: 163px;
    }
    .style9
    {
        width: 129px;
    }
    .style12
    {
    }
    .style13
    {
        width: 23px;
    }
    .style16
    {
        font-family: Verdana, Arial, Helvetica, sans-serif;
        font-size: 12px;
        font-style: normal;
        line-height: normal;
        font-weight: bold;
        color: #800000;
        text-decoration: none;
        text-align: center;
        margin: 0px;
        padding: 0px;
    }
    .style7
    {
        width: 100%;
    }
    .style18
    {
        width: 127px;
    }
    .style19
    {
        width: 152px;
    }
    .style20
    {
        width: 129px;
        height: 29px;
    }
    .style21
    {
        height: 29px;
    }
    .style22
    {
        width: 129px;
        height: 30px;
    }
    .style23
    {
        height: 30px;
    }
    </style>
<br />
<br />

<div style="width:664px; height: 857px;" >
<table style="height: 850px; width: 100%">
    <tr>
        <td colspan="2">
            <h4 class="style16">
                INFORMACIÓN PERSONAL</h4>
            <br />
        </td>
    </tr>
    <tr>
        <td colspan="2" style="background-color: #800000">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="nombresLabel" runat="server" Text="" Style="font-weight: 700; text-transform: uppercase" />&nbsp;
            <asp:Label ID="apellidosLabel" runat="server" Text="" Style="font-weight: 700; text-transform: uppercase" />
        </td>
    </tr>
    <tr>
        <td class="style9">
            <asp:Label ID="Label3" runat="server" Text="Cédula:" />
        </td>
        <td>
            <asp:Label ID="cedulaLabel" runat="server" Text="" />
          
        </td>
    </tr>
    <tr>
        <td class="style9">
            <asp:Label ID="Label5" runat="server" Text="Matrícula:" />
        </td>
        <td>
            <asp:Label ID="matriculaLabel" runat="server" Text="" />
        </td>
    </tr>
    <tr>
        <td class="style9">
            <asp:Label ID="Label7" runat="server" Text="Dirección:" CssClass="style2" />
        </td>
        <td>
             <cc1:RequiredTextBox ID="direccionLabel" runat="server" Text="" Height="56px" MaxLength="255"
                Width="229px" />
                <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" 
                ControlToValidate="direccionLabel" Display="Dynamic" 
                ErrorMessage="La dirección es requerida." ValidationGroup="practicas">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style9">
            <asp:Label ID="Label9" runat="server" Text="Teléfono:" CssClass="style2" />
        </td>
        <td>
            <asp:TextBox ID="telefonoLabel" runat="server" Text="" MaxLength="20" Width="230px" />
            <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" 
                ControlToValidate="telefonoLabel" Display="Dynamic" 
                ErrorMessage="El teléfono es requerido." ValidationGroup="practicas">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revTelefono" runat="server" 
                            ErrorMessage="El teléfono es inválido." 
                            ControlToValidate="telefonoLabel" Display="Dynamic" 
                            ValidationExpression="\d+" 
                            ValidationGroup="practicas">*</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="style9">
            <asp:Label ID="Label11" runat="server" Text="Celular:" CssClass="style2" />
        </td>
        <td>
            <asp:TextBox ID="celularLabel" runat="server" Text="" MaxLength="20" Width="229px" />
            <asp:RequiredFieldValidator ID="rfvCelular" runat="server" 
                ControlToValidate="celularLabel" Display="Dynamic" 
                ErrorMessage="El teléfono celular es requerido." 
                ValidationGroup="practicas">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revTelefono1" runat="server" 
                            ErrorMessage="El teléfono celular es inválido." 
                            ControlToValidate="celularLabel" Display="Dynamic" 
                            ValidationExpression="\d+" 
                            ValidationGroup="practicas">*</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="style20">
            <asp:Label ID="Label13" runat="server" Text="Ciudad:" CssClass="style2" />
        </td>
        <td class="style21">
            <asp:DropDownList ID="ddlCiudad" runat="server"  Width="229px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style20">
            <asp:Label ID="Label15" runat="server" Text="Género:" CssClass="style2" />
        </td>
        <td class="style21">
            <asp:DropDownList ID="ddlGenero" runat="server" Width="229px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style9">
            <asp:Label ID="Label17" runat="server" Text="Fecha de Nacimiento: " CssClass="style2" />
        </td>
        <td>
            <asp:Label ID="fechaNacimientoLabel" runat="server" Text="" />
        </td>
    </tr>
    <tr>
        <td class="style9">
            <asp:Label ID="Label41" runat="server" Text="Email:" CssClass="style2" />
        </td>
        <td>
            <asp:TextBox ID="emailLabel" runat="server" Text="" Width="229px" />
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                ControlToValidate="emailLabel" Display="Dynamic" 
                ErrorMessage="El email es requerido." ValidationGroup="practicas">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                            ErrorMessage="El email es inválido." 
                            ControlToValidate="emailLabel" Display="Dynamic" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            ValidationGroup="practicas">*</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="style22">
            Estoy interesado en:
        </td>
        <td class="style23">
            <asp:DropDownList ID="interesDropDownList" runat="server" Width="232px">
            </asp:DropDownList>
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                ControlToValidate="interesDropDownList" Display="Dynamic" 
                ErrorMessage="El campo &quot;Estoy interesado en&quot; es obligatorio." 
                Operator="NotEqual" ValueToCompare="-1" ValidationGroup="practicas">*</asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td class="style22">
            Disponibilidad:
        </td>
        <td class="style23">
            <asp:DropDownList ID="disponibilidadDropDownList" runat="server" Width="232px">
            </asp:DropDownList>
            <asp:CompareValidator ID="cmpValDisponibilidad" runat="server" 
                ControlToValidate="disponibilidadDropDownList" Display="Dynamic" 
                ErrorMessage="El campo &quot;Disponibilidad en&quot; es obligatorio." 
                Operator="NotEqual" ValueToCompare="-1" ValidationGroup="practicas">*</asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td class="style22">
            Nivel de Empleo:
        </td>
        <td class="style23">
            <asp:DropDownList ID="nivelEmpleoDropDownList" runat="server" Width="232px">
            </asp:DropDownList>
            <asp:CompareValidator ID="cmpNivelEmpleo" runat="server" 
                ControlToValidate="nivelEmpleoDropDownList" Display="Dynamic" 
                ErrorMessage="El campo &quot;Nivel de Empleo&quot; es obligatorio." 
                Operator="NotEqual" ValueToCompare="-1" ValidationGroup="practicas">*</asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td class="style22">
            Modalidad:
        </td>
        <td class="style23">
            <asp:DropDownList ID="modalidadDropDownList" runat="server" Width="232px">
            </asp:DropDownList>
            <asp:CompareValidator ID="cmpModalidad" runat="server" 
                ControlToValidate="modalidadDropDownList" Display="Dynamic" 
                ErrorMessage="El campo &quot;Modalidad&quot; es obligatorio." 
                Operator="NotEqual" ValueToCompare="-1" ValidationGroup="practicas">*</asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td class="style22">
            Aspiración Salarial:
        </td>
        <td class="style23">
            <asp:DropDownList ID="aspiracionDropDownList" runat="server" Width="232px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style9">
            Objetivo Personal:
        </td>
        <td>
            <cc1:RequiredTextBox ID="objetivoTextBox" runat="server" TextMode="MultiLine"  MaxLength="1024"
                Width="229px"></cc1:RequiredTextBox>
        </td>
    </tr>
    <tr>
        <td class="style9">
            Meritos:
        </td>
        <td>
            <cc1:RequiredTextBox ID="meritosTextBox" runat="server" TextMode="MultiLine"  MaxLength="1024"
                Width="229px"></cc1:RequiredTextBox>
        </td>
    </tr>
    <tr>
        <td class="style9">
            Otras Actividades:
        </td>
        <td>
            <cc1:RequiredTextBox ID="otrasActividadesTextBox" runat="server" TextMode="MultiLine" 
                Width="229px" MaxLength="255"></cc1:RequiredTextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="background-color: #800000">
            <br />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table class="style7">
                <tr>
                    <td colspan="4">
            <h4 class="style16">
                FORMACIÓN ACADÉMICA</h4>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="Label141" runat="server" Text="Estudios Universitarios:" 
                            style="font-weight: 700" />
                    </td>
                </tr>
                <tr>
                    <td class="style18">
                        <asp:Label ID="Label23" runat="server" Text="Carrera:" />
                    </td>
                    <td class="style19">
                        <asp:Label ID="lblCarrera" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label25" runat="server" Text="Nivel:" />
                    </td>
                    <td>
                        <asp:DropDownList ID="nivel1Carreradrp" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style18">
                        <asp:Label ID="Label27" runat="server" Text="Otra Carrera:" />
                    </td>
                    <td class="style19">
                        <asp:TextBox ID="txtOtraCarrera" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label29" runat="server" Text="Nivel:" />
                    </td>
                    <td>
                        <asp:DropDownList ID="nivel2Carreradrp" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="Label142" runat="server" Text="Otros Estudios:" 
                            style="font-weight: 700" />
                    </td>
                </tr>
                <tr>
                    <td class="style18">
                        <asp:Label ID="Label19" runat="server" Text="Carrera:" />
                    </td>
                    <td class="style19">
                        <asp:DropDownList ID="otrosEstudiosCarreraDropDownList" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label21" runat="server" Text="Nivel:" />
                    </td>
                    <td>
                        <asp:DropDownList ID="aniosEstudiosDropDownList" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style18">
                        <asp:Label ID="Label139" runat="server" Text="En:" />
                    </td>
                    <td class="style19">
                        <asp:TextBox ID="estudiosEnTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style18">
                        <asp:Label ID="Label140" runat="server" Text="Institución:" />
                    </td>
                    <td class="style19">
                        <asp:TextBox ID="institucionTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
</table>

</div>
<br />
<table style="width:664px">
    <tr>
        <td  colspan="5" >
            &nbsp;</td>
    </tr>
    <tr>
        <td  colspan="5" style="background-color: #800000">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style12" colspan="5">
            <h4 class="style16">
                IDIOMAS</h4>
        </td>
    </tr>
    <tr>
        <td class="style18">
            <asp:Label ID="label30" runat="server" Text="Español:" />
        </td>
        <td class="style3" colspan="2">
            <asp:DropDownList ID="espaniolDropDownList" runat="server" Width="100px" />
        </td>
        <td>
            <asp:Label ID="label33" runat="server" Text="Inglés:" />
        </td>
        <td>
            <asp:DropDownList ID="inglesDropDownList" runat="server" Width="100px" />
        </td>
    </tr>
    <tr>
        <td class="style18">
            <asp:Label ID="label1" runat="server" Text="Francés:" />
        </td>
        <td class="style3">
            <asp:DropDownList ID="francesDropDownList" runat="server" Width="100px" />
        </td>
        <td class="style13">
            &nbsp;
        </td>
        <td>
            <asp:Label ID="label4" runat="server" Text="Alemán:" />
        </td>
        <td>
            <asp:DropDownList ID="alemanDropDownList" runat="server" Width="100px" />
        </td>
    </tr>
    <tr>
        <td class="style18">
            <asp:Label ID="label8" runat="server" Text="Otro:" />
        </td>
        <td class="style3">
            <asp:TextBox ID="txtOtroIdioma" runat="server" MaxLength="20"></asp:TextBox>
        </td>
        <td class="style13">
            &nbsp;</td>
        <td>
            <asp:DropDownList ID="otroIdiomaDropDownList" runat="server" Width="100px" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td  colspan="5" style="background-color: #800000">
            &nbsp;</td>
    </tr>
    </table>

<table width="500px" >
    <tr>
        <td class="style4" colspan="4">
            <h4 class="cedulamatrilog">
                EXPERIENCIA LABORAL</h4>
        </td>
    </tr>
    <tr>
        <td class="style5">
            <asp:Label ID="label2" runat="server" Text="Última empresa:" />
        </td>
        <td class="style6">
            <asp:TextBox ID="empresa1Label" runat="server" Text="" Width="175px" MaxLength="80" />
        </td>
        <td class="style5">
            <asp:Label ID="label10" runat="server" Text="Cargo:" />
        </td>
        <td>
            <asp:TextBox ID="cargo1Label" runat="server" Text="" Width="175px" MaxLength="80" />
        </td>
    </tr>
    <tr>
        <td class="style5">
            <asp:Label ID="label14" runat="server" Text="Jefe inmediato:" />
        </td>
        <td class="style6">
            <asp:TextBox ID="jefe1Label" runat="server" Text="" Width="175px" MaxLength="50" />
        </td>
        <td class="style5">
            <asp:Label ID="label18" runat="server" Text="Teléfono:" />
        </td>
        <td>
            <asp:TextBox ID="telefono1Label" runat="server" Text="" Width="175px" MaxLength="30" />
                        <asp:RegularExpressionValidator ID="revTelefono4" runat="server" 
                            ErrorMessage="El teléfono es inválido." 
                            ControlToValidate="telefono1Label" Display="Dynamic" 
                            ValidationExpression="\d+" 
                            ValidationGroup="practicas">*</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="style5">
            <asp:Label ID="label22" runat="server" Text="Fecha de Inicio:" />
        </td>
        <td class="style6">
            <SharePoint:DateTimeControl ID="fechaInicio1Label" runat="server" DateOnly="true" />
        </td>
        <td class="style5">
            <asp:Label ID="label26" runat="server" Text="Fecha de Salida:" />
        </td>
        <td>
            <SharePoint:DateTimeControl ID="FechaSalida1Label" runat="server" DateOnly="true" />
        </td>
    </tr>
    <tr>
        <td class="style5">
            <asp:Label ID="label31" runat="server" Text="Responsabilidades:" />
        </td>
        <td class="style6">
            <cc1:RequiredTextBox ID="responsabilidades1Label" runat="server" Text="" Height="22px" Width="175px"
                TextMode="MultiLine" MaxLength="1024" />
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <br />
        </td>
    </tr>
    <tr>
        <td class="style5">
            <asp:Label ID="label6" runat="server" Text="Empresa Anterior:" />
        </td>
        <td class="style6">
            <asp:TextBox ID="empresa2Label" runat="server" Text="" Width="175px" MaxLength="80" />
        </td>
        <td class="style5">
            <asp:Label ID="label20" runat="server" Text="Cargo:" />
        </td>
        <td>
            <asp:TextBox ID="cargo2Label" runat="server" Text="" Width="175px" MaxLength="80" />
        </td>
    </tr>
    <tr>
        <td class="style5">
            <asp:Label ID="label24" runat="server" Text="Jefe inmediato:" />
        </td>
        <td class="style6">
            <asp:TextBox ID="jefe2Label" runat="server" Text="" Width="175px" MaxLength="50" />
        </td>
        <td class="style5">
            <asp:Label ID="label28" runat="server" Text="Teléfono:" />
        </td>
        <td>
            <asp:TextBox ID="telefono2Label" runat="server" Text="" Width="175px" MaxLength="30" />
                        <asp:RegularExpressionValidator ID="revTelefono2" runat="server" 
                            ErrorMessage="El teléfono es inválido." 
                            ControlToValidate="telefono2Label" Display="Dynamic" 
                            ValidationExpression="\d+" 
                            ValidationGroup="practicas">*</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="style5">
            <asp:Label ID="label12" runat="server" Text="Fecha de Inicio:" />
        </td>
        <td class="style6">
            <SharePoint:DateTimeControl ID="fechaInicio2Label" runat="server" DateOnly="true" />
        </td>
        <td class="style5">
            <asp:Label ID="label16" runat="server" Text="Fecha de Salida:" />
        </td>
        <td>
            <SharePoint:DateTimeControl ID="FechaSalida2Label" runat="server" DateOnly="true" />
        </td>
    </tr>
    <tr>
        <td class="style5">
            <asp:Label ID="label32" runat="server" Text="Responsabilidades:" />
        </td>
        <td class="style6">
            <cc1:RequiredTextBox ID="responsabilidades2Label" runat="server" Text="" Height="22px" Width="175px"
                TextMode="MultiLine" MaxLength="1024" />
            <br />
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <br />
        </td>
    </tr>
    <tr>
        <td class="style5">
            <asp:Label ID="label34" runat="server" Text="Otra empresa:" />
        </td>
        <td class="style6">
            <asp:TextBox ID="empresa3Label" runat="server" Text="" Width="175px" MaxLength="80" />
        </td>
        <td class="style5">
            <asp:Label ID="label35" runat="server" Text="Cargo:" />
        </td>
        <td>
            <asp:TextBox ID="cargo3Label" runat="server" Text="" Width="175px" MaxLength="80" />
        </td>
    </tr>
    <tr>
        <td class="style5">
            <asp:Label ID="label36" runat="server" Text="Jefe inmediato:" />
        </td>
        <td class="style6">
            <asp:TextBox ID="jefe3Label" runat="server" Text="" Width="175px" MaxLength="50" />
        </td>
        <td class="style5">
            <asp:Label ID="label38" runat="server" Text="Teléfono:" />
        </td>
        <td>
            <asp:TextBox ID="telefono3Label" runat="server" Text="" Width="175px" MaxLength="30" />
                        <asp:RegularExpressionValidator ID="revTelefono3" runat="server" 
                            ErrorMessage="El teléfono es inválido." 
                            ControlToValidate="telefono3Label" Display="Dynamic" 
                            ValidationExpression="\d+" 
                            ValidationGroup="practicas">*</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="style5">
            <asp:Label ID="label37" runat="server" Text="Fecha de Inicio:" />
        </td>
        <td class="style6">
            <SharePoint:DateTimeControl ID="fechaInicio3Label" runat="server" DateOnly="true" />
        </td>
        <td class="style5">
            <asp:Label ID="label138" runat="server" Text="Fecha de Salida:" />
        </td>
        <td>
            <SharePoint:DateTimeControl ID="FechaSalida3Label" runat="server" DateOnly="true" />
        </td>
    </tr>
    <tr>
        <td class="style5">
            <asp:Label ID="label39" runat="server" Text="Responsabilidades:" />
        </td>
        <td colspan="2">
           <cc1:RequiredTextBox ID="responsabilidades3Label" runat="server" Text="" Height="22px" Width="175px"
                TextMode="MultiLine" MaxLength="1024" />
            <br />
        </td>
    </tr>
    <tr>
        <td class="style4" colspan="3">
            <asp:ValidationSummary ID="valSummary" runat="server" 
                ValidationGroup="practicas" />
        </td>
    </tr>
    <tr>

        <td class="style4">
            <asp:Button ID="guardarButton" runat="server" Text="CONTINUAR" 
                OnClick="guardarButton_Click"  BackColor="Maroon" ForeColor="White" 
                style="font-weight: 700" ValidationGroup="practicas" />
        </td>
    </tr>
</table>

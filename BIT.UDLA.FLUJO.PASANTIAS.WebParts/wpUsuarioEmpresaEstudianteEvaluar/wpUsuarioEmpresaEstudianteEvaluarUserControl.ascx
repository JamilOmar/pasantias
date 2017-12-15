<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpUsuarioEmpresaEstudianteEvaluarUserControl.ascx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpUsuarioEmpresaEstudianteEvaluar.wpUsuarioEmpresaEstudianteEvaluarUserControl" %>
<%@ Register src="../usrCommand.ascx" tagname="usrCommand" tagprefix="uc2" %>
<%@ Register assembly="BIT.UDLA.FLUJOS.PASANTIAS.Comun, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7bf52b8cf62fe4fe" namespace="WimdowsControls.Web.UI" tagprefix="cc1" %>


    <style type="text/css">
        .style2
        {
            font-weight: bold;
        }
    </style>

    <asp:Panel ID="pnlEmpresasUno" runat="server">
       <table>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Posición o cargo:" 
                    CssClass="style2"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="cargoTextBox" runat="server" Text="" MaxLength="50"
                    Width="291px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCargo" runat="server" 
                    ControlToValidate="cargoTextBox" ErrorMessage="Ingrese &quot;Posición o cargo&quot;." 
                    ValidationGroup="practicas" Display="Dynamic">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Área de trabajo o práctica:" 
                    CssClass="style2"></asp:Label>
            </td>
            <td>
         
                <asp:TextBox ID="areaTrabajoTextBox" runat="server" Text=""  
                    Width="291px" Rows="6"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAreaTrabajo" runat="server" 
                    ControlToValidate="areaTrabajoTextBox" ErrorMessage="Ingrese &quot;Área de trabajo o práctica&quot;." 
                    ValidationGroup="practicas" Display="Dynamic">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="Funciones:" CssClass="style2"></asp:Label>
            </td>
            <td>
                 <cc1:RequiredTextBox ID="funcionesTextBox" runat="server" Text=""  TextMode="MultiLine" 
                    Height="90px" Width="291px" Rows="6"  MaxLines="6"  />
                <asp:RequiredFieldValidator ID="rfvFunciones" runat="server" 
                    ControlToValidate="funcionesTextBox" ErrorMessage="Ingrese &quot;Funciones&quot;." 
                    ValidationGroup="practicas" Display="Dynamic">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label11" runat="server" Text="Fecha Inicio:" CssClass="style2"></asp:Label>
            </td>
            <td>
                <SharePoint:DateTimeControl ID="fechaInicioCalendar" runat="server" 
                    DateOnly="True"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label13" runat="server" Text="Fecha Fin:" CssClass="style2"></asp:Label>
            </td>
            <td>
                <SharePoint:DateTimeControl  runat="server" ID="fechaFinCalendar" DateOnly="true" />
            </td>
        </tr>
       
        <tr>
            <td>
                <asp:Label ID="Label15" runat="server" Text="Horario de trabajo o práctica:" 
                    CssClass="style2"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="horarioTrabajoDropDownList" runat="server">
                    <asp:ListItem>Medio tiempo</asp:ListItem>
                    <asp:ListItem>Tiempo Completo</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label17" runat="server" Text="Número de horas de trabajo o práctica:" 
                    CssClass="style2"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNumeroHorasEjecutadasEmpresa" runat="server" Text="0" 
                    MaxLength="4"></asp:TextBox>
                <asp:CompareValidator ID="cmpValidador" runat="server" 
                    ControlToValidate="txtNumeroHorasEjecutadasEmpresa" Display="Dynamic" 
                    
                    ErrorMessage="Ingrese solo números en &quot;Número de horas de trabajo o práctica&quot;." 
                    Operator="DataTypeCheck" Type="Integer" 
                    ValidationGroup="practicas">*</asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToValidate="txtNumeroHorasEjecutadasEmpresa" 
                    
                    ErrorMessage="El número debe ser mayor que 0, en &quot;Número de horas de trabajo o práctica&quot;." Operator="GreaterThan" 
                    Type="Integer" ValidationGroup="practicas" ValueToCompare="0">*</asp:CompareValidator>
                <asp:RequiredFieldValidator ID="rfvHorasEmpresa" runat="server" 
                    ControlToValidate="txtNumeroHorasEjecutadasEmpresa" 
                    ErrorMessage="Ingrese &quot;Número de horas de trabajo o práctica&quot;." 
                    ValidationGroup="practicas">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server" EnableViewState="False" 
                    style="color: #FF0000" Text="Verifique las Fechas Ingresadas" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Panel>
   <asp:Panel ID="pnlTutoresUno" runat="server" 
    GroupingText="Confirmación de Horas por Parte del Tutor">
      <table>
        <tr>
            <td>
                <asp:Label ID="Label22" runat="server" Text="Número de horas aprobadas:" 
                    CssClass="style2"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNumeroHorasEjecutarTutor" runat="server" Text="0" 
                    MaxLength="4"></asp:TextBox>
                <asp:CompareValidator ID="cmpValHorasEjecutarTutor" runat="server" 
                    ControlToValidate="txtNumeroHorasEjecutarTutor" Display="Dynamic" 
                    
                    ErrorMessage="Ingrese solo números en &quot;Número de horas aprobadas&quot;." 
                    Operator="DataTypeCheck" Type="Integer" 
                    ValidationGroup="practicas">*</asp:CompareValidator>
                <asp:CompareValidator ID="cmpValTutor" runat="server" 
                    ControlToValidate="txtNumeroHorasEjecutarTutor" 
                    ErrorMessage="El número debe ser mayor que 0, en &quot;Número de horas aprobadas&quot;." Operator="GreaterThan" 
                    Type="Integer" ValidationGroup="practicas" ValueToCompare="0">*</asp:CompareValidator><asp:RequiredFieldValidator
                        ID="rfvHorasTutor" runat="server" 
                     ErrorMessage="Ingrese &quot;Número de horas aprobadas&quot;." 
                    ControlToValidate="txtNumeroHorasEjecutarTutor" 
                    ValidationGroup="practicas">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Panel>
   <asp:Panel ID="pnlEmpresasDos" runat="server">
     <table>
 <tr>
            <td>
                <asp:Label ID="Label18" runat="server" Text="Confirmación de Fin de Práctica:" 
                    CssClass="style2"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chckConfirmacion" runat="server" />
            </td>
        </tr>
         <tr>
             <td>
                 <asp:Label ID="lblErrorRegistro" runat="server" EnableViewState="False" 
                     style="color: #FF0000" Text="Realize la confirmación" 
                     Visible="False"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
    </table>
</asp:Panel>
 
                <asp:ValidationSummary ID="valSumary" runat="server" 
    ValidationGroup="practicas" />
 
                <uc2:usrCommand ID="procesarUsrCommand" runat="server" OnOnCancelar="cancelarButton_Click" OnOnGuardar="aceptarButton_Click" OnOnEliminar="btnCancelarFlujo_Click" />
            
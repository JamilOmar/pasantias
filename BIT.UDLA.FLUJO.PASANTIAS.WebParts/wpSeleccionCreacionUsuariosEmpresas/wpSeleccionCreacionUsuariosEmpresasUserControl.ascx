<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpSeleccionCreacionUsuariosEmpresasUserControl.ascx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpSeleccionCreacionUsuariosEmpresas.wpSeleccionCreacionUsuariosEmpresasUserControl" %>
<%@ Register src="../usrPager.ascx" tagname="usrPager" tagprefix="uc1" %>
<%@ Register src="../usrCommand.ascx" tagname="usrCommand" tagprefix="uc2" %>


<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 155px;
    }
    .style3
    {
        font-weight: bold;
    }
    .style4
    {
        width: 20%;
    }
</style>
<script type="text/javascript">
    function OpenDialog(URL, local) {
        var NewPopUp = SP.UI.$create_DialogOptions();
        NewPopUp.url = URL;
        NewPopUp.width = 500;
        NewPopUp.height = 500;
        NewPopUp.dialogReturnValueCallback =
        Function.createDelegate(null, function (result, returnValue) {
            if (result == SP.UI.DialogResult.OK) {
                if (returnValue == null) {
                    SP.UI.Notify.addNotification('Operación Exitosa');
                    if (local != '')
                        location.href = local;
                }
                
            }
        });
        SP.UI.ModalDialog.showModalDialog(NewPopUp);
    }
 </script>




 <table class="style1">
  <tr >
        <td>
                  <a runat="server" id="hlNuevaAsistencia"  style="color: #3333CC; text-decoration: underline; font-weight: 700; cursor:hand">Nuevo Usuario</a>
            
        </td>
    </tr>
    <tr>
        <td>
    <asp:GridView ID="grdUsuarios" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" EnableModelValidation="True" ForeColor="#333333" 
                GridLines="None" >
    <AlternatingRowStyle CssClass="ms-alternating" BackColor="White" />
    <Columns>
        <asp:TemplateField HeaderText="Nombre Completo">
              <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Nombre")+ " " + Eval("Apellido")   %>'></asp:Label>
            </ItemTemplate>
      
        </asp:TemplateField>
        

         <asp:TemplateField HeaderText="UserName">
            
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("UserName")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Habilitado">
            
            <ItemTemplate>
                <asp:CheckBox ID="chck" runat="server" Enabled=false Checked='<%# Eval("EsValido") %>'></asp:CheckBox>
            </ItemTemplate>
        </asp:TemplateField>
       
        <asp:TemplateField HeaderText="Editar">
                 <ItemTemplate>
                    <a href="<%# ObtenerLink(Eval("UniqueID")) %>" >Ver</a> 
            </ItemTemplate>
        </asp:TemplateField>
           <asp:TemplateField HeaderText="Seleccionar">
                 <ItemTemplate>
                <asp:LinkButton ID="lnkbtnSeleccion" runat="server" 
    oncommand="lnkbtnSeleccion_Command" CommandArgument='<%# Eval("UniqueID") %>'>Elegir Usuario</asp:LinkButton>

            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
        <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
</asp:GridView>
<p style="width:400px; margin:0">
 <uc1:usrPager ID="usrPagerActividades" runat="server" NumeroItemsPorPagina="10" 
    OnAdelante ="lnkAdelante_Click" OnAtras="lnkAtras_Click" />
</p>

        </td>
    </tr>
    </table>

<h4>
    Usuario Seleccionado</h4>

            <table class="style1">
                <tr>
                    <td class="style2">
                        <asp:Label ID="Label4" runat="server" Text="Nombre:" CssClass="style3"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="Label5" runat="server" Text="Usuario:" CssClass="style3"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUsername" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
           
                </table>

            

<p>
                        <asp:Label ID="lblError" runat="server" ForeColor="Red" 
                            Text="Seleccione un Usuario" Visible="False" EnableViewState="False"></asp:Label>
                        <br />
                        <asp:Label ID="lblErrorAsignacion" runat="server" ForeColor="Red" 
                            Text="Verifica que el usuario seleccionado se encuentre habilitado y cumpla los riquisitos mínimos." Visible="False" EnableViewState="False"></asp:Label>
                    </p>
<table class="style4">
    <tr>
        <td>
                        <uc2:usrCommand ID="usrCommand1" runat="server" OnOnGuardar="aceptarButton_Click" BotonAceptarTexto="GUARDAR" BotonCancelarTexto="CERRAR" OnOnCancelar="cancelarButton_Click" />
                    </td>
    </tr>
</table>


            


<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpCursosUserControl.ascx.cs"
    Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpCursos.wpCursosUserControl" %>

<script type="text/javascript">
    function OpenDialog(URL, local) {
        var NewPopUp = SP.UI.$create_DialogOptions();
        NewPopUp.url = URL;
        NewPopUp.width = 500;
        NewPopUp.height = 400;
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



 <h2>
     Cursos y seminarios</h2>
<br />


  <a runat="server" id="hlNuevoCurso"  style="color: #3333CC; text-decoration: underline; font-weight: 700; cursor:hand">Nuevo Curso</a>

<asp:GridView ID="cursosSPGrid" runat="server" AutoGenerateColumns="False" 
    CellPadding="4" EnableModelValidation="True" ForeColor="#333333" 
    GridLines="None" PageSize="50">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:TemplateField HeaderText="Curso">
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Institución">
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Institucion") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fecha">
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# ToDateTimeFormat(Eval("Fecha")) %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Duración">
            <ItemTemplate>
                <asp:Label ID="chck" runat="server" Text='<%# Eval("Duracion") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Editar">
            <ItemTemplate>
                <a href="<%# ObtenerLink(Eval("Id"))  %>">Ver</a>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Eliminar">
            <ItemTemplate>
                <asp:LinkButton ID="lnkbtnSeleccion" runat="server" OnCommand="lnkbtnSeleccion_Command"
                    CommandArgument='<%# Eval("Id") %>'>Borrar ítem</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
</asp:GridView>

<p>
            <asp:Button ID="guardarButton" runat="server" Text="CONTINUAR" OnClick="guardarButton_Click"  BackColor="Maroon" ForeColor="White" style="font-weight: 700" />
        </p>



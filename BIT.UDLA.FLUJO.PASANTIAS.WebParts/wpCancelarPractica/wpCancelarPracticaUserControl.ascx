<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpCancelarPracticaUserControl.ascx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpCancelarPractica.wpCancelarPracticaUserControl" %>
<%@ Register src="../usrPager.ascx" tagname="usrPager" tagprefix="uc1" %>
<script type="text/javascript">
    function OpenDialog(URL, local) {
        var NewPopUp = SP.UI.$create_DialogOptions();
        NewPopUp.url = URL;
        NewPopUp.width = 500;
        NewPopUp.height = 300;
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
 
<asp:GridView ID="grdPasantias" runat="server" 
    AutoGenerateColumns="False" PageSize="5" CellPadding="4" 
    EnableModelValidation="True" ForeColor="#333333" GridLines="None" >
 
    <AlternatingRowStyle BackColor="White" />
 
    <Columns>
        <asp:TemplateField HeaderText="Estudiante">
              <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("NombreSaes") %>'></asp:Label>
            </ItemTemplate>
      
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Empresa">
            
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Empresa") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
               <asp:TemplateField HeaderText="Carrera">
            
            <ItemTemplate>
                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Carrera") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Materia">
            
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Materia") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
           <asp:TemplateField HeaderText="Nivel">
            
            <ItemTemplate>
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Nivel") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
           <asp:TemplateField HeaderText="Tutor">
            
            <ItemTemplate>
                <asp:Label ID="Label6" runat="server" Text='<%# Eval("NombreTutorSAES") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
           <asp:TemplateField HeaderText="Docente">
            
            <ItemTemplate>
                <asp:Label ID="Label7" runat="server" Text='<%# Eval("NombreDocenteSAES") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Supervisor">
            
            <ItemTemplate>
                <asp:Label ID="Label7" runat="server" Text='<%# Eval("NombreSupervisor") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        
       
        <asp:TemplateField HeaderText="Cancelar">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </EditItemTemplate>
                 <ItemTemplate>
                    <a href="<%# ObtenerLink(Eval("Id")) %>" >Ver</a> 
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    <SelectedRowStyle CssClass="ms-selectednav" Font-Bold="True" 
        BackColor="#FFCC66" ForeColor="Navy" />
 </asp:GridView>
<uc1:usrPager ID="usrPager1" runat="server" OnAdelante="lnkAdelante_Click" NumeroItemsPorPagina="5" OnAtras="lnkAtras_Click" />

<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpConSupervisionUserControl.ascx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpConSupervision.wpConSupervisionUserControl" %>
<%@ Register src="../usrPager.ascx" tagname="usrPager" tagprefix="uc1" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>
<script type="text/javascript">
    function OpenDialog(URL ,local) {
        var NewPopUp = SP.UI.$create_DialogOptions();
        NewPopUp.url = URL;
        NewPopUp.width = 500;
        NewPopUp.height = 300;
        NewPopUp.dialogReturnValueCallback =
        Function.createDelegate(null, function (result, returnValue) {
            if (result == SP.UI.DialogResult.OK) {
                if (returnValue == null) {
                    SP.UI.Notify.addNotification('Operación Exitosa');
                    if(local!='')
                    location.href = local;
                }
               
            }
        }); 
        SP.UI.ModalDialog.showModalDialog(NewPopUp);
    }
 </script>
 <h2>Registro de Actividades y Asistencia</h2>
  <table class="style1">
  <tr runat=server id="trAsistenciaInsert">
        <td>
         <a runat="server" id="hlNuevaAsistencia"  style="color: #3333CC; text-decoration: underline; font-weight: 700; cursor:hand">Nueva Asistencia</a>
        </td>
    </tr>
    <tr>
        <td>
       <asp:GridView ID="grdAsistencia" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                CellPadding="4" EnableModelValidation="True" >
    <AlternatingRowStyle CssClass="ms-alternating" />
    <Columns>
        <asp:TemplateField HeaderText="Desde">
              <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# ToDateTimeFormat(Eval("FechaInicio")) %>'></asp:Label>
            </ItemTemplate>
      
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Hasta">
            
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# ToDateTimeFormat(Eval("FechaFin")) %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Actividades">
            
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Actividad") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
       
        <asp:TemplateField HeaderText="">
                 <ItemTemplate>
                  <a href="<%# ObtenerLinkAsistencia(Eval("Id")) %>" >Ver</a> 
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
           <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
           <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
           <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
           <RowStyle BackColor="White" ForeColor="#330099" />
           <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
</asp:GridView>
 <p style="width:400px; margin:0">
            <uc1:usrPager ID="usrPagerActividades" runat="server" 
                NumeroItemsPorPagina="10" OnAdelante ="lnkAdelante_Click" OnAtras="lnkAtras_Click" />
 </p>
        </td>
    </tr>
    </table>
 <h2 id="titulo" runat="server">Registro de Visitas</h2>

<table class="style1">

    <tr runat="server" id="trVisitasInsert" >
        <td>
        <a runat="server" id="hlNuevaVisita"  style="color: #3333CC; text-decoration: underline; font-weight: 700; cursor:hand">Nueva Visita</a>
        </td>
    </tr>
     <tr runat="server" id="trVisitasGrid">
        <td>
          <asp:GridView ID="grdVisitas" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                CellPadding="4" EnableModelValidation="True" >
    <AlternatingRowStyle CssClass="ms-alternating" />
    <Columns>
        <asp:TemplateField HeaderText="Fecha">
              <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# ToDateTimeFormat(Eval("FechaVisita")) %>'></asp:Label>
            </ItemTemplate>
      
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Observaciones">
            
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Observaciones") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
       
         <asp:TemplateField HeaderText="">
           
           
                 <ItemTemplate>
                 <a href="<%# ObtenerLinkVisita(Eval("Id")) %>" >Ver</a> 
                    
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
              <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
              <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
              <RowStyle BackColor="White" ForeColor="#330099" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
</asp:GridView>
 <p style="width:400px; margin:0">
            <uc1:usrPager ID="usrPagerVisitas" runat="server" NumeroItemsPorPagina="10" OnAdelante ="lnkAdelanteVisita_Click" OnAtras="lnkAtrasVisita_Click" />
 </p>
        </td>
    </tr>
  
</table>

<asp:LinkButton ID="lnkGeneral" runat="server" Visible="False"  style="color: #3333CC; text-decoration: underline; font-weight: 700; cursor:hand"></asp:LinkButton>
<p>
    &nbsp;</p>



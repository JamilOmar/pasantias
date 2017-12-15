<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wcOfertasLaboralesUserControl.ascx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.wcOfertasLaborales.wcOfertasLaboralesUserControl" %>


<%@ Register src="../usrPager.ascx" tagname="usrPager" tagprefix="uc1" %>



<style type="text/css">
#hor-minimalist-a
{
	font-family: "Lucida Sans Unicode", "Lucida Grande", Sans-Serif;
	font-size: 12px;
	
	margin: 45px;
	width: 480px;
	border-collapse: collapse;
	text-align: left;
	
}
#hor-minimalist-a th
{
	font-size: 14px;
	font-weight: normal;
	padding: 10px 8px;
	border-bottom: 2px solid #6678b1;
	text-align:center;
}
#hor-minimalist-a td
{
	
	padding: 9px 8px 0px 8px;
}
#hor-minimalist-a tbody tr:hover td
{
	
}
</style>


  



<table id="hor-minimalist-a" summary="Employee Pay Sheet">
    <thead>
    	<tr>
        	<th scope="col" style="text-align:left">Oferta</th>
            <th scope="col" style="text-align:left">Empresa</th>
              <th scope="col" style="text-align:left">Fecha</th>
            <th scope="col">Acción</th>
        </tr>
    </thead>
    <tbody>
    <asp:Repeater ID="empresasListRepeater" runat="server">
        <ItemTemplate>
            <tr>
                <td style="width:45%">
                    <%#Eval("Titulo")%>
                </td>
                <td style="width:45%">
                    <%#Eval("Empresa")%>
                </td>
                 <td style="width:45%">
                    <%#ToDateTimeFormat(Eval("Fecha"))%>
                </td>
                <td style="width:10%; text-align:center">
                 <a href='<%#"InformacionEmpresas.aspx?ide="+Eval("EMP_ID")+"&modo=select&oferta=true&idPasantia="+IdPeticion.ToString() +"&ofertaID="+Eval("OFE_ID") %>'>Seleccionar</a>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
 <uc1:usrPager ID="usrPager1" runat="server" NumeroItemsPorPagina="10" 
    OnAdelante ="lnkAdelante_Click" OnAtras="lnkAtras_Click" />
    </tbody>
</table>





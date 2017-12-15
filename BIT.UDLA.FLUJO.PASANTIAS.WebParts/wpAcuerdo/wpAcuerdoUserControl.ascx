<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpAcuerdoUserControl.ascx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpAcuerdo.wpAcuerdoUserControl" %>
<script language="javascript">
	function showWaitScreen() {
		//When the app page is NOT in dialog mode window.frameElement will be null
		var parentObject = window.frameElement;
		if (parentObject == null) {
			parentObject = window;
		}

		parentObject.waitDialog = SP.UI.ModalDialog.showWaitScreenWithNoClose('Por favor espera.', 'En este momento se esta creando la Práctica Pre-Profesional.', 76, 330);
	}
    </script>
<asp:CheckBox ID="chckAceptar" runat="server" Text="Acepto" />

<p>
    <asp:Button ID="btnAceptar" OnClientClick="javascript:showWaitScreen();" runat="server" onclick="btnAceptar_Click" 
        Text="ACEPTAR" BackColor="Maroon" ForeColor="White" style="font-weight: 700" />
</p>


<asp:Label ID="lblMensaje" runat="server" />


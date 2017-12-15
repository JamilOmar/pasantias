<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpInformacionValidadorUserControl.ascx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpInformacionValidador.wpInformacionValidadorUserControl" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style3
    {
        width: 103px;
    }
    .style4
    {
        font-weight: bold;
        color: #800000;
    }
    .style5
    {
        font-weight: bold;
    }
    </style>

<table class="style1">
    <tr>
        <td class="style3">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
          
            <asp:Label ID="lblAlumno" runat="server" Text="Alumno:" CssClass="style4"></asp:Label>
          
        </td>
        <td>
            <asp:label ID="txtAlumno" ReadOnly=true runat="server" Width="525px" 
                CssClass="style5"></asp:label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
         
            <asp:Label ID="lblAlumno0" runat="server" Text="Cédula:" CssClass="style4"></asp:Label>
          
        </td>
        <td>
            <asp:label ID="txtCedula" ReadOnly=true runat="server" Width="525px" 
                CssClass="style5"></asp:label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
          
            <asp:Label ID="lblEmpresa" runat="server" Text="Empresa:" CssClass="style4"></asp:Label>
          
        </td>
        <td>
            <asp:label ID="txtEmpresa" ReadOnly=true runat="server" Width="523px" 
                CssClass="style5"></asp:label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
    
            <asp:Label ID="lblTipoPasantia" runat="server" Text="Tipo de Práctica:" 
                Width="120px" CssClass="style4"></asp:Label>
       
        </td>
        <td>
            <asp:label ID="txtTipoPasantia" ReadOnly=true runat="server" Width="521px" 
                CssClass="style5"></asp:label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>

<script type="text/javascript">
    javascript: window.history.forward(1);
    function ValidateLines(e, max, chrln) {
        var text = e.value; //.replace(/\s+$/g,"");
        var split = e.value.split("\n");
        if (max == 0)
            max = split.length;
        if (chrln == 0)
            chrln = text.length + 1;

        if (split.length <= max && text.length + 1 <= chrln) {
            return true;
        }
        else if (split.length >= max || e.value.length >= chrln) {
         event.returnValue = false;
         return false;
        }
 }
 function maxLengthPaste(field, max, chrln) {
   
     var total = field.value.length + window.clipboardData.getData("Text").length;
     var allText = field.value + window.clipboardData.getData("Text");
     var split = allText.split("\n");
     if (max == 0)
         max = split.length;
     if (chrln == 0)
         chrln = total + 1;

     if (split.length <= max && total + 1 <= chrln) {
            event.returnValue = true;
            return true;
        }
     if ( split.length >= max || total >= chrln) {
          event.returnValue = false;
         return false;
     }

 }  
 </script>
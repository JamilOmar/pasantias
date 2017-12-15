<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="BIT.UDLA.FLUJO.PASANTIAS.WebParts.Layouts.Login.LoginPage"%>
<head id="Head1" runat="server">
    <title>UDLA PRACTICAS PRE PROFESIONALES</title>
    <style type="text/css">
        .style4
        {
            width: 653px;
        }
        .style5
        {
            width: 33%;
        }
        .style6
        {
            color: #800000;
        }
        .style7
        {
            text-align: center;
            color: #800000;
        }
    </style>
</head>
<body style="height: 323px; width: 613px">
    <form id="form1" runat="server">
        <table style="width: 516px; height: 282px;">
            <tr>
                <td colspan="2">
                      <asp:Image ID="imgTop" runat="server" ImageUrl="/_layouts/Login/sis_pp_01.jpg" Width=596px />
                </td>
            </tr>
            <tr>
                <td class="style4">
                     <asp:ImageButton ID="imgEstudiante" runat="server" ImageUrl="/_layouts/Login/foto_estu.jpg"  Height="166px" />
                </td>
                <td class="style5">
                    <table class="style1">
                        <tr>

        <td class="style7" colspan="2">

            <strong>Ingresos de Empresas</strong></td>

    </tr>

                        <tr>

        <td>

            <strong style="color: #800000">Username</strong></td>

        <td>

            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>

        </td>

    </tr>

    <tr>

        <td class="style6">

            <strong>Password</strong></td>

        <td>

            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>

        </td>

    </tr>

    <tr>

        <td colspan="2">

            <asp:Label ID="lblError" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>

        </td>

    </tr>

    <tr>

        <td>

            &nbsp;</td>

        <td>

            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                Text="Ingresar" />

        </td>

    </tr>

</table>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style5">
                       <asp:HyperLink ID="HyperLink2" runat="server" 
                    NavigateUrl="http://bolsadeempleo.udla.edu.ec/inicio_emp.php?opm=1" 
                    style="color: #990000; font-weight: 700">Eres empresa Nueva?, registrate en Bolsa de Empleo!!!</asp:HyperLink></td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
        </table>
    

    </form>
</body>
</html>

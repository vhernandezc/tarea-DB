<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frminicio.aspx.cs" Inherits="tarea2_bd.frminicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="cargadatos" runat="server" OnClick="cargadatos_Click" Text="cargar a la DB" />
        <p>
            <asp:TextBox ID="TextBoxIDE" runat="server"></asp:TextBox>
            <asp:Button ID="BuscarIDE" runat="server" Text="Buscar por IDE" OnClick="BuscarIDE_Click" />
        </p>
        <asp:TextBox ID="TextBoxNOMBRE" runat="server" Width="206px"></asp:TextBox>
        <asp:Button ID="Buttonnombre" runat="server" OnClick="Buttonnombre_Click" style="margin-bottom: 0px" Text="Buscar por nombre" Width="132px" />
        <p>
            &nbsp;</p>
    </form>
</body>
</html>

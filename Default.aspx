<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YourNamespace.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Current Time and Weather for Singapore</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Current Time and Weather for Singapore</h1>
            <p>Current Time: <asp:Label ID="lblTime" runat="server"></asp:Label></p>
            <p>Current Weather: <asp:Label ID="lblWeather" runat="server"></asp:Label></p>
        </div>
    </form>
</body>
</html>
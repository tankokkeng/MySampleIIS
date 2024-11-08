<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YourNamespace.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Current Time, Weather, and Parking Availability for Singapore</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Current Time, Weather, and Parking Availability for Singapore</h1>
            <p>Current Time: <asp:Label ID="lblTime" runat="server"></asp:Label></p>
            <p>Current Weather: <asp:Label ID="lblWeather" runat="server"></asp:Label></p>
            <p>Parking Availability at Plaza Singapura: <asp:Label ID="lblParking" runat="server"></asp:Label></p>
        </div>
    </form>
</body>
</html>

﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainHost.aspx.cs" Inherits="MainWebHost.MainHost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button ID="btnGetOrders" runat="server" OnClick="btnGetOrders_Click" Text="Task 1 - Show List of Orders" />
            &nbsp;
            <asp:Button ID="btnShowOrderDetails" runat="server" OnClick="btnShowOrderDetails_Click" Text="Task 2 - Show Order Details" />
            <asp:TextBox ID="txtOrderId" runat="server" Width="82px"></asp:TextBox>
            <br />
            <br />
            <asp:GridView ID="grvAllOrders" runat="server">
            </asp:GridView>

        </div>
    </form>
</body>
</html>
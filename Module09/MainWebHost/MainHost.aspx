<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainHost.aspx.cs" Inherits="MainWebHost.MainHost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button ID="btnGetOrders" runat="server" OnClick="btnGetOrders_Click" Text="Task 1 - Show List of Orders" />
            <br />
            <asp:GridView ID="grvAllOrders" runat="server">
            </asp:GridView>

        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Task2InvalidationCache.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Invalidation Cache Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
        </p>
        <p>
            <asp:SqlDataSource id="Source1" runat="server" SelectCommand="SELECT * FROM [Categories]" UpdateCommand="UPDATE [Categories] SET [CategoryName]=@CategoryName,[Description]=@Description,[Picture]=@Picture WHERE [CategoryID]=@CategoryID" ConnectionString="<%$ ConnectionStrings:Northwind %>"></asp:SqlDataSource>
            <asp:GridView id="GridView1" runat="server" DataKeyNames="CategoryID" AllowSorting="True" AllowPaging="True" DataSourceID="Source1"></asp:GridView>
        </p>
        <p>
        </p>
        <p>
            <asp:Label id="CacheMsg" runat="server" AssociatedControlID="GridView1"></asp:Label>
        </p>
    </form>
</body>
</html>

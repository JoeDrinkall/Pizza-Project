<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="Pizza_Project.Pages.CreateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1 style="text-align: left">Nescot Pizza</h1>
        <br />
        <div>
            <asp:Label>Username:</asp:Label>
            <asp:TextBox runat="server" id="txtUsername"></asp:TextBox>
            <br />
            <asp:Label>Password</asp:Label>
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button runat="server" ID="btnCreateAccount" OnClick="btnCreateAccount_Click" Text="Create Account" />
            <asp:Label runat="server" ID ="lblUserExists" Text="There is already a user with this name" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>

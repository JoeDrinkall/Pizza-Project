<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pizza_Project.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="Username"></asp:Label>
            <asp:TextBox runat="server" ID="txtUsername"></asp:TextBox>
            <br /><br />
            <asp:Label runat="server" Text="Password"></asp:Label>
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
            <br /><br />
            <asp:Button runat="server" Text="Login" ID="btnLogin" OnClick="btnLogin_Click"/>
            <br /><br />
            <a href="CreateAccount.aspx">Create an Account</a>
        </div>
        <asp:label runat="server" id ="error" visible="false">
            Incorrect Username or Password
        </asp:label>
        
    </form>
</body>
</html>

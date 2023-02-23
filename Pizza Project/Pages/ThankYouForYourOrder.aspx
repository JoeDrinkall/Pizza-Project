<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThankYouForYourOrder.aspx.cs" Inherits="Pizza_Project.ThankYouForYourOrder" %>

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
            Thank you for your order, it will be ready shortly.
            <br />
            <br />
            Your order number is :<asp:Label runat="server" ID ="lblOrderNumber"></asp:Label>
        </div>
    </form>
</body>
</html>

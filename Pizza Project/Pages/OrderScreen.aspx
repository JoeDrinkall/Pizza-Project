<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderScreen.aspx.cs" Inherits="Pizza_Project.Order_Screen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
            margin-left: 160px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <h1 style="text-align: left">Nescot Pizza</h1>
            <table>
            <tr>
                <td>
                    <div style="float: right">
                        <asp:linkbutton runat="server" ID="btnViewBasket" OnClick="btnViewBasket_Click" font-size="Large"> View Basket</asp:linkbutton>
                        <asp:linkbutton runat="server" ID="btnViewStaffScreen" OnClick="btnViewStaffScreen_Click" font-size="Large" Visible="false">View Staff Screen</asp:linkbutton>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                    <tr>
                    <td style="padding-right:300px"><asp:Image ID="Image1" runat="server" Height="190px" ImageUrl="~/Images/Cheese-Pizza.jpg" Width="200px"/></td>
                    <td style="padding-right:300px"> <asp:Image ID="Image2" runat="server" Height="193px" ImageUrl="~/Images/pepperoni_cheese_pizza.jpg" Width="232px" /></td>
                    </tr>            
                    <tr>
                    <td style="padding-right:300px">Cheese Pizza - £3.60</td>
                    <td style="padding-right:300px">Pepperoni Pizza - £3.80</td>            
                    </tr>
                    <tr>
                    <td style="padding-right:300px"><asp:Button ID="Button1" runat="server" OnClick="btnCheesePizza_Click" Text="Add to order" Width="124px" /></td>
                    <td style="padding-right:300px"><asp:Button ID="Button2" runat="server" Text="Add to order" Width="124px" OnClick="btnPepperoniPizza_Click" /></td>            
                    </tr>
                    <tr>
                    <td style="padding-right:300px"><asp:Image ID="Image3" runat="server" Height="190px" ImageUrl="~/Images/fanta_orange_500ml.jpg" Width="200px"/></td>
                    <td style="padding-right:300px"> <asp:Image ID="Image4" runat="server" Height="193px" ImageUrl="~/Images/water-bottle.jpg" Width="232px" /></td>
                    </tr>            
                    <tr>
                    <td style="padding-right:300px">Bottle of Fanta - £1.50</td>
                    <td style="padding-right:300px">Bottle of Water - £1.50</td>            
                    </tr>
                    <tr>
                    <td style="padding-right:300px"><asp:Button ID="Button3" runat="server" OnClick="btnFanta_Click" Text="Add to order" Width="124px" /></td>
                    <td style="padding-right:300px"><asp:Button ID="Button4" runat="server" Text="Add to order" Width="124px" OnClick="btnWater_Click" /></td>            
                </tr>
            </table>            
        </td>
        </tr>
        </table>
        <p>
            <asp:Label ID="lblTotalPriceText" runat="server" Text="Total: "></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label ID="lblTotalPrice" runat="server"></asp:Label>
        </p>
        
    </form>
</body>
</html>

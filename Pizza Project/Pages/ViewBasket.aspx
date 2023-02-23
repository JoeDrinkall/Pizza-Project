<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBasket.aspx.cs" Inherits="Pizza_Project.ViewBasket" %>

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
            <br /><br />
            <a href="OrderScreen.aspx">< Back to Order Screen</a>
            <br /><br />
            <asp:GridView runat="server" ID="gvBasket" AutoGenerateColumns="false" EmptyDataText="There is nothing in your Basket" GridLines="None" Width="100%" CellPadding="5" ShowFooter="true" DataKeyNames="ProductId" OnRowCommand="gvBasket_RowCommand">
                <HeaderStyle HorizontalAlign="Left" BackColor="#3D7169" ForeColor="#FFFFFF" />
                <FooterStyle HorizontalAlign="Right" BackColor="#6C6B66" ForeColor="#FFFFFF" />
                <AlternatingRowStyle BackColor="#F8F8F8" />
                <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="Name" />
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtQuantity" Columns="5" Text='<%# Eval("Quantity") %>'></asp:TextBox><br />
                            <asp:LinkButton runat="server" ID="btnRemove" Text="Remove" CommandName="Remove" CommandArgument='<%# Eval("ProductId") %>' style="font-size:12px;"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ProductPrice" HeaderText="Price" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="TotalPrice" HeaderText="Total" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:C}" />
                </Columns>
            </asp:GridView>
            <br /><br />
            <asp:Button runat="server" ID="btnPlaceOrder" Text="Place Order" OnClick="btnPlaceOrder_Click" Visible="false"/>
        </div>        
    </form>
</body>
</html>

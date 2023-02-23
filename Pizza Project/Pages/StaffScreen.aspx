<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffScreen.aspx.cs" Inherits="Pizza_Project.Pages.StaffScreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <h1 style="text-align: left">Nescot Pizza</h1>
            <br /><br />
            <a href="OrderScreen.aspx">< Back to Order Screen</a>
            <br /><br />
            <asp:GridView runat="server" ID="gvOrders" AutoGenerateColumns="false" EmptyDataText="There are no outstanding orders" GridLines="None" Width="100%" CellPadding="5" ShowFooter="true" DataKeyNames="Id" OnRowCommand="gvOrders_RowCommand">
                <HeaderStyle HorizontalAlign="Left" BackColor="#3D7169" ForeColor="#FFFFFF" />
                <FooterStyle HorizontalAlign="Right" BackColor="#6C6B66" ForeColor="#FFFFFF" />
                <AlternatingRowStyle BackColor="#F8F8F8" />
                <Columns>
                    <asp:BoundField DataField="OrderDate" HeaderText="Order Date and Time" />
                    <asp:BoundField DataField="Id" HeaderText="Order Number" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:TemplateField HeaderText="Details">
                        <ItemTemplate>                            
                            <asp:Button runat="server" ID="btnView" Text="View" CommandName="View" CommandArgument='<%# Eval("Id") %>' style="font-size:12px;"></asp:Button>
                            <asp:Button runat="server" ID="btnMaking" Text="Making" CommandName="Making" CommandArgument='<%# Eval("Id") %>' style="font-size:12px;"></asp:Button>
                            <asp:Button runat="server" ID="btnComplete" Text="Complete" CommandName="Complete" CommandArgument='<%# Eval("Id") %>' style="font-size:12px;"></asp:Button>                            
                        </ItemTemplate>
                    </asp:TemplateField>                    
                </Columns>
            </asp:GridView>
            <br /><br />
            Order Details:
            <asp:GridView runat="server" ID="gvOrderDetails" AutoGenerateColumns="false" EmptyDataText="There is no selected order" GridLines="None" Width="100%" CellPadding="5" ShowFooter="true" DataKeyNames="Id">
                <HeaderStyle HorizontalAlign="Left" BackColor="#3D7169" ForeColor="#FFFFFF" />
                <FooterStyle HorizontalAlign="Right" BackColor="#6C6B66" ForeColor="#FFFFFF" />
                <AlternatingRowStyle BackColor="#F8F8F8" />
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                </Columns>
            </asp:GridView>
            <br /><br />
        </div>        
    </form>
</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.master" AutoEventWireup="true" CodeFile="product_desc.aspx.cs" Inherits="User_product_desc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="Server">

    <asp:FormView ID="d1" runat="server">
        <ItemTemplate>
            <div style="height: 300px; width: 600px; border-style: solid; border-width: 1px;">
                <div style="height: 300px; width: 200px; border-right: solid; border-width: 1px; float: left;">
                    <img src="../<%#Eval("prod_images") %>" height="auto" width="200" />
                </div>
                <div style="height: 300px; width: 395px; float: left; font-size: 20px;">
                    <p style="margin: 1em;"><strong>item name: </strong><%#Eval("prod_name") %></p>
                    <p style="margin: 0 1em 1em 1em;"><strong>product description: </strong><%#Eval("prod_desc") %></p>
                    <p style="margin: 0 1em 1em 1em;"><strong>product qty: </strong><%#Eval("prod_qty") %></p>
                    <p style="margin: 0 1em 1em 1em;"><strong>product price: </strong><%#Eval("prod_price") %></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>
    <br/>

    <table>
        <tr>
            <td><asp:Label ID="l2" runat="server" Text="qty" ></asp:Label></td>
            <td style="height: 42px;"><asp:TextBox ID="t1" runat="server" Height="21px" Width="61px" font-size="Large"></asp:TextBox></td>
            <td style="height: 42px"><asp:Button ID="b1" runat="server" Text="Add" onclick="b1_Click" Font-Bold="True" Font-Size="Medium" Height="30px" Width="114px"/></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="l1" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
    </table>    

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="display_order.aspx.cs" Inherits="Admin_display_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="Server">
    <h3>Orders Viewer</h3>
    <asp:Repeater ID="d1" runat="server">
        <HeaderTemplate>
            <table>
                <tr style="background-color: silver; color: white; font-weight: bold; padding: initial">
                    <td style="padding: 4px;">id</td>
                    <td style="padding: 4px;">firstname</td>
                    <td style="padding: 4px;">last name</td>
                    <td style="padding: 4px;">town</td>
                    <td style="padding: 4px;">postcode</td>
                    <td style="padding: 4px;">telephone</td>
                    <td style="padding: 4px;">view order details</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("id") %></td>
                <td><%#Eval("firstname") %></td>
                <td><%#Eval("lastname") %></td>
                <td><%#Eval("town") %></td>
                <td><%#Eval("postcode") %></td>
                <td><%#Eval("telephone") %></td>
                <td><a href="view_order_details.aspx?id=<%#Eval("id") %>">View order details</a></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>  
</asp:Content>


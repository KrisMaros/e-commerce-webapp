<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.master" AutoEventWireup="true" CodeFile="view_order_details.aspx.cs" Inherits="User_view_order_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    <asp:Repeater ID="d1" runat="server">
        <HeaderTemplate>
            <table>
                <tr style="background-color: silver; color: white; font-weight: bold; padding: initial">
                    <td style="padding: 4px;">product image</td>
                    <td style="padding: 4px;">product name</td>
                    <td style="padding: 4px;">price</td>
                    <td style="padding: 4px;">qty</td>                    
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><img src="../<%#Eval("prod_images")%>" height="100" width="100"/></td>
                <td><%#Eval("prod_name") %></td>
                <td><%#Eval("prod_price") %></td>
                <td><%#Eval("prod_qty") %></td>                 
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater> 
    <div style="padding-left:200px">
        <asp:Label ID="l1" runat="server" Text=""></asp:Label> 
    </div>   
</asp:Content>


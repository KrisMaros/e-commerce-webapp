<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.master" AutoEventWireup="true" CodeFile="view_cart.aspx.cs" Inherits="User_view_cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
        <div>
            
            <asp:DataList ID="d1" runat="server">

                <HeaderTemplate>
                 <table>
                     <tr style="background-color:silver; color:white; font-weight:bold; padding:initial">
                         <td style="padding:4px;">image</td>
                         <td style="padding:4px;">product name</td>
                         <td style="padding:4px;">description</td>
                         <td style="padding:4px;">price</td>
                         <td style="padding:4px;">qty</td>
                         <td style="padding:4px;">delete</td>
                     </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <img src="../<%#Eval("prod_images") %>" height="auto" width="100" /></td>
                        <td><%#Eval("prod_name") %></td>
                        <td><%#Eval("prod_desc") %></td>
                        <td><%#Eval("prod_price") %></td>
                        <td><%#Eval("prod_qty") %></td>
                        <td>
                            <a href="delete_cart.aspx?id=<%#Eval("id") %>">delete</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>

            </asp:DataList>
            <br />
            <p align="center">
                <asp:Label ID="l1" runat="server"  Font-Size="Medium"></asp:Label><br />
                <asp:Button ID="b1" runat="server" Text="checkout" OnClick="b1_Click" />
            </p>
            
        </div>
    
</asp:Content>

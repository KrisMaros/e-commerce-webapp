<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.master" AutoEventWireup="true" CodeFile="display_product.aspx.cs" Inherits="User_display_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="Server">
    <asp:Repeater ID="d1" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <a href="product_desc.aspx?id=<%#Eval("id")%>"><img src="../<%#Eval("prod_images") %>" alt="" /></a>
                <div class="product-info">
                    <h3><%#Eval("prod_name") %></h3>
                    <div class="product-desc">
                        <h4>qty:<%#Eval("prod_qty") %></h4>
                        <p>
                           <%#Eval("prod_desc") %>
                        </p>
                        <strong class="price">price:<%#Eval("prod_price") %></strong>
                    </div>
                </div>
            </li>

        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>


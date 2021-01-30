<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="add_category.aspx.cs" Inherits="Admin_add_category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    <table>
        <tr>
            <td>New category: </td>
            <td>
                <asp:TextBox ID="t1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btn1" runat="server" Text="Add new category" OnClick="btn1_Click" />                
            </td>
        </tr>
        <tr>
            <td colspan="2">                
                <asp:Label ID="l1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>

    <asp:DataList ID="d1" runat="server" Width="129px">
        <HeaderTemplate>
            <table>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td style="padding: 5px;">
                    <%#Eval("product_category") %>
                </td>
                <td>
                     <a href="delete_category.aspx?category=<%#Eval("product_category")%>">Delete</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:DataList>

</asp:Content>


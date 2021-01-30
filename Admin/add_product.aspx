<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="add_product.aspx.cs" Inherits="Admin_add_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="Server">

    <h3>New Product Page</h3>

    <table>
        <tr>
            <td>Product name</td>
            <td>
                <asp:TextBox ID="t1" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Product description</td>
            <td>
                <asp:TextBox ID="t2" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Product price</td>
            <td>
                <asp:TextBox ID="t3" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Product qty</td>
            <td>
                <asp:TextBox ID="t4" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Select category</td>
            <td>
                <asp:DropDownList ID="DropDownCategory" runat="server"></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>Product images</td>
            <td>
                <asp:FileUpload ID="f1" runat="server"></asp:FileUpload></td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:Button ID="btn1" runat="server" Text="upload" OnClick="btn1_Click" />
            </td>
        </tr>

    </table>  

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EcommerceConnectionString %>" SelectCommand="SELECT * FROM [Product]"></asp:SqlDataSource>
</asp:Content>



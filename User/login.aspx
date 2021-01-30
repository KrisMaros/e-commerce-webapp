<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="User_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    <table>
        <tr>
            <td>Enter Email</td>
            <td>
                <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Enter Password</td>
            <td>
                <asp:TextBox ID="TextBoxPass" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
         <tr>            
            <td colspan="2" align="center">
                <asp:Button ID="btn1" runat="server" Text="Login" Font-Bold="False" Font-Size="Medium" OnClick="btn1_Click" />
            </td>
        </tr>
         <tr>            
            <td colspan="2" align="center">
                <asp:Label ID="l1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.master" AutoEventWireup="true" CodeFile="update_order_details.aspx.cs" Inherits="User_update_order_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    <table>
        <tr>
            <td>First name:</td>
            <td>
                <asp:TextBox ID="TextBoxFirst" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Last name:</td>
            <td>
                <asp:TextBox ID="TextBoxLast" runat="server"></asp:TextBox>
            </td>
        </tr>       
        <tr>
            <td>Address:</td>
            <td>
                <asp:TextBox ID="TextBoxAddress" runat="server" Height="59px" TextMode="MultiLine" Width="115px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Town:</td>
            <td>
                <asp:TextBox ID="TextBoxTown" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Post code:</td>
            <td>
                <asp:TextBox ID="TextBoxPost" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Phone:</td>
            <td>
                <asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>            
            <td colspan="2" align="center">
                <asp:Button ID="btn1" runat="server" Text="update details" OnClick="btn1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>


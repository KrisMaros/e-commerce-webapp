<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.master" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="User_registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="Server">

    <table>
        <tr>
            <td>First name</td>
            <td>
                <asp:TextBox ID="TextBoxFirst" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Last name</td>
            <td>
                <asp:TextBox ID="TextBoxLast" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>E-mail</td>
            <td>
                <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="TextBoxPass" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>        
        <tr>
            <td>Address</td>
            <td>
                <asp:TextBox ID="TextBoxAddress" runat="server" Height="67px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Town</td>
            <td>
                <asp:TextBox ID="TextBoxTown" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Postcode</td>
            <td>
                <asp:TextBox ID="TextBoxPost" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Pin code</td>
            <td>
                <asp:TextBox ID="TextBoxPin" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Telephone</td>
            <td>
                <asp:TextBox ID="TextBoxTelephone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>            
            <td colspan="2" align="center" style="height: 45px"> 
                <asp:Button ID="btn1" runat="server" Text="Register" OnClick="btn1_Click" Font-Bold="True" Height="34px" Width="75px" />
            </td>
        </tr>
        <tr>           
            <td colspan="2" align="center" style="height: 24px"> 
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>


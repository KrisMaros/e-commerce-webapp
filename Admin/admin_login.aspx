<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_login.aspx.cs" Inherits="Admin_admin_login" %>

<!DOCTYPE HTML>
<html>
<head>
    <title>Simple Login Form</title>
    <meta charset="UTF-8" />
    <link rel="stylesheet" type="text/css" href="css/reset.css">
    <link rel="stylesheet" type="text/css" href="css/structure.css">
</head>

<body>
    <form class="box login" id="f1" runat="server">
        <fieldset class="boxBody">
            <label>Username</label>
            <asp:TextBox ID="t1" runat="server"></asp:TextBox>
            <label>Password</label>
            <asp:TextBox ID="t2" runat="server"></asp:TextBox>
        </fieldset>
        <footer>            
            <asp:Button ID="btn1" runat="server" Text="Login" OnClick="btn1_Click"/>
             <asp:Label ID="l1" runat="server" ForeColor="#FF3300"></asp:Label> 
        </footer>
       
    <footer id="main">
        <a href="http://wwww.cssjunction.com">Simple Login Form (HTML5/CSS3 Coded) by CSS Junction</a> | <a href="http://www.premiumpixels.com">PSD by Premium Pixels</a>
    </footer>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EcommerceConnectionString %>" SelectCommand="SELECT * FROM [admin_login]"></asp:SqlDataSource>
        
    </form>
    </body>
</html>

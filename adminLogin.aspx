<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminLogin.aspx.cs" Inherits="FinalFurnitureShowroom.Admin.adminLogin" %>

<html >
  <head>
    <meta charset="UTF-8">
    <title>Admin Login</title>
     <link rel="stylesheet" href="logincss/style.css">
</head>

  <body>

    
<form id="fi" runat="server">
  <header>Login</header>
  <label>Username <span>*</span></label>
  <asp:TextBox id="tbxUsername" runat="server"> </asp:TextBox>
  <label>Password <span>*</span></label>
  <asp:TextBox id="tbxPass" runat="server" TextMode="Password"> </asp:TextBox>
<br /> 
    <asp:Button ID="b1" Text="LogIn" runat="server" OnClick="b1_Click" /> 
    <br />
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <br />
</form>
    
    
    
    
  </body>
</html>


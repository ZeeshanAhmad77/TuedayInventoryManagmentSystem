<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="InventoryManagmentSystem.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     
        <div id="view">
            <h1> Login form</h1>

              <!--  Defining TextBox  -->
            <asp:Label Text=" User Name" ID="LableUserName"  runat="server"> User Name</asp:Label>
            <asp:TextBox ID="txtUserName" runat="server"  ></asp:TextBox> <br />
              <!--  Seperation Dive  -->
            <div class="sepation"></div>
            <asp:Label Text=" Password" ID="LablePassword" runat="server" > Password</asp:Label>
            <asp:TextBox ID="txtPassword" runat="server"  ></asp:TextBox> <br />
              <!--  Seperation Dive  -->
            <div class="sepation"></div>

            <!--  Defining Buttons  -->
            <asp:Button   ID="btnLogin" runat="server"  Text="Login"  OnClientClick="javascript: return Validate()" OnClick="btnLogin_Click" /> 
       
            <asp:Label Text=" Incorrect User Credentials" ID="lblErrorMessage" runat="server" > </asp:Label>

            <br />
            <input id="checkBoxAdmin" type="checkbox"  runat="server"/> Login as admin<br />
       
        </div>


    </form>
    <script src="LoginJavaScript.js"></script>
    </body>
</html>

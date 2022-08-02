<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountantPage.aspx.cs" Inherits="InventoryManagmentSystem.AccountantPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 runat="server" id="heading"> </h1>
             <p runat="server" id="name"> </p>
             <p runat="server" id="password"> </p>
        </div>
                <div>

              <label for="html"> Home Page </label>
              <asp:Button   ID="btnHomePage1" runat="server"  Text="Home Page Button"   OnClick="btnHomePage1_Click"/> 

        </div>
    </form>
</body>
</html>

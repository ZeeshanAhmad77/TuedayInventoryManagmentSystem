<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="InventoryManagmentSystem.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p" crossorigin="anonymous" />
    <link rel="stylesheet" type="text/css" href="//cdn.datatables.net/1.10.22/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="//cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>
    

       <style>

   </style>
    <title> Admin Page </title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 runat="server" id="heading"> </h1>
             <p runat="server" id="name"> </p>
             <p runat="server" id="password"> </p>
        </div>
        <div>

              <label for="html">Home Page </label>
              <asp:Button   ID="btnHomePage" runat="server"  Text="Home Page Button"   OnClick="btnHomePage_Click" /> 

              <br />
              <br />
              <br />

        </div>

        <div>
             <label for="html"> Accountant Namee</label>
            <input id="txtAccountantName" type="text" runat="server" /> 
            <label for="html">Accountant Password</label>
            <input id="txtAccountantPassword" type="text" runat="server" />
            <asp:Button   ID="submitAccountantData" runat="server"  Text="Add Accountant "  OnClick="submitAccountantData_Click"  />
             <label for="html" id="confirmation" runat="server"> </label>
           
        </div>


               <div id="divArea">
        <table id="AdminTable">
            <thead>
                <tr>
                     <th> ID</th>
                     <th> Name</th>
                     <th> Password</th>
                    <th> Operation</th>
                </tr>
            </thead>
        </table>
          </div>
    </form>
       <script >

           //Ajax call to populate the Table of  Accountant from Database 
           $(document).ready(function () {
               $.ajax({
                   url: 'AccountantServices.asmx/AccountantTable',
                   method: 'post',
                   dataType: 'json',
                   success: function (data) {

                       $("#AdminTable").dataTable({
                           data: data,
                           columns: [


                               { 'data': 'Id' },
                               { 'data': 'Name' },
                               { 'data': 'Password' },

                               {
                                   'data': 'Id',
                                   'render': function (data) {
                                       //Making buttons of delete & Update
                                       return '<button type="button" class="btn btn-primary" id="editAccountantID" onclick="deleteAccountant(' + data + ')">Delete</button>'
                                   },
                               },


                           ],
                            select: true,
                       });
                   }

               });



           });
           //Function that is called when we click on the Delete Button present on the data table of accountant
           function deleteAccountant(id) {
               $.ajax({
                   url: 'AdminPage.aspx/DeleteAccountant',
                   type: 'post',
                   data: JSON.stringify({ "id": id }),
                   contentType: 'application/json',
                   async: false,
                   success: function (data) {
                       alert("Succesfully deleted Entry at " + id+"   Refresh to watch");

                   }
               });
              
           }
       </script>
</body>
</html>

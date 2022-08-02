<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="InventoryManagmentSystem.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.js" integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk="  crossorigin="anonymous"></script>
    <link  rel="stylesheet" type="text/css" href="//cdn.datatables.net/1.12.1/css/jquery.dataTables.min.css"/>
    <script src="//cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
    <title>Home Page</title>
           <style>
      #divAreaCustomer,#divAreaItems
      {
           border: 1px solid black;
           width:50%;
           padding:3px;
           background-color:cornsilk;

       }
   </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1> Home Page</h1>

        </div>
           <div>
            <h1> Customer Table</h1>

        </div>
                <div>
            <label for="html"> ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>
&nbsp;<input id="CustomerId" type="text" runat="server" /> 
            <label for="html"> 
                    <br />
                    Customer Name </label>
                    &nbsp;
            <input id="txtCustomertName" type="text" runat="server" /> 
            <label for="html">
                    <br />
                    Customer Adress</label>&nbsp;
            <input id="txtCustomerAdress" type="text" runat="server" /><br />
                    <br />
&nbsp;<asp:Button   ID="submitCustomerData" runat="server"  Text="Add Customer "  OnClick="submitCustomerData_Click" />
               
                    <asp:Button   ID="updateCustomerData" runat="server"  Text="Update Customer "  OnClick="updateCustomerData_Click" />

             <label for="html" id="confirmationCustomer" runat="server"> </label>
           <asp:HiddenField ID="hiddenCustomerName" runat="server"  />
         <asp:HiddenField ID="hiddenCustomerAdress" runat="server"  />
        </div>

      <div id="divAreaCustomer">
        <table id="CustomerTable">
            <thead>
                <tr>
                     <th> ID</th>
                     <th> Customer Name</th>
                     <th> Customer Name</th>
                     <th> Operation</th>
                    
                </tr>
            </thead>
        </table>
      </div>

              
        <div>
            <h1> Product Table</h1>

        </div>
         <div>
             <label for="html"> ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>
             <input id="ProductId" type="text" runat="server" /> 
             <label for="html"> 
             <br />
             Product Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>
            &nbsp;<input id="txtProductName" type="text" runat="server" /> 
            <label for="html">
             <br />
             Product Cost Price&nbsp;&nbsp; </label>
&nbsp;<input id="txtCostPrice" type="text" runat="server" />
             <label for="html">
             <br />
             Product Sale Price</label>&nbsp;&nbsp;&nbsp;&nbsp;
            <input id="txtSalePrice" type="text" runat="server" /><br />
&nbsp;<asp:Button   ID="submitProductData" runat="server"  Text="Add Product "  OnClick="submitProductData_Click" />
            
             <asp:Button   ID="updateProductData" runat="server"  Text="Update Product "  OnClick="updateProductData_Click" />


             <label for="html" id="confirmationProduct" runat="server"> </label>
           
        </div>
        
      <div id="divAreaItems">
        <table id="ProductTable">
            <thead>
                <tr>
                     <th> ID</th>
                     <th>Product Name</th>
                     <th> Cost Price</th>
                    <th> Sale Price</th>
                     <th> Operations</th>
                </tr>
            </thead>
        </table>
      </div>

    </form>
           <script >
               //Ajax call to populate the Table of  Product Database 
           $(document).ready(function () {
               $.ajax({
                   url: 'AccountantServices.asmx/ProductTable',
                   method: 'post',
                   dataType: 'json',
                   success: function (data) {

                       $("#ProductTable").dataTable({
                           data: data,
                           columns: [

                               { 'data': 'Id' },
                               { 'data': 'Name' },
                               { 'data': 'CostPrice' },
                               { 'data': 'SalePrice' },
                               {
                                   'data': 'Id',
                                   'render': function (data) {
                                        //Making buttons of delete & Update
                                       return '<button type="button" class="btn btn-primary" id="editAccountantID" onclick="deleteProduct(' + data + ')">Delete</button><button type="button" class="btn btn-primary" id="UpdateAccountant" onclick="UpdateCustmor(' + data + ')">Update</button>'
                                   },
                               },

                           ],
                            select: true,
                       });
                   }

               });



           });
                //Function that is called when we click on the Delete Button present on the data table of Product
               function deleteProduct(id) {           
                   $.ajax({
                       url: 'HomePage.aspx/DeleteProduct',
                       type: 'post',
                       data: JSON.stringify({ "id": id }),
                       contentType: 'application/json',
                       async: false,
                       success: function (data) {
                           alert("Succesfully deleted Entry at " + id + "    Refresh to watch ");

                       }
                   });

               }
           </script>
              <script >
                 //Ajax call to populate the Table of  Custmor Database 
                  $(document).ready(function () {
                      $.ajax({
                          url: 'AccountantServices.asmx/CustomerTable',
                          method: 'post',
                          dataType: 'json',
                          success: function (data) {

                              $("#CustomerTable").dataTable({
                                  data: data,
                                  columns: [

                                      { 'data': 'Id' },
                                      { 'data': 'Name' },
                                      { 'data': 'Adress' },
                                      {
                                          'data': 'Id',
                                          'render': function (data) {
                                                 //Making buttons of delete & Update
                                              return '<button type="button" class="btn btn-primary" id="editAccountantID" onclick="deleteCustmor(' + data + ')">Delete</button><button type="button" class="btn btn-primary" id="UpdateAccountant" onclick="UpdateCustmor(' + data + ')">Update</button>'
                                          },
                                      },
                                     

                                  ],
                                  select: true,
                              });
                          }

                      });



                  });
                  //Function that is called when we click on the Update Button present on the data table of Custmor
                  function UpdateCustmor(id) {                 

                  }
                  //Function that is called when we click on the Delete Button present on the data table of Custmor
                  function deleteCustmor(id) {


                      $.ajax({
                          url: 'HomePage.aspx/DeleteCustmor',
                          type: 'post',
                          data: JSON.stringify({ "id": id }),
                          contentType: 'application/json',
                          async: false,
                          success: function (data) {
                              alert("Succesfully deleted Entry at "+id +"    Refresh to watch ");

                          }
                      });

                  }
              </script>
</body>
</html>

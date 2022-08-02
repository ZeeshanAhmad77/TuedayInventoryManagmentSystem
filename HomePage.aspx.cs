using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace InventoryManagmentSystem
{
    public partial class HomePage : System.Web.UI.Page
    {
       
      
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["userName"].ToString() == null && Session["password"].ToString() == null)
            //{
            //    Response.Redirect("LoginPage.aspx");
            //}
            //else { return; }
            hiddenCustomerAdress.Value = txtCustomertName.Value;
            hiddenCustomerAdress.Value = txtCustomerAdress.Value;

        }
        // Customer Operation
        protected void submitCustomerData_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.AddCustomer(txtCustomertName.Value, txtCustomerAdress.Value);
        }


        [WebMethod]
        public static List<Customer> DeleteCustmor(int id)
        {
            Customer customer = new Customer();
            customer.DeleteCustomer(id);
            List<Customer> CustomertList = customer.GetCustomerList();
            return CustomertList;
        }

        protected void updateCustomerData_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.UpdateCustomer(Convert.ToInt32(CustomerId.Value), txtCustomertName.Value, txtCustomerAdress.Value);
        }
        [WebMethod]
        public static void UpdateCustmor(int id)
        {

            //Customer customer = new Customer();
            //customer.UpdateCustomer(id, txtCustomertName.Value, txtCustomerAdress.Value);
            //List<Customer> CustomertList = customer.GetCustomerList();
            //return CustomertList;
        }

        // Product Operation
        protected void submitProductData_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.AddProduct(txtProductName.Value, Convert.ToInt32(txtCostPrice.Value), Convert.ToInt32(txtSalePrice.Value));
        }

        [WebMethod]
        public static List<Product> DeleteProduct(int id)
        {
            Product product = new Product();
            product.DeleteProduct(id);
            List<Product> productList = product.GetProductList();
            return productList;
        }

        protected void updateProductData_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.UpdateProduct(Convert.ToInt32(ProductId.Value), txtProductName.Value, Convert.ToInt32(txtCostPrice.Value),Convert.ToInt32( txtSalePrice.Value));
        }
    }
}
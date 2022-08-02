using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace InventoryManagmentSystem
{
    /// <summary>
    /// Summary description for AccountantServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class AccountantServices : System.Web.Services.WebService
    {

        [WebMethod]
        public void AccountantTable()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
           

            Accountant accountant = new Accountant();
            List<Accountant> AccountantList = accountant.GetAccountantList();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(AccountantList));
        }


        [WebMethod]
        public void ProductTable()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;


            Product product = new Product();
            List<Product> ProductList = product.GetProductList();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(ProductList));
        }
        [WebMethod]
        public void CustomerTable()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;


            Customer customer = new Customer();
            List<Customer> CustomertList = customer.GetCustomerList();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(CustomertList));
        }
        public void DeleteCustomer()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;


            Customer customer = new Customer();
            List<Customer> CustomertList = customer.GetCustomerList();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(CustomertList));
        }
    }

    
}

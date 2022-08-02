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
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            heading.InnerText = "Welcome to Admin Page " ;
            name.InnerText = "User Name " + Session["userName"].ToString() ;
            password.InnerText = "Having the password  = " + Session["password"].ToString();
        }

        protected void submitAccountantData_Click(object sender, EventArgs e)
        {
            Accountant accountant = new Accountant();
            accountant.AddAccountant(txtAccountantName.Value, txtAccountantPassword.Value);
        }
        [WebMethod]
        // Delete function that is called through Ajex to delete an accountant
        public static void DeleteAccountant(int id)
        {
            Accountant accountant = new Accountant();
            accountant.DeleteAccountant(id);


        }

        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}
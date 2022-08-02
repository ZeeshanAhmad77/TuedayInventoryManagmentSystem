using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagmentSystem
{
    public partial class AccountantPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Data will be shown on loading the Accountant Page
            heading.InnerText = "Welcome to Accountant Page " ;
            name.InnerText = "User Name " + Session["userName"].ToString();
            password.InnerText = "Having the password  = " + Session["password"].ToString();

        }



        protected void btnHomePage1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");

        }
    }
}
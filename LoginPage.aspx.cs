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

namespace InventoryManagmentSystem
{
    public partial class LoginPage : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            
           // lblErrorMessage.Visible = false;

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
            // Making the objects

            Admin admin = new Admin();
            Accountant accountant = new Accountant();
            
        
            if (checkBoxAdmin.Checked)
            {
                List<Admin> adminList = admin.GetAdminList();
                // Loop on admin list to go to admin page

                foreach (Admin _admin in adminList)
                {
                    if (txtUserName.Text.Trim().ToLower() == _admin.Name.Trim().ToLower() && txtPassword.Text.Trim().ToLower() == _admin.Password.Trim().ToLower())
                    {
                        Session["userName"] = txtUserName.Text;
                        Session["password"] = txtPassword.Text;
                        Response.Redirect("AdminPage.aspx");

                    }
                }

            }
            else
            {
                List<Accountant> accountantList = accountant.GetAccountantList();
               

                // Loop on Accountant list to go to admin page

                foreach (Accountant _accountant in accountantList)
                {
                    if (txtUserName.Text.Trim().ToLower() == _accountant.Name.Trim().ToLower() && txtPassword.Text.Trim().ToLower() == _accountant.Password.Trim().ToLower())
                    {
                        Session["userName"] = txtUserName.Text;
                        Session["password"] = txtPassword.Text;
                        Response.Redirect("AccountantPage.aspx");

                    }
                }

            }
            lblErrorMessage.Visible = true;

        }


        //protected void login_Click(object sender, EventArgs e)
        //{
        //    lblErrorMessage.Visible = false;
        //    //Getting the Lists of Admins and users

        //    adminList = admin.GetAdminList();
        //    accountantList = accountant.GetAccountantList();

        //    // Loop on admin list to go to admin page

        //    foreach (Admin admin in adminList)
        //    {
        //        if (userName.Text.Trim().ToLower() == admin.Name.Trim().ToLower() && password.Text.Trim().ToLower() == admin.Password.Trim().ToLower())
        //        {
        //            Session["userName"] = userName.Text;
        //            Session["password"] = password.Text;
        //            Response.Redirect("AdminPage.aspx");

        //        }
        //    }


        //    // Loop on admin list to go to admin page
        //    foreach (Accountant accountant in accountantList)
        //    {
        //        if (userName.Text.Trim().ToLower() == accountant.Name.Trim().ToLower() && password.Text.Trim().ToLower() == accountant.Password.Trim().ToLower())
        //        {
        //            Session["userName"] = userName.Text;
        //            Session["password"] = password.Text;
        //            Response.Redirect("AccountantPage.aspx");

        //        }
        //    }

        //    lblErrorMessage.Visible = true;
        //}
    }
}
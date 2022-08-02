using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace InventoryManagmentSystem
{
     public class Admin :User
    {


        //Constructer

   
        // Method Return the table of Amdmin as a List<Admin>
        public List<Admin> GetAdminList()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            List<Admin> adminList = new List<Admin>();
            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("spGetAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Admin admin = new Admin();
                    admin.Id = Convert.ToInt32(rdr["id"]);
                    admin.Name = rdr["name"].ToString();
                    admin.Password = rdr["password"].ToString();
                    adminList.Add(admin);
                }

            }

            return adminList;


        }
            
        //    List<Admin> lisOfAdmin = new List<Admin>();
        //    lisOfAdmin.Add(new Admin("Admin1", "123"));
        //    lisOfAdmin.Add(new Admin("Admin2", "123"));
        //    lisOfAdmin.Add(new Admin("Admin3", "123"));
        //    lisOfAdmin.Add(new Admin("Admin4", "123"));
        //    return lisOfAdmin;
        //}

        //public List<Accountant> AddAccountant(Accountant newAccountant )
        //{
        //    Accountant accountant = new Accountant();
        //    List<Accountant> listOfAccountant;           
        //    listOfAccountant= accountant.GetAccountantList();
        //    listOfAccountant.Add(newAccountant);
        //    return listOfAccountant;
        //}

    }
}
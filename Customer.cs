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
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }

        public List<Customer> GetCustomerList()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            List<Customer> customerList = new List<Customer>();
            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("spGetCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Customer customer = new Customer();
                    customer.Id = Convert.ToInt32(rdr["id"]);
                    customer.Name = rdr["name"].ToString();
                    customer.Adress = rdr["Adress"].ToString();

                    customerList.Add(customer);
                }

            }
            return customerList;


        }


        public void AddCustomer(string customerName, string adress)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                var sql = "INSERT INTO tblCustomer(name, Adress) VALUES(@name, @Adress)";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@name", customerName);
                    cmd.Parameters.AddWithValue("@Adress", adress);
                   

                    cmd.ExecuteNonQuery();
                }
                con.Close();


            }

        }

        public void DeleteCustomer(int id)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                var sql = "DELETE FROM tblCustomer WHERE id = @id;";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }


        }

        public void UpdateCustomer(int id, string customertName, string customerAdress)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();


                var sql = "UPDATE tblCustomer SET name = @name, Adress = @Adress WHERE id = @id;";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", customertName);
                    cmd.Parameters.AddWithValue("@Adress", customerAdress);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }


        }

    }
}
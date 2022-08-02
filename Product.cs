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
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CostPrice { get; set; }
        public int SalePrice { get; set; }

        public List<Product> GetProductList()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            List<Product> productList = new List<Product>();
            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("spGetProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Product product = new Product();
                    product.Id = Convert.ToInt32(rdr["id"]);
                    product.Name = rdr["itemName"].ToString();
                    product.CostPrice = Convert.ToInt32(rdr["costPrice"]);
                    product.SalePrice = Convert.ToInt32(rdr["salePrice"]);
                    productList.Add(product);
                }

            }
            return productList;


        }


        public void AddProduct(string productName, int costPrice, int salePrice)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                var sql = "INSERT INTO tblItems(itemName, costPrice,salePrice) VALUES(@itemName, @costPrice,@salePrice)";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@itemName", productName);
                    cmd.Parameters.AddWithValue("@costPrice", costPrice);
                    cmd.Parameters.AddWithValue("@salePrice", salePrice);

                    cmd.ExecuteNonQuery();
                }
                con.Close();


            }

        }

        public void DeleteProduct(int id)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                var sql = "DELETE FROM tblItems WHERE id = @id;";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }


        }

        public void UpdateProduct(int id, string producttName, int productCostPrice,int productSalePrice)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();


                var sql = "UPDATE tblItems SET itemName = @itemName, costPrice = @costPrice,salePrice = @salePrice WHERE id = @id;";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@itemName", producttName);
                    cmd.Parameters.AddWithValue("@costPrice", productCostPrice);
                    cmd.Parameters.AddWithValue("@salePrice", productSalePrice);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }


        }
    }
}
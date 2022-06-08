using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Saki_Naturals.Models;

namespace Saki_Naturals.DB
{
    static public class DataBaseService
    {
        static private string sqlUrl = "Data Source=(localdb)\\SakiNaturalsInstance;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static private SqlConnection con = new SqlConnection(sqlUrl);

        static public List<ProductDataClass> getAllProductsData()
        {   

            String query = "SELECT * FROM Products";
            SqlCommand sqlCommand = new(query, con);
            sqlCommand.CommandTimeout = 60;

            con.Open();

            List<ProductDataClass> productList = new List<ProductDataClass>();

            SqlDataReader res = sqlCommand.ExecuteReader();

            if(res != null)
            {
                while (res.Read())
                {

                    ProductDataClass productData = new ProductDataClass(res[1].ToString(), res[2].ToString(), res[3].ToString(), int.Parse(res[4].ToString()), decimal.Parse(res[5].ToString()), decimal.Parse(res[6].ToString()), decimal.Parse(res[7].ToString()), DateTime.Now, int.Parse(res[9].ToString()));
                    productData.Id = int.Parse(res[0].ToString());

                    productList.Add(productData);

                }

                res.Close();
            }                                

            con.Close();

            return productList;
        }

        static public void insertProductData(ProductDataClass queryData)
        {      

            String insertQuery = "INSERT INTO Products ([Group], Product_Name, Description, Stock, Price_Direct_Sale, Price_Reseller, Price_Dealer, Created_Date, Sold) ";
            insertQuery += "VALUES (@Group, @Product_Name, @Description, @Stock, @Price_Direct_Sale, @Price_Reseller, @Price_Dealer, @Created_Date, @Sold);";

            Debug.WriteLine("Debug query");
            Debug.WriteLine(insertQuery);


            SqlCommand sqlCommand = new SqlCommand(insertQuery, con);
            sqlCommand.Parameters.AddWithValue("@Group", queryData.group);
            sqlCommand.Parameters.AddWithValue("@Product_Name", queryData.productName);
            sqlCommand.Parameters.AddWithValue("@Description", queryData.description);
            sqlCommand.Parameters.AddWithValue("@Stock", queryData.stock);
            sqlCommand.Parameters.AddWithValue("@Price_Direct_Sale", queryData.priceDirectSale);
            sqlCommand.Parameters.AddWithValue("@Price_Reseller", queryData.priceReseller);
            sqlCommand.Parameters.AddWithValue("@Price_Dealer", queryData.priceDealer);
            sqlCommand.Parameters.AddWithValue("@Created_Date", queryData.createdDate);
            sqlCommand.Parameters.AddWithValue("@Sold", queryData.sold);
            sqlCommand.CommandTimeout = 60;

            con.Open();

            sqlCommand.ExecuteNonQuery();              

            con.Close();
        }
    }
}

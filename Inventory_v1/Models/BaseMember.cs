using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Inventory_v1.Models
{
	public class BaseMember   // base member er moddhe j function ta likhbo sei function er moddhe amr connectivity properties gulo thakbe
	{

        // property declaration way
        public int id { get; set; }  // property declare kora hoise 
        public string Name { get; set; }  // property declare kora hoise 
        public int Age { get; set; }  // property declare kora hoise 
        public string Password { get; set; }  // property declare kora hoise 
        public string ServiceType { get; set; }  // property declare kora hoise 

        public string Role { get; set; }  // property declare kora hoise 

        public string DashBoardPageURL { get; set; }  // property declare kora hoise


        // ekta function create kori jeta amr database er sathe connect kore
        public DataTable ValidateMemberAsDataTable(string Username, string Password)                                // function er name ValidateMember
        {
            DataTable dataTable = new DataTable();                          // data table object create kora hoise

            // Connection string theke use korte caile 
            string Connstring = ConfigurationManager.ConnectionStrings["Connstring"].ToString();    // Connection string ta amra web.config file theke nitechi
            
            // Appsettings theke use korte caile 
            //string Connstring = ConfigurationManager.AppSettings["ConnstringAppSetting"].ToString();  // Appsettings theke Connection string ta amra web.config file theke nitechi


            //sql connection
            SqlConnection sqlConnection = new SqlConnection(Connstring);  // sql connection object create kora hoise and connection string pass kora hoise
            sqlConnection.Open();                                         // connection open kora hoise 

            // sokol prokar query, calculation amra stored procedure e korbo, database level e korbo  


            string CommandText = "select * from Member where Name='"+ Username + "' and Password='"+ Password +"' ";
            //string CommandText = "select * from Member";

            //sql command
            SqlCommand cmd = new SqlCommand(CommandText, sqlConnection);  // sql command object create kora hoise
            cmd.CommandTimeout = 0;                                       // command timeout 0 kora hoise 
            cmd.CommandType = CommandType.Text;               // command type text kora hoise
            cmd.Parameters.Clear();                                       // parameter clear kora hoise 


            // table data 
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);             // sql data adapter object create kora hoise and command pass kora hoise
            adapter.Fill(dataTable);                                     // data table fill kora hoise
            
            cmd.Dispose();          // command dispose kora hoise
            sqlConnection.Close();  // connection close kora hoise


            return dataTable;       // data table return korbe

        }





        public DataTable ValidateMemberAsDataTableBySP(string Username, string Password)                                // function er name ValidateMember
        {
            DataTable dataTable = new DataTable();                          // data table object create kora hoise

            // Connection string theke use korte caile 
            string Connstring = ConfigurationManager.ConnectionStrings["Connstring"].ToString();    // Connection string ta amra web.config file theke nitechi

            // Appsettings theke use korte caile 
            //string Connstring = ConfigurationManager.AppSettings["ConnstringAppSetting"].ToString();  // Appsettings theke Connection string ta amra web.config file theke nitechi


            //sql connection
            SqlConnection sqlConnection = new SqlConnection(Connstring);  // sql connection object create kora hoise and connection string pass kora hoise
            sqlConnection.Open();                                         // connection open kora hoise 

            // sokol prokar query, calculation amra stored procedure e korbo, database level e korbo  

            //sql command
            SqlCommand cmd = new SqlCommand("spOst_LstMember", sqlConnection);  //  

            cmd.CommandTimeout = 0;                                       // command timeout 0 kora hoise 
            cmd.CommandType = CommandType.StoredProcedure;                // Command type stored procedure 
            cmd.Parameters.Clear();                                       // parameter clear kora hoise 
            cmd.Parameters.Add(new SqlParameter("@Username", Username));
            cmd.Parameters.Add(new SqlParameter("@Username", Password));

            // table data 
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);             // sql data adapter object create kora hoise and command pass kora hoise
            adapter.Fill(dataTable);                                      // data table fill kora hoise

            cmd.Dispose();          // command dispose kora hoise
            sqlConnection.Close();  // connection close kora hoise


            return dataTable;       // data table return korbe

        }








        public List<BaseMember> ValidateMemberAsList(string Username, string Password)                                // function er name ValidateMember
        {
            List<BaseMember> listMember = new List<BaseMember>();               // list object create kora hoise

            // Connection string theke use korte caile 
            string Connstring = ConfigurationManager.ConnectionStrings["Connstring"].ToString();    // Connection string ta amra web.config file theke nitechi

            // Appsettings theke use korte caile 
            //string Connstring = ConfigurationManager.AppSettings["ConnstringAppSetting"].ToString();  // Appsettings theke Connection string ta amra web.config file theke nitechi


            //sql connection
            SqlConnection sqlConnection = new SqlConnection(Connstring);  // sql connection object create kora hoise and connection string pass kora hoise
            sqlConnection.Open();                                         // connection open kora hoise 

            // sokol prokar query, calculation amra stored procedure e korbo, database level e korbo  


            string CommandText = "select * from Member";
            //sql command
            SqlCommand cmd = new SqlCommand(CommandText, sqlConnection);  // sql command object create kora hoise
            cmd.CommandTimeout = 0;                                       // command timeout 0 kora hoise 
            cmd.CommandType = CommandType.Text;               // command type text kora hoise
            cmd.Parameters.Clear();                                       // parameter clear kora hoise 

            // List akare nite caile 
            SqlDataReader reader = cmd.ExecuteReader();                   // sql data reader object create kora hoise 
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // amra jodi kono kaj korte chai tahole ei block e kaj korbo
                    BaseMember objMember = new BaseMember();  // base member class er object create kora hoise
                    objMember.Name = reader["Name"].ToString();  // reader theke data read kora hoise
                    objMember.Password = reader["Password"].ToString();  // reader theke data read kora hoise
                    objMember.id = Convert.ToInt16( reader["id"].ToString());  // reader theke data read kora hoise
                    objMember.Age = Convert.ToInt16(reader["Age"].ToString());  // reader theke data read kora hoise
                    objMember.ServiceType = reader["ServiceType"].ToString();  // reader theke data read kora hoise

                    listMember.Add(objMember);


                }
            }

            cmd.Dispose();          // command dispose kora hoise
            sqlConnection.Close();  // connection close kora hoise


            return listMember;  // username and password admin na hole false return korbe

        }


    }
}
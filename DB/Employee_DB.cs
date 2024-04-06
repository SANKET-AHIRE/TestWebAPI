using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestWebAPI.Models;

namespace TestWebAPI.DB
{
    public class Employee_DB
    {
        private SqlConnection con;
        private void connection()
        {
            try
            { 
                string constring = ConfigurationManager.ConnectionStrings["DB"].ToString();
                con = new SqlConnection(constring);

            }
            catch (Exception ex)
            {
              //Exception Logic
            }

        }
        public int RegisterNewEmployee(Request_Employee employee)
        {
            int count = 0;
          
            try
            {
                connection();
                SqlCommand cmd = null;
                con.Open();

                cmd = new SqlCommand("Insert into tbl_employee(Name,Surname,City,Gender,Mobile,EmailID)values(@Name,@Surname,@City,@Gender,@Mobile,@EmailID)",con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Surname", employee.Name);
                cmd.Parameters.AddWithValue("@City", employee.Name);
                cmd.Parameters.AddWithValue("@Gender", employee.Name);
                cmd.Parameters.AddWithValue("@Mobile", employee.Name);
                cmd.Parameters.AddWithValue("@EmailID", employee.Name);
                count = cmd.ExecuteNonQuery();
            
                con.Close();
              
            }
            catch (Exception ex)
            {
                //Exception Logic

            }
            return count;
        }

        public int isEmployeesPresent()
        {
            int count = 0;
            DataTable dt = new DataTable();

            try
            {
                connection();
                SqlCommand cmd = null;
                con.Open();

                cmd = new SqlCommand("Select count(*) from tbl_employee", con);
                cmd.CommandType = CommandType.Text;
                count = (int)cmd.ExecuteScalar();
                con.Close();

            }
            catch (Exception ex)
            {
                //Exception Logic
            }
            return count;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestTask.Models;

namespace TestTask.Repository
{
    public class CompanyRepository
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Employee details
        public bool AddCompany(Company obj)
        {

            Connection();
            SqlCommand com = new SqlCommand("AddNewCompanyDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@name", obj.Name);
            com.Parameters.AddWithValue("@size", obj.Size);
            com.Parameters.AddWithValue("@form", obj.Form);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            return false;
        }
        //To view employee details with generic list 
        public List<Company> GetAllCompanies()
        {
            Connection();
            List<Company> CompanyList = new List<Company>();
            SqlCommand com = new SqlCommand("GetCompanies", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind EmpModel generic list using LINQ 
            CompanyList = (from DataRow dr in dt.Rows

                select new Company()
                {
                    CompanyId = Convert.ToInt32(dr["id"]),
                    Name = Convert.ToString(dr["name"]),
                    Size = Convert.ToInt32(dr["size"]),
                    Form = Convert.ToString(dr["form"])
                }).ToList();


            return CompanyList;


        }
        //To Update Employee details
        public bool UpdateCompany(Company obj)
        {

            Connection();
            SqlCommand com = new SqlCommand("UpdateCompanyDetails", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", obj.CompanyId);
            com.Parameters.AddWithValue("@name", obj.Name);
            com.Parameters.AddWithValue("@size", obj.Size);
            com.Parameters.AddWithValue("@form", obj.Form);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            return false;
        }
        //To delete Employee details
        public bool DeleteCompany(int Id)
        {

            Connection();
            SqlCommand com = new SqlCommand("DeleteCompanyById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            return false;
        }

    }
}
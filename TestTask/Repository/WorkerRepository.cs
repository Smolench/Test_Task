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
    public class WorkerRepository
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Employee details
        public bool AddWorker(Worker obj)
        {

            Connection();
            SqlCommand com = new SqlCommand("AddNewWorkerDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@first_name", obj.FirstName);
            com.Parameters.AddWithValue("@second_name", obj.SecondName);
            com.Parameters.AddWithValue("@middle_name", obj.MiddleName);
            com.Parameters.AddWithValue("@entry_date", obj.EntryDate);
            com.Parameters.AddWithValue("@position", obj.Position);
            com.Parameters.AddWithValue("@company", obj.Company);

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
        public List<Worker> GetAllWorkers()
        {
            Connection();
            List<Worker> workerList = new List<Worker>();
            SqlCommand com = new SqlCommand("GetWorkers", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind EmpModel generic list using LINQ 
            workerList = (from DataRow dr in dt.Rows

                select new Worker()
                {
                    WorkerId = Convert.ToInt32(dr["id"]),
                    FirstName = Convert.ToString(dr["first_name"]),
                    SecondName = Convert.ToString(dr["second_name"]),
                    MiddleName = Convert.ToString(dr["middle_name"]),
                    EntryDate = Convert.ToDateTime(dr["entry_date"]),
                    Position = Convert.ToString(dr["position"]),
                    Company = Convert.ToString(dr["company"])
                }).ToList();


            return workerList;


        }
        //To Update Employee details
        public bool UpdateWorker(Worker obj)
        {

            Connection();
            SqlCommand com = new SqlCommand("UpdateWorkerDetails", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@first_name", obj.FirstName);
            com.Parameters.AddWithValue("@second_name", obj.SecondName);
            com.Parameters.AddWithValue("@middle_name", obj.MiddleName);
            com.Parameters.AddWithValue("@entry_date", obj.EntryDate.Date);
            com.Parameters.AddWithValue("@position", obj.Position);
            com.Parameters.AddWithValue("@company", obj.Company);

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
        public bool DeleteWorker(int Id)
        {

            Connection();
            SqlCommand com = new SqlCommand("DeleteWorkerById", con);

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
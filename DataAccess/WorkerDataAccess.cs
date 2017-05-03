using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace DataAccess
{
    public class WorkerDataAccess :IWorkerDataAccess
    {
        private string connectionString;

        public WorkerDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddWorker(Worker worker)
        {
            string expression = $"INSERT INTO Worker (LastName, FirstName, MiddleName,EntryDate, Position, CompanyId) VALUES" +
                                $"('{worker.LastName}','{worker.FirstName}','{worker.MiddleName}',convert(date,'{worker.EntryDate}',104),'{worker.Position}',{worker.CompanyId})";
            Execute(expression);
        }

        public void EditWorker(int id, Worker worker)
        {
            string expression =
                $"UPDATE Worker SET LastName = '{worker.LastName}', FirstName = '{worker.FirstName}', MiddleName = '{worker.MiddleName}', EntryDate = convert(date,'{worker.EntryDate}',104)," +
                $"Position = '{worker.Position}', CompanyId = {worker.CompanyId} " +
                $"WHERE WorkerId = {worker.WorkerId}";
            Execute(expression);
        }

        public void DeleteWorker(int id)
        {
            string expression = $"DELETE FROM Worker WHERE WorkerId = {id}";
            Execute(expression);
        }

        public Worker GetWorker(int id)
        {
            string expression = $"SELECT * FROM Worker WHERE WorkerId = {id}";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(expression, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                return new Worker()
                {
                    WorkerId = (int)dataReader["WorkerId"],
                    LastName = (string)dataReader["LastName"],
                    FirstName = (string)dataReader["FirstName"],
                    MiddleName = (string)dataReader["MiddleName"],
                    EntryDate = (DateTime)dataReader["EntryDate"],
                    Position = (string)dataReader["Position"],
                    CompanyId = (int)dataReader["CompanyId"]
                };
            }
        }

        public IEnumerable<Worker> GetAllWorkers()
        {
            List<Worker> workers = new List<Worker>();
            string expression = $"SELECT * FROM Workers";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(expression, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    workers.Add(new Worker()
                    {
                        WorkerId = (int)dataReader["WorkerId"],
                        LastName = (string)dataReader["LastName"],
                        FirstName = (string)dataReader["FirstName"],
                        MiddleName = (string)dataReader["MiddleName"],
                        EntryDate = (DateTime)dataReader["EntryDate"],
                        Position = (string)dataReader["Position"],
                        CompanyId = (int)dataReader["CompanyId"]
                    });
                }
            }
            return workers;
        }

        private void Execute(string expression)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(expression, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}

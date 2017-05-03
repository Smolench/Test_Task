using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace DataAccess
{
    public class CompanyDataAccess :ICompanyDataAccess
    {
        private string connectionString;

        public CompanyDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddCompany(Company company)
        {
            string expression = $"INSERT INTO Company (Name, Size, Form) VALUES" +
                                $"('{company.Name}',{company.Size},'{company.Form}')";
            Execute(expression);
        }

        public void EditCompany(int id, Company company)
        {
            string expression =
                $"UPDATE Company SET Name = '{company.Name}', Size = {company.Size}, Form = '{company.Form}'" +
                $"WHERE CompanyId = {id}";
            Execute(expression);
        }

        public void DeleteCompany(int id)
        {
            string expression = $"DELETE FROM Company WHERE CompanyID = {id}";
            Execute(expression);
        }

        public Company GetCompany(int id)
        {
            string expression = $"SELECT * FROM Company WHERE CompanyId = {id}";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(expression, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                return new Company()
                {
                    CompanyId = (int)dataReader["CompanyId"],
                    Name = (string)dataReader["Name"],
                    Size = (int)dataReader["Size"],
                    Form = (string)dataReader["Form"]
                };
            }
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            List<Company> companies = new List<Company>();
            string expression = "SELECT * FROM Company";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(expression, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    companies.Add(new Company()
                    {
                        CompanyId = (int)dataReader["CompanyId"],
                        Name = (string)dataReader["Name"],
                        Size = (int)dataReader["Size"],
                        Form = (string)dataReader["Form"]
                    });
                }
            }
            return companies;
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

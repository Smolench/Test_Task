using System.Collections.Generic;
using DataModels;

namespace DataAccess
{
    public interface ICompanyDataAccess
    {
        void AddCompany(Company company);

        void EditCompany(int id, Company company);

        void DeleteCompany(int id);

        Company GetCompany(int id);

        IEnumerable<Company> GetAllCompanies();
    }
}

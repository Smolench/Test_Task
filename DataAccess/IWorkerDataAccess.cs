using System.Collections.Generic;
using DataModels;

namespace DataAccess
{
    public interface IWorkerDataAccess
    {
        void AddWorker(Worker worker);

        void EditWorker(int id,Worker worker);

        void DeleteWorker(int id);

        Worker GetWorker(int id);

        IEnumerable<Worker> GetAllWorkers();
    }
}

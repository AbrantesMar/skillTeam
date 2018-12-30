using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SkillTeam.Models.Repository
{
    public interface IEmployeeRepository
    {
        Task<Employee> FindById(ObjectId id);
        Task<List<Employee>> GetAll();
        void Delete(ObjectId id);
        void Edit(Employee employee);

    }
}
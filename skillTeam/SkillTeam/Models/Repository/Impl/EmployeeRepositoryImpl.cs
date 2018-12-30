using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SkillTeam.Models.Repository.Impl
{
    public class EmployeeRepositoryImpl : IEmployeeRepository
    {
        private DBContext _dbContext;

        public EmployeeRepositoryImpl()
        {
            _dbContext = new DBContext();

        }
        public async void Delete(ObjectId id)
        {
            await _dbContext.Employees.DeleteOneAsync(e => e.Id == id);
        }

        public async void Edit(Employee employee)
        {
            await _dbContext.Employees.ReplaceOneAsync(e => e.Id == employee.Id, employee);
        }

        public async Task<Employee> FindById(ObjectId id)
        {
            var entity = await _dbContext.Employees.FindAsync(e => e.Id == id);
            return entity.FirstOrDefault();
        }

        public async Task<List<Employee>> GetAll()
        {
            var entity = await _dbContext.Employees.FindAsync(e => true);
            return entity.ToList();
        }
    }
}
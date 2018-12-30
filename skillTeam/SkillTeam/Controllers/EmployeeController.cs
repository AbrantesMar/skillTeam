using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTeam.Models;
using SkillTeam.Models.Repository;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SkillTeam.Controllers
{
    //TODO: Referencia: https://www.qappdesign.com/using-mongodb-with-net-core-webapi/
    [Route("api/[controller]")]
    [Authorize()]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

        }

        [HttpGet] 
        public async Task<IEnumerable<Employee>> Index()
        {
            DBContext dbContext = new DBContext();
            var entiry = await dbContext.Employees.FindAsync(_ => true);
            return entiry.ToList();
        }

        [HttpPost("add")]
        public async void Add(Employee employee)
        {
            DBContext dbContext = new DBContext();
            //employee.Id = Guid.NewGuid();
            await dbContext.Employees.InsertOneAsync(employee);
        }

        [HttpPost("delete")]
        public async void Delete(ObjectId id)
        {
            _employeeRepository.Delete(id);
            
        }

        [HttpPost("edit")]
        public async void Edit(Employee employee)
        {
            _employeeRepository.Edit(employee);
        }

        [HttpPost("findById")]
        public async Task<Employee> FindEmployeeById(ObjectId id)
        {
            return await _employeeRepository.FindById(id);
        }

    }
}
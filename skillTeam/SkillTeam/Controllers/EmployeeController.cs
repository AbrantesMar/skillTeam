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
        [HttpGet] 
        public async Task<IEnumerable<Employee>> Index()
        {
            DBContext dbContext = new DBContext();
            var entiry = await dbContext.Employees.FindAsync(_ => true);
            return entiry.ToList();
        }

        [HttpPost]
        public async void Add(Employee employee)
        {
            DBContext dbContext = new DBContext();
            //employee.Id = Guid.NewGuid();
            await dbContext.Employees.InsertOneAsync(employee);
        }

        [HttpPost]
        public async void Delete(ObjectId id)
        {
            DBContext dBContext = new DBContext();
            await dBContext.Employees.DeleteOneAsync(e => e.Id == id);
        }

        [HttpPost]
        public async void Edit(Employee employee)
        {
            DBContext dbContext = new DBContext();
            var entity = await dbContext.Employees.ReplaceOneAsync(e => e.Id == employee.Id, employee);
        }

        public async Task<Employee> FindEmployeeById(ObjectId id)
        {
            DBContext context = new DBContext();
            var entity = await context.Employees.FindAsync(e => e.Id == id);
            return entity.FirstOrDefault();
        }

    }
}
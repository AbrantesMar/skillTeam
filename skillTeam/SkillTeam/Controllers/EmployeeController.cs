using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTeam.Models;
using SkillTeam.Models.Repository;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

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
            var entiry = dbContext.Employees.FindAsync(_ => true);
            return entiry.ToList();
        }

        [HttpPost]
        public async void Add(Employee employee)
        {
            DBContext dbContext = new DBContext();
            employee.Id = Guid.NewGuid();
            await dbContext.Employees.InsertOneAsync(employee);
        }

        [HttpPost]
        public async void Delete(ObjectId id)
        {
            DBContext dBContext = new DBContext();
            await dBContext.Employees.DeleteOneAsync(e => e.Id == id);
        }

        public async Task<Employee> Edit(Employee employee)
        {
            if(employee == null)
                return BadRequest();
            DBContext dbContext = new DBContext();
            return Ok(await dbContext.Employees.ReplaceOneAsync(e => e.Id == employee.Id, employee));
            
        }

    }
}
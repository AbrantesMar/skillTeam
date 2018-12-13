using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTeam.Models;

namespace SkillTeam.Controllers
{
    [Route("api/[controller]")]
    [Authorize()]
    public class EmployeeController : Controller
    {
        public IActionResult Index(){
            return new RedirectResult("~/swagger");
        }

        public IActionResult Add(Employee employee){
            return View();
        }

        public IActionResult Delete(int id){
            return View();
        }

        public IActionResult MyProperty { get; set; }

    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEmpleado.Data;
using ProyectoEmpleado.Models;

namespace ProyectoEmpleado.Controllers
{
    public class EmployeeController : Controller
    {

        public readonly BaseContext _context;

        public EmployeeController(BaseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var userName = HttpContext.Session.GetString("UserName");
            ViewBag.UserName = userName;
            
            return View(await _context.Employee.ToArrayAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee e)
        {
            _context.Employee.Add(e);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index", "Home");
        }

    }
}
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEmpleado.Data;
using ProyectoEmpleado.Models;
using ProyectoEmpleado.Helpers;
using Microsoft.VisualBasic;

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
            var userId = HttpContext.Session.GetInt32("userId");

            ViewBag.UserName = userName;
            ViewBag.UserId = userId;

            //guardian
            if (ViewBag.UserId != null)
            {
                return View(await _context.Register.Where(m => m.IdEmpleado == userId).ToArrayAsync());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            // return View(await _context.Register.ToListAsync());

        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee e)
        {
            var pass = new PasswordHasher(); //instancia  del hasher

            var password = e.Password; //var temp password guarda el valor del password ingresado

            var hasPassword = pass.HashPassword(password); //se hashea la password

            e.Password = hasPassword; // se asigna el valor de la contraseña hashea en la contraseña que envia el usuario
            _context.Employee.Add(e); 
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserName");
            HttpContext.Session.Remove("userId");
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> EntryTimeEmployee()
        {
            var userId = HttpContext.Session.GetInt32("userId");
            //botones desactivar
            // var offFechaSalida = await _context.Register.FirstOrDefaultAsync(x=>x.IdEmpleado == userId && x.FechaIngreso== null);
            // if (offFechaSalida != null)
            // {
            //     var fechaSalidaOff = new Register
            //     {

            //     };
            // }

            if (userId != null)
            {
                var EntryTime = new Register
                {
                    // nos da el valor de IdEmpleado usando userId
                    IdEmpleado = userId.Value,
                    FechaIngreso = DateTime.Now,
                };

                _context.Register.Add(EntryTime);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                // Si userId es null
                return RedirectToAction("Index", "Employee");
            }
        }

        public async Task<IActionResult> DepartureTimeEmployee()
        {
            var userId = HttpContext.Session.GetInt32("userId");
            var entry = _context.Register.FirstOrDefault(x => x.IdEmpleado == userId && x.FechaSalida ==null);
            if(userId != null)
            {
                entry.FechaSalida = DateTime.Now;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Employee");
            }
            else{
                // Si userId es null
                return RedirectToAction("Index", "Employee");
            }

            
        }
        public async Task<IActionResult> ListEmploye()
        {
            return View(await _context.Employee.ToListAsync());
        }
    

        public IActionResult DeleteEmployee(int id)
        {

            var employee = _context.Employee.Find(id);
            _context.Employee.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }
    }
}
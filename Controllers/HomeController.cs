using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoEmpleado.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using ProyectoEmpleado.Data;
using Microsoft.AspNetCore.Http;

namespace ProyectoEmpleado.Controllers;

public class HomeController : Controller
{
    // private readonly ILogger<HomeController> _logger;

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }

    // public IActionResult Index()
    // {
    //     return View();
    // }

    // public IActionResult Privacy()
    // {
    //     return View();
    // }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }

    public readonly BaseContext _context;

        public HomeController(BaseContext context)
        {
            _context = context;
        }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Login(string email, string password)
    {   

        var user = await _context.Employee.FirstOrDefaultAsync(n=>n.Email == email && n.Password == password);
     
        if (user != null)
        {
            HttpContext.Session.SetString("UserName", user.Name);
            return RedirectToAction("Index", "Employee");
        }
        else
        {
            //ViewBag.ErrorMessage = "Correo electrónico o contraseña incorrectos";
            return RedirectToAction("Index", "Home");
        }
    }
}

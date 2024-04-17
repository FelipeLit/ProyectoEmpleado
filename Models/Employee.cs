using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ProyectoEmpleado.Models
{
    public class Employee
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public  string Password { get; set; }

    }

    
}
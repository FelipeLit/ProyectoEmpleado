using Microsoft.EntityFrameworkCore;
using ProyectoEmpleado.Models;

namespace ProyectoEmpleado.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base (options)
        {

        }
        public DbSet <Employee> Employee { get; set;}
        public DbSet <Register> Register { get; set;}

    }
}

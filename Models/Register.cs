namespace ProyectoEmpleado.Models
{
    public class Register
    {
        public int Id { get; set; }
        public string FechaIngreso { get; set; }
        public string FechaSalida { get; set; }
        public string IdEmpleado { get; set; }

        // public Employee Employee { get; set; }
    }
//     public class Employee
// {
//     public string Nombre { get; set; }
  
//     // Propiedad de navegación para acceder a los registros asociados
//     public ICollection<Employee> Employees { get; set; }
// }
}
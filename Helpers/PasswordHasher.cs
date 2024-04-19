using BCryptNet = BCrypt.Net.BCrypt;

namespace ProyectoEmpleado.Helpers
{

    public class PasswordHasher
    {
        public string HashPassword(string password)
        {
            //se genera el el cifrado
            string hashedPassword = BCryptNet.HashPassword(password, BCryptNet.GenerateSalt());
            return hashedPassword;
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            //verificar si las contraseñas coinciden
            bool passwordMatch = BCryptNet.Verify(providedPassword, hashedPassword);
            return passwordMatch;
        }

    }
}

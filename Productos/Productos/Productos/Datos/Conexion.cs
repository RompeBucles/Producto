using System.Data.SqlClient;

namespace Productos.Datos
{
    public class Conexion 
    {
        private string conexionBD = string.Empty;
        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            conexionBD = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string getCadenaSQL()
        {
            return conexionBD;
        }
    }
}

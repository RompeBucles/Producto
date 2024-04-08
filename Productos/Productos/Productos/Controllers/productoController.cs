using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Productos.Models;

namespace Productos.Controllers
{
    public class productoController : Controller
    {
        private string connectionString = "Server=localhost;Database=producto;Integrated Security=true;";

        // Método para mostrar la lista de usuarios
        public ActionResult Index()
        {
            DataTable dtProductos = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("sp_listar", con);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.Fill(dtProductos);
            }
            return View(dtProductos);
        }

        // Método para crear un nuevo usuario
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ProductosModel producto)
        {
            if(!ModelState.IsValid)
                return View();
            try
            {

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_guardar", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", producto.nombre);
                    cmd.Parameters.AddWithValue("@Categoria", producto.categoria);
                    cmd.Parameters.AddWithValue("@Precio", producto.precio);
                    cmd.Parameters.AddWithValue("@Fecha", producto.fecha);
                    cmd.ExecuteNonQuery();
                }
               

            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index");
        }

        // Método para editar un usuario
        public ActionResult Editar(int id)
        {

            ProductosModel producto = new ProductosModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("sp_obtener", con);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@Id", id);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    producto.id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    producto.nombre = dt.Rows[0]["nombre"].ToString();
                    producto.categoria = dt.Rows[0]["categoria"].ToString();
                    producto.precio = Convert.ToInt32(dt.Rows[0]["precio"]);
                    producto.fecha = Convert.ToDateTime(dt.Rows[0]["fecha"]);
                    return View(producto);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpPost]
        public ActionResult Editar(ProductosModel producto)
        {

            if (!ModelState.IsValid)
                return View();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_editar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", producto.id);
                cmd.Parameters.AddWithValue("@Nombre", producto.nombre);
                cmd.Parameters.AddWithValue("@Categoria", producto.categoria);
                cmd.Parameters.AddWithValue("@Precio", producto.precio);
                cmd.Parameters.AddWithValue("@Fecha", producto.fecha);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

      

        // Método para eliminar un usuario
        public ActionResult Eliminar(int id)
        {
         
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_eliminar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}

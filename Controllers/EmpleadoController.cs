using Microsoft.Data.SqlClient; // <-- Cambia System.Data por Microsoft.Data
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EjemploForm.Models;

namespace EjemploForm.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly string connectionString = "Data Source=clsqln02;Initial Catalog=DataRmsa_desa;Integrated Security=True;Encrypt=False";


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear([FromBody] Empleado empleado)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Ejemplo1 (Nombre, Apellido) VALUES (@Nombre, @Apellido)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Json(new { success = true });
                    }
                }
                return Json(new { success = false });

            }
        }
    }
}



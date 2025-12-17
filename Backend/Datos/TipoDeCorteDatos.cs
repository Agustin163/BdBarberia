using MySql.Data.MySqlClient;
using System.Data;
using BdBarberia.Entidades;

namespace BdBarberia.Datos
{
    public class TipoDeCorteDatos
    {
        private string cadenaConexion =
            "server=localhost;database=BdBarberia;user=root;password=TU_PASSWORD;";

        // LISTAR
        public DataTable Listar()
        {
            DataTable tabla = new DataTable();
            string sql = "SELECT * FROM TipoDeCorte";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conexion);
                adapter.Fill(tabla);
            }

            return tabla;
        }

        // INSERTAR
        public void Insertar(TipoDeCorte corte)
        {
            string sql = "INSERT INTO TipoDeCorte (tipo, precio) VALUES (@tipo, @precio)";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@tipo", corte.Tipo);
                cmd.Parameters.AddWithValue("@precio", corte.Precio);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // MODIFICAR
        public void Modificar(TipoDeCorte corte)
        {
            string sql = @"UPDATE TipoDeCorte 
                           SET tipo=@tipo, precio=@precio 
                           WHERE idTipoDeCorte=@id";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@tipo", corte.Tipo);
                cmd.Parameters.AddWithValue("@precio", corte.Precio);
                cmd.Parameters.AddWithValue("@id", corte.IdTipoDeCorte);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ELIMINAR
        public void Eliminar(int id)
        {
            string sql = "DELETE FROM TipoDeCorte WHERE idTipoDeCorte=@id";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@id", id);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

using MySql.Data.MySqlClient;
using System.Data;

namespace BdBarberia
{
    public class ConexionTipoDeCorte
    {
        string cadena = "server=localhost;database=BdBarberia;user=root;password=TU_PASSWORD;";

        public DataTable Listar()
        {
            DataTable tabla = new DataTable();
            string sql = "SELECT * FROM TipoDeCorte";

            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                da.Fill(tabla);
            }
            return tabla;
        }

        public void Agregar(string tipo, decimal precio)
        {
            if (string.IsNullOrWhiteSpace(tipo))
                throw new Exception("El tipo no puede estar vacío");

            if (precio <= 0)
                throw new Exception("El precio debe ser mayor a 0");

            string sql = "INSERT INTO TipoDeCorte (tipo, precio) VALUES (@tipo, @precio)";

            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@precio", precio);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(int id, string tipo, decimal precio)
        {
            if (string.IsNullOrWhiteSpace(tipo))
                throw new Exception("El tipo no puede estar vacío");

            if (precio <= 0)
                throw new Exception("El precio debe ser mayor a 0");

            string sql = "UPDATE TipoDeCorte SET tipo=@tipo, precio=@precio WHERE idTipoDeCorte=@id";

            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            string sql = "DELETE FROM TipoDeCorte WHERE idTipoDeCorte=@id";

            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

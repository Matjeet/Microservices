using CapaNegocio;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ConexionBBDD : DatosRepositorio
    {
        private SqlConnection _connection;

        public ConexionBBDD()
        {
            _connection = new SqlConnection(@"Password=sa;Persist Security Info=True;User ID=sa;Initial Catalog=MSHabitaciones;Data Source=MATEO\SQLEXPRESS01");
        }

        public HabitacionDTO consultarInfoHabitacion(int idHabitacion)
        {
            _connection.Open();
            string query = string.Format(
                "SELECT * FROM Habitaciones WHERE idHabitacion = {0}",
                idHabitacion
                );
            SqlCommand sqlCommand = new SqlCommand(query, _connection);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            HabitacionDTO habitacionDTO = new HabitacionDTO();

            while( reader.Read())
            {
                habitacionDTO.idHabitacion = idHabitacion;
                habitacionDTO.Costo = int.Parse(reader.GetValue(1).ToString());
            }

            _connection.Close();

            return habitacionDTO;
        }
    }
}
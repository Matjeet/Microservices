using CapaNegocio;
using System.Data.SqlClient;
using System.Globalization;

namespace CapaDatos
{
    public class ConexionBBDD : DatosReservaRepositorio
    {
        private SqlConnection _connection;

        public ConexionBBDD()
        {
            _connection = new SqlConnection(@"Password=sa;Persist Security Info=True;User ID=sa;Initial Catalog=MSReservas;Data Source=MATEO\SQLEXPRESS01");
        }

        public bool guardarInfoReserva(int ccCliente, int idHabitacion, string fecha, int costo)
        {
                       
            _connection.Open();
            DateTime fechaDate = DateTime.Parse(fecha); 
            string query = string.Format(
                "INSERT INTO Reservas (" +
                "idHabitacion, " +
                "ccCLiente, " +
                "fecha, " +
                "valorAPagar" +
                ") " +
                "VALUES({0}, {1}, '{2}', {3}) ",
                idHabitacion,
                ccCliente,
                fechaDate.ToString("yyyy-MM-dd"),
                costo
                );
            SqlCommand sqlCommand = new SqlCommand(query, _connection);

            int rows = sqlCommand.ExecuteNonQuery();

            if( rows > 0 )
            {
                _connection.Close();
                return true;
            }
            else
            {
                _connection.Close();
                return false;
            }
        }

        public ReservaDTO consultarReserva(int idHabitacion)
        {
            _connection.Open();
            string query = string.Format(
                "SELECT * FROM Reservas WHERE idHabitacion = {0}",
                idHabitacion
                );

            SqlCommand sqlCommand = new SqlCommand(query, _connection);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            ReservaDTO reservaDTO = new ReservaDTO();

            while (reader.Read())
            {
                reservaDTO.idReserva = int.Parse(reader.GetValue(0).ToString());
                reservaDTO.idHabitacion = idHabitacion;
                reservaDTO.ccCliente = int.Parse(reader.GetValue(2).ToString());
                DateTime fechaOriginal = DateTime.ParseExact(reader.GetValue(3).ToString(), "dd/MM/yyyy hh:mm:ss tt", null);
                reservaDTO.fecha = fechaOriginal.ToString("yyyy-MM-dd");
                reservaDTO.costo = int.Parse(reader.GetValue(4).ToString());
          
            }

            _connection.Close();

            return reservaDTO;
        }

    }
}
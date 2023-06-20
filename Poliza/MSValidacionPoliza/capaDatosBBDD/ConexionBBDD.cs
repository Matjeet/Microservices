using capaNegocio;
using System.Data.SqlClient;

namespace capaDatosBBDD
{
    public class ConexionBBDD : datosValidacionRepositorio
    {
        SqlConnection conn;

        public ConexionBBDD()
        {
            conn = new SqlConnection(@"Password=sa;Persist Security Info=True;User ID=sa;Initial Catalog=MSValidaciones;Data Source=MATEO\SQLEXPRESS01");
        }
        public bool guardarResultadoPoliza(string placa, int ccCliente, string resultado)
        {
            conn.Open();
            string query = string.Format(
                "INSERT INTO Polizas (placa, ccCliente, resultado) VALUES('{0}', {1}, '{2}')",
                placa,
                ccCliente,
                resultado
                );
            SqlCommand sqlCommand = new SqlCommand( query, conn );
            int rows = sqlCommand.ExecuteNonQuery();

            if(rows > 0 )
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false; 
            }

        }
    }
}
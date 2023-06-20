using capaNegocio;
using System.Data.SqlClient;

namespace capaDatos
{
    public class ConexionBBDD : datosAccidentesRepositorio
    {

        private SqlConnection conn;

        public ConexionBBDD()
        {
            conn = new SqlConnection(@"Password=sa;Persist Security Info=True;User ID=sa;Initial Catalog=MSFaseColda;Data Source=MATEO\SQLEXPRESS01");
        }

        public AccidentesDTO consultarAccidentes(string placa)
        {
            conn.Open();
            string query = string.Format(
                "SELECT severidad FROM Accidentes WHERE placa = '{0}'",
                placa
                );
            SqlCommand cmd = new SqlCommand( query, conn );

            SqlDataReader reader = cmd.ExecuteReader();
            AccidentesDTO accidentes = new AccidentesDTO();

            while ( reader.Read())
            {
                if (reader.GetValue(0).ToString().Equals("Solo latas"))
                {
                    accidentes.soloLatas += 1;
                }
                if (reader.GetValue(0).ToString().Equals("Heridos"))
                {
                    accidentes.heridos += 1;
                }
                if (reader.GetValue(0).ToString().Equals("Muertos"))
                {
                    accidentes.muertos += 1;
                }
            }

            return accidentes;
        }
    }
}
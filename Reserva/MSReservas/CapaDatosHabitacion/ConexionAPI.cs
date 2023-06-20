using CapaNegocio;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Nodes;

namespace CapaDatosHabitacion
{
    public class ConexionAPI : DatosHabitacionRepositorio
    {
        public HabitacionDTO consultarCostoHabitacion(int idHabitacion)
        {
            HabitacionDTO habitacion = new HabitacionDTO();

            string url = @"http://localhost:5030/consultaHabitacion/"+idHabitacion;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);

                string respuesta = sr.ReadToEnd();
                habitacion = JsonConvert.DeserializeObject<HabitacionDTO>(respuesta);
                return habitacion;

            }
            catch(Exception ex) 
            {
                return new HabitacionDTO();
            }
        }
    }
}
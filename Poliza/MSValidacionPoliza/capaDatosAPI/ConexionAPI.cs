using capaNegocio;
using System.Net;
using System.Text.Json.Serialization;
using Newtonsoft;
using Newtonsoft.Json;

namespace capaDatosAPI
{
    public class ConexionAPI : datosAccidentesRepositorio
    {
        public AccidentesDTO consultarAccidentes(string placa)
        {
            AccidentesDTO accidentes = new AccidentesDTO();

            string url = @"http://localhost:5193/api/Accidentes/consultarAccidentes/" + placa;

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
                accidentes = JsonConvert.DeserializeObject<AccidentesDTO>(respuesta);
                return accidentes;
            }
            catch (Exception ex)
            {
                return new AccidentesDTO();
            }
        }
    }
}
using capaDatos;
using capaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace capaPresentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccidentesController : ControllerBase
    {
        LogicaAccidentes logica = new LogicaAccidentes(new ConexionBBDD());
        [HttpGet]
        [Route("consultarAccidentes/{placa}")]
        public AccidentesDTO consultarAccidentes(string placa)
        {
            return logica.obtenerNumeroAccidentes(placa);
        }
    }
}

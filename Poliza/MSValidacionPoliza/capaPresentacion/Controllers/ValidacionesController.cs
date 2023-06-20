using capaDatosAPI;
using capaDatosBBDD;
using capaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace capaPresentacion.Controllers
{
    [ApiController]
    public class ValidacionesController : ControllerBase
    {
        LogicaValidacion logica = new LogicaValidacion(new ConexionAPI(), new ConexionBBDD());
        [HttpGet]
        [Route("polizaSeguros/{placa}/{ccCliente:int}")]
        public bool validarPoliza(string placa, int ccCliente)
        {
            return logica.validacionPolizaSeguros(placa, ccCliente);
        }
    }
}

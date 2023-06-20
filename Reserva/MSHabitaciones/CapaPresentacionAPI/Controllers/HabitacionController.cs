using CapaDatos;
using CapaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacionAPI.Controllers
{
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        Logica logica = new Logica(new ConexionBBDD());
        [HttpGet]
        [Route("consultaHabitacion/{idHabitacion:int}")]
        public HabitacionDTO consultarHabitacion(int idHabitacion)
        {
            return logica.obtenerInfoHabitacion(idHabitacion);
        }

    }
}

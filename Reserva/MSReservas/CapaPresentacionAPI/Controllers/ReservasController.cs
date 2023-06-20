using CapaDatos;
using CapaDatosHabitacion;
using CapaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacionAPI.Controllers
{
    [ApiController]
    public class ReservasController : ControllerBase
    {
        LogicaReservas logica = new LogicaReservas(new ConexionBBDD(), new ConexionAPI());

        [HttpGet]
        [Route("reservar/{idHabitacion:int}/{ccCliente:int}/{fecha}")]
        public string realizarReserva(int idHabitacion, int ccCliente, string fecha)
        {
            
            return this.logica.realizarReserva(idHabitacion,ccCliente, fecha);
        }

    }
}

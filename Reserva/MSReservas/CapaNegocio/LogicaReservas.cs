using Newtonsoft.Json;
using System.Globalization;

namespace CapaNegocio
{
    public class LogicaReservas
    {
        DatosReservaRepositorio datosReserva;
        DatosHabitacionRepositorio datosHabitacion;
        public LogicaReservas(DatosReservaRepositorio datosReserva,
            DatosHabitacionRepositorio datosHabitacion) 
        {
            this.datosReserva = datosReserva;
            this.datosHabitacion = datosHabitacion;
        }
        public string realizarReserva(int idHabitacion, int ccCliente, string fecha)
        {
            ReservaDTO consultareserva = datosReserva.consultarReserva(idHabitacion);
            HabitacionDTO habitacion = datosHabitacion.consultarCostoHabitacion(idHabitacion);
            dynamic jsonReserva = new System.Dynamic.ExpandoObject();
            
            if (consultareserva.idHabitacion == idHabitacion)
            {
                
                if (consultareserva.fecha == fecha)
                {
                    jsonReserva.reserva = false;
                    jsonReserva.mensaje = "La fecha ya está reservada";
                }
                else
                {
                    bool reserva = datosReserva.guardarInfoReserva(
                    ccCliente,
                    idHabitacion,
                    fecha,
                    habitacion.Costo
                    );
                    if (reserva)
                    {
 
                        jsonReserva.reserva = true;
                        jsonReserva.costo = habitacion.Costo;
                    }
                    else
                    {
                        jsonReserva.reserva = false;
                        jsonReserva.mensaje = "Ocurrió un error al reservar";
                    }
                }

            }
            else
            {
                bool reserva = datosReserva.guardarInfoReserva(
                    ccCliente,
                    idHabitacion,
                    fecha,
                    habitacion.Costo
                    );
                if (reserva)
                {
                    
                    jsonReserva.reserva = true;
                    jsonReserva.costo = habitacion.Costo;
                }
                else
                {
                    jsonReserva.reserva = false;
                    jsonReserva.mensaje = "Ocurrió un error al reservar";
                }
            }

            string jsonResponse = JsonConvert.SerializeObject(jsonReserva);
            return jsonResponse;
        }

    }
}
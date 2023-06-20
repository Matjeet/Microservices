using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ReservaDTO
    {
        public int idReserva { get; set; }
        public int idHabitacion { get; set; }
        public int ccCliente { get; set; }
        public string fecha { get; set; }
        public int costo { get; set; }

        public ReservaDTO(int idReserva, int idHabitacion, int ccCliente, string fecha, int costo)
        {
            this.idReserva = idReserva;
            this.idHabitacion = idHabitacion;
            this.ccCliente = ccCliente;
            this.fecha = fecha;
            this.costo = costo;
        }

        public ReservaDTO()
        {
        }
    }
}

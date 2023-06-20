using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class HabitacionDTO
    {
        public int idHabitacion { get; set; }
        public int Costo { get; set; }

        public HabitacionDTO(int idHabitacion, int costo)
        {
            this.idHabitacion = idHabitacion;
            Costo = costo;
        }

        public HabitacionDTO()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public interface DatosReservaRepositorio
    {
        public bool guardarInfoReserva(int ccCliente, int idHabitacion, string fecha, int costo);

        public ReservaDTO consultarReserva(int idHabitacion);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaNegocio
{
    public interface datosValidacionRepositorio
    {
        public bool guardarResultadoPoliza(string placa, int ccCliente, string resultado);
    }
}

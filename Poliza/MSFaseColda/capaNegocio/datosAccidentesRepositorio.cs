﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaNegocio
{
    public interface datosAccidentesRepositorio
    {
        public AccidentesDTO consultarAccidentes(string placa);
    }
}

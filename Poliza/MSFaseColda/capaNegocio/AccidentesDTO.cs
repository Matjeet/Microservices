using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaNegocio
{
    public class AccidentesDTO
    {
        public int soloLatas { get; set; }
        public int heridos { get; set; }
        public int muertos { get; set; }

        public AccidentesDTO(int soloLatas, int heridos, int muertos)
        {
            this.soloLatas = soloLatas;
            this.heridos = heridos;
            this.muertos = muertos;
        }

        public AccidentesDTO()
        {
        }
    }
}

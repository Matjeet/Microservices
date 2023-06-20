using System.Globalization;

namespace capaNegocio
{
    public class LogicaAccidentes
    {
        public datosAccidentesRepositorio datosAccidentes;

        public LogicaAccidentes(datosAccidentesRepositorio datosAccidentes)
        {
            this.datosAccidentes = datosAccidentes;
        }

        public AccidentesDTO obtenerNumeroAccidentes(string placa)
        {
            return this.datosAccidentes.consultarAccidentes(placa);
        }
    }
}
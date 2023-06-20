namespace capaNegocio
{
    public class LogicaValidacion
    {
        datosAccidentesRepositorio datosAccidentes;
        datosValidacionRepositorio datosValidacion;

        public LogicaValidacion(
            datosAccidentesRepositorio datosAccidentes, 
            datosValidacionRepositorio datosValidacion)
        {
            this.datosAccidentes = datosAccidentes;
            this.datosValidacion = datosValidacion;
        }

        public bool validacionPolizaSeguros(string placa, int ccCliente)
        {
            string resultado;
            AccidentesDTO accidentes = datosAccidentes.consultarAccidentes(placa);

            int totalPuntos = 
                (accidentes.soloLatas * 100) + 
                (accidentes.heridos*200) + 
                (accidentes.muertos*300);

            if(totalPuntos >= 400)
            {
                resultado = "Recahazado";
                datosValidacion.guardarResultadoPoliza(placa, ccCliente, resultado);
                return false;
            }
            else
            {
                resultado = "Aprobado";
                datosValidacion.guardarResultadoPoliza(placa, ccCliente, resultado);
                return true;
            }
        }
    }
}
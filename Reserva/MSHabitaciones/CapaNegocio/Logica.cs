namespace CapaNegocio
{
    public class Logica
    {
        private DatosRepositorio repositorio;

        public Logica(DatosRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public HabitacionDTO obtenerInfoHabitacion(int idHabitacion)
        {
            return this.repositorio.consultarInfoHabitacion(idHabitacion);
        }
    }
}
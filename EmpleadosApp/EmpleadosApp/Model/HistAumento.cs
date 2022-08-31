namespace EmpleadosApp.Model
{
    public class HistAumento
    {
        public int Id { get; set; }
        public double SalarioAnterior { get; set; }
        public double SalarioNuevo { get; set; }
        public string Fecha { get; set; }
        public Empleado Empleado { get; set; }
    }
}

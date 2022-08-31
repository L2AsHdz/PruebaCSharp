namespace EmpleadosApp.Model
{
    public class Empleado
    {
        public string CUI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public double Sueldo { get; set; }
        public string FechaIngreso { get; set; }
        public string FechaBaja { get; set; }
        public Puesto Puesto { get; set; }
        public Departamento Departamento { get; set; }
        public Empleado Jefe { get; set; }
    }
}

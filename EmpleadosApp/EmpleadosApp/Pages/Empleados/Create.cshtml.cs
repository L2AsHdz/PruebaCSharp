using EmpleadosApp.Data;
using EmpleadosApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmpleadosApp.Pages.Empleados
{
    public class CreateModel : PageModel
    {
        private readonly EmpleadoDAOImpl empleadoDAO = EmpleadoDAOImpl.Instance;
        private readonly DepartamentoDAOImpl departamentoDAO = DepartamentoDAOImpl.Instance;
        private readonly PuestoDAOImpl puestoDAO = PuestoDAOImpl.Instance;
        public List<Departamento> departamentos = new();
        public List<Puesto> puestos = new();
        public Empleado empleado = new();
        public string errorMessage = "";
        public void OnGet()
        {
            departamentos = departamentoDAO.ReadAll();
            puestos = puestoDAO.ReadAll();
        }

        public void OnPost()
        {
            empleado.CUI = Request.Form["cui"];
            empleado.Nombre = Request.Form["nombre"];
            empleado.Apellido = Request.Form["apellidos"];
            empleado.Departamento = new()
            {
                Id = int.Parse(Request.Form["departamento"])
            };
            empleado.Puesto = new()
            {
                Id = int.Parse(Request.Form["puesto"])
            };
            empleado.FechaIngreso = Request.Form["fecha"];
            empleado.Sueldo = double.Parse(Request.Form["sueldo"]);
            if (empleado.Nombre.Length == 0 || empleado.Apellido.Length == 0 || empleado.CUI.Length == 0)
            {
                errorMessage = "Los campos cui, nombre, apellidos, son obligatorios";
                return;
            }
            empleadoDAO.Create(empleado);
            empleado = new();
            Response.Redirect("/Empleados/Index");
        }
    }
}

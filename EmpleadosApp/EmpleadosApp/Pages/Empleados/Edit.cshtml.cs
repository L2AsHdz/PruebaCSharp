using EmpleadosApp.Data;
using EmpleadosApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmpleadosApp.Pages.Empleados
{
    public class EditModel : PageModel
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
            empleado.CUI = Request.Query["cui"];
            empleado = empleadoDAO.Read(empleado);
            
            departamentos = departamentoDAO.ReadAll();
            puestos = puestoDAO.ReadAll();
        }
    }
}

using EmpleadosApp.Data;
using EmpleadosApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmpleadosApp.Pages.Empleados
{
    public class BajaModel : PageModel
    {
        private readonly EmpleadoDAOImpl empleadoDAO = EmpleadoDAOImpl.Instance;
        public List<Empleado> empleados = new();
        public void OnGet()
        {
            empleados = empleadoDAO.ReadAllBajas();
        }
    }
}

using EmpleadosApp.Data;
using EmpleadosApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmpleadosApp.Pages.Empleados
{
    public class IndexModel : PageModel
    {
        private readonly EmpleadoDAOImpl empleadoDAO = EmpleadoDAOImpl.Instance;
        public List<Empleado> empleados = new();
        public void OnGet()
        {
            string cui = Request.Query["cui"];
            if (cui != null)
            {
                Empleado em = empleadoDAO.Read(new()
                {
                    CUI = cui
                });
                em.FechaBaja = DateTime.Now.ToString("yyyy-MM-dd");
                empleadoDAO.UpdateBaja(em);
                Response.Redirect("Baja");
            }
            empleados = empleadoDAO.ReadAll();
        }
    }
}

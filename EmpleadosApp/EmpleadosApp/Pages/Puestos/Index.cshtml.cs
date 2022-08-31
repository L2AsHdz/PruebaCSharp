using EmpleadosApp.Data;
using EmpleadosApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmpleadosApp.Pages.Puestos
{
    public class IndexModel : PageModel
    {
        private readonly PuestoDAOImpl puestoDAO = PuestoDAOImpl.Instance;
        public List<Puesto> puestos = new();
        public void OnGet()
        {
            puestos = puestoDAO.ReadAll();
        }
    }
}

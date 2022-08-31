using EmpleadosApp.Data;
using EmpleadosApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmpleadosApp.Pages.Empleados
{
    public class AumentosModel : PageModel
    {
        private readonly HistAumentoDAOImpl histDAO = HistAumentoDAOImpl.Instance;
        public List<HistAumento> aumentos = new();
        public void OnGet()
        {
            string cui = Request.Query["cui"];
            aumentos = histDAO.ReadAllByCUI(cui);
        }
    }
}

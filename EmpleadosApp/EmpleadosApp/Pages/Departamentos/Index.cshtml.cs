using EmpleadosApp.Data;
using EmpleadosApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmpleadosApp.Pages.Departamentos
{
    public class IndexModel : PageModel
    {
        private readonly DepartamentoDAOImpl departamentoDAO = DepartamentoDAOImpl.Instance;
        public List<Departamento> departamentos = new();
        public void OnGet()
        {
            departamentos = departamentoDAO.ReadAll();
        }
    }
}

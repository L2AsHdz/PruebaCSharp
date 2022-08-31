using EmpleadosApp.Data;
using EmpleadosApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmpleadosApp.Pages.Departamentos
{
    public class CreateModel : PageModel
    {
        private readonly DepartamentoDAOImpl departamentoDAO = DepartamentoDAOImpl.Instance;
        public Departamento departamento = new();
        public string errorMessage = "";
        
        public void OnGet()
        {
        }

        public void OnPost()
        {
            departamento.Nombre = Request.Form["nombre"];
            departamento.Presupuesto = double.Parse(Request.Form["presupuesto"]);
            departamento.Descripcion = Request.Form["desc"];

            if (departamento.Nombre.Length == 0)
            {
                errorMessage = "El campo nombre es obligatorio";
                return;
            }
            departamentoDAO.Create(departamento);
            departamento = new();
            Response.Redirect("/Departamentos/Index");
        }
    }
}

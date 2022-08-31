using EmpleadosApp.Data;
using EmpleadosApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmpleadosApp.Pages.Puestos
{
    public class CreateModel : PageModel
    {
        private readonly PuestoDAOImpl puestoDAO = PuestoDAOImpl.Instance;
        public Puesto puesto = new();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            puesto.Nombre = Request.Form["nombre"];
            puesto.Descripcion = Request.Form["desc"];

            if (puesto.Nombre.Length == 0)
            {
                errorMessage = "El campo nombre es obligatorio";
                return;
            }
            puestoDAO.Create(puesto);
            puesto = new();
            successMessage = "Nuevo puesto creado";
            Response.Redirect("/Puestos/Index");
        }
    }
}

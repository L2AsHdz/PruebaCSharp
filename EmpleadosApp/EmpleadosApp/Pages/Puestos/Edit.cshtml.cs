using EmpleadosApp.Data;
using EmpleadosApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmpleadosApp.Pages.Puestos
{
    public class EditModel : PageModel
    {
        private readonly PuestoDAOImpl puestoDAO = PuestoDAOImpl.Instance;
        public Puesto puesto = new();
        public string errorMessage = "";
        public void OnGet()
        {
            puesto.Id = int.Parse(Request.Query["id"]);

            puesto = puestoDAO.Read(puesto);
        }
        
        public void OnPost()
        {
            puesto.Id = int.Parse(Request.Form["id"]);
            puesto.Nombre = Request.Form["nombre"];
            puesto.Descripcion = Request.Form["desc"];

            if (puesto.Nombre.Length == 0)
            {
                errorMessage = "El campo nombre es obligatorio";
                return;
            }
            puestoDAO.Update(puesto);
            Response.Redirect("/Puestos/Index");
        }
    }
}

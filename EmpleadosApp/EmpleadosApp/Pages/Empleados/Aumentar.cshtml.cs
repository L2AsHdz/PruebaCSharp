using EmpleadosApp.Data;
using EmpleadosApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace EmpleadosApp.Pages.Empleados
{
    public class AumentarModel : PageModel
    {
        private readonly EmpleadoDAOImpl empleadoDAO = EmpleadoDAOImpl.Instance;
        private readonly HistAumentoDAOImpl histDAO = HistAumentoDAOImpl.Instance;
        public Empleado empleado = new();
        public HistAumento hist = new();
        public String errorMessage = "";
        public void OnGet()
        {
            string cui = Request.Query["cui"];
            empleado = empleadoDAO.Read(new() { CUI = cui });
        }

        public void OnPost()
        {
            String sueldoNuevo = Request.Form["sueldoN"];
            String cui = Request.Form["cui"];
            String sueldo = Request.Form["sueldo"];
            if (sueldoNuevo == null || sueldoNuevo.Length == 0)
            {
                errorMessage = "El sueldo nuevo es un campo obligatorio";
                return;
            }

            
            hist.Empleado = new()
            {
                CUI = cui
            };
            hist.SalarioAnterior = double.Parse(sueldo);
            hist.SalarioNuevo = double.Parse(sueldoNuevo);
            hist.Fecha = DateTime.Now.ToString("yyyy-MM-dd");
            Console.WriteLine("cui: " + hist.Empleado.CUI);
            Console.WriteLine(empleado.CUI);
            Console.WriteLine(empleado.Sueldo);


            empleado = new()
            {
                CUI = cui,
                Sueldo = double.Parse(sueldoNuevo)
            };
            empleadoDAO.UpdateSueldo(empleado);
            histDAO.Create(hist);
            Response.Redirect("/Empleados/Index");
        }
    }
}

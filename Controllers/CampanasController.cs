using Microsoft.AspNetCore.Mvc;
using PortalCampanas.Models;
using System.Linq;

namespace PortalCampanas.Controllers
{
    public class CampanasController : Controller
    {
        private static List<Campana> campanas = new List<Campana>
        {
            new Campana { Id = 1, Nombre = "Promo TV", Categoria="Electro", Estado="Vigente", Canal="Web", DescuentoPct=20, FechaInicio=DateTime.Now, FechaFin=DateTime.Now.AddDays(10), Descripcion="Descuento en TVs" },
            new Campana { Id = 2, Nombre = "Ropa Verano", Categoria="Moda", Estado="Próxima", Canal="App", DescuentoPct=15, FechaInicio=DateTime.Now.AddDays(5), FechaFin=DateTime.Now.AddDays(15), Descripcion="Ofertas verano" }
        };

        // INDEX CON FILTROS
        public IActionResult Index(string categoria, string estado)
        {
            var lista = campanas.AsQueryable();

            if (!string.IsNullOrEmpty(categoria))
                lista = lista.Where(c => c.Categoria == categoria);

            if (!string.IsNullOrEmpty(estado))
                lista = lista.Where(c => c.Estado == estado);

            return View(lista.ToList());
        }

        // DETALLE
        public IActionResult Detalle(int id)
        {
            var campana = campanas.FirstOrDefault(c => c.Id == id);

            if (campana == null)
                return NotFound();

            return View(campana);
        }

        // RESUMEN
        public IActionResult Resumen()
        {
            var total = campanas.Count;
            var vigentes = campanas.Count(c => c.Estado == "Vigente");
            var proximas = campanas.Count(c => c.Estado == "Próxima");
            var promedio = campanas.Average(c => c.DescuentoPct);

            ViewBag.Total = total;
            ViewBag.Vigentes = vigentes;
            ViewBag.Proximas = proximas;
            ViewBag.Promedio = promedio;

            return View();
        }
    }
}
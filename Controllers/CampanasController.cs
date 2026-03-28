using Microsoft.AspNetCore.Mvc;
using PortalCampanas.Models;
using System.Linq; // IMPORTANTE

namespace PortalCampanas.Controllers
{
    public class CampanasController : Controller
    {
        private static List<Campana> campanas = new List<Campana>
        {
            new Campana { Id = 1, Nombre = "Promo TV", Categoria="Electro", Estado="Vigente", Canal="Web", DescuentoPct=20, FechaInicio=DateTime.Now, FechaFin=DateTime.Now.AddDays(10), Descripcion="Descuento en TVs" },
            new Campana { Id = 2, Nombre = "Ropa Verano", Categoria="Moda", Estado="Próxima", Canal="App", DescuentoPct=15, FechaInicio=DateTime.Now.AddDays(5), FechaFin=DateTime.Now.AddDays(15), Descripcion="Ofertas verano" }
        };

        public IActionResult Index()
        {
            return View(campanas);
        }

        // 🔥 MÉTODO DETALLE (ESTO TE FALTABA)
        public IActionResult Detalle(int id)
        {
            var campana = campanas.FirstOrDefault(c => c.Id == id);

            if (campana == null)
                return NotFound();

            return View(campana);
        }
    }
}
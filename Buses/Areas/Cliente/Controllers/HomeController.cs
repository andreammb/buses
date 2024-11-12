using Buses.Data.Data.Repository.IRepository;
using Buses.Models;
using Buses.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Buses.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
        private readonly IContenedor _contenedor;

        public HomeController(IContenedor contenedor)
        {
            _contenedor = contenedor;
        }
        [HttpGet]
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Buses = _contenedor.Bus.GetAll(),
                Rutas = _contenedor.Ruta.GetAll(),
                Sliders = _contenedor.Slider.GetAll(),
            };

            ViewBag.IsHome = true;
            return View(homeVM);
        }
        [HttpGet]
        public IActionResult SearchResult(string searchText, int page =1, int pagSize = 6) 
        {
            var rutas = _contenedor.Ruta.AsQueryable();
            if (!string.IsNullOrEmpty(searchText))
            {
                rutas = (rutas.Where(e => e.Origen.Contains(searchText)));
            }
            var rutasPaginadas = rutas.Skip((page -1) * pagSize).Take(pagSize);
            var model = new ListaPaginada<Ruta>(rutasPaginadas.ToList(), rutas.Count(), page, pagSize, searchText);
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            HomeVM homeVM = new HomeVM();
            {
                homeVM.Ruta = _contenedor.Ruta.Get(id);
                homeVM.Buses = _contenedor.Bus.GetAll()
                    .Where(b => b.RutaId == id)
                    .ToList();
                    }
                
            return View(homeVM);
        }
        [HttpGet]
        public IActionResult Reservar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reservar(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _contenedor.Reserva.Add(reserva);
                _contenedor.Save();
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

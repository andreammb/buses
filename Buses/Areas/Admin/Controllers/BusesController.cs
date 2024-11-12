using Buses.Data.Data.Repository.IRepository;
using Buses.Models;
using Buses.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Buses.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BusesController : Controller
    {
        private readonly IContenedor _contenedor;
        public BusesController(IContenedor contenedor)
        {
            _contenedor = contenedor;
        }
        [HttpGet]
        public IActionResult Index()
           
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()

        {
            BusVM busvm = new BusVM()
            {
                Bus = new Buses.Models.Bus(),
                ListaRutas = _contenedor.Ruta.GetListaRutas()
                
            };
            return View(busvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BusVM busvm)
        {
            if (ModelState.IsValid)
            {
                _contenedor.Bus.Add(busvm.Bus);
                _contenedor.Save();

                return RedirectToAction(nameof(Index));
            }
            busvm.ListaRutas = _contenedor.Ruta.GetListaRutas();
            return View(busvm);
        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id)
        {
            BusVM busVM = new BusVM()
            {
                Bus = new Buses.Models.Bus(),
                ListaRutas = _contenedor.Ruta.GetListaRutas()

            };
            if( id != null)
            {
                busVM.Bus = _contenedor.Bus.Get(id.GetValueOrDefault());
            }
            return View(busVM); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BusVM busVM)
        {
            if (ModelState.IsValid)
            {
                 _contenedor.Bus.Update(busVM.Bus);
                _contenedor.Save();

                return RedirectToAction(nameof(Index));

            }

            return View(busVM);
        }

        #region LLamadas API

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedor.Bus.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedor.Bus.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error al eliminar bus" });
            }

            _contenedor.Bus.Remove(objFromDb);
            _contenedor.Save();
            return Json(new { success = true, message = "Bus eliminado Correctamente" });
        }

        #endregion
    }
}

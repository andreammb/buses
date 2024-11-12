using Buses.Data.Data.Repository.IRepository;
using Buses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System;

namespace Buses.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RutasController : Controller
    {
        private readonly IContenedor _contenedor;
        public RutasController(IContenedor contenedor)
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ruta ruta)
        {
            if (ModelState.IsValid)
            {
                _contenedor.Ruta.Add(ruta);
                _contenedor.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(ruta);
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {

            if (id < 0)
            {
                return NotFound();
            }
            Ruta ruta = _contenedor.Ruta.Get(id);
           
            if (ruta == null)
            {
                return NotFound();
            }
            return View(ruta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ruta ruta)
        {
            if (ModelState.IsValid)
            {
                _contenedor.Ruta.Update(ruta);
                _contenedor.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(ruta);
        }

        #region LLamadas API

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new {data = _contenedor.Ruta.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)     
        {
            var objFromDb = _contenedor.Ruta.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, Message = "Error al eliminar ruta" });
            }
            _contenedor.Ruta.Remove(objFromDb);
            _contenedor.Save();
            return Json(new { success = true, Message = "La ruta se eliminó correctamente" });
        }
        #endregion

    }
}

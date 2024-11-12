using Buses.Data.Data.Repository.IRepository;
using Buses.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System;

namespace Buses.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly IContenedor _contenedor;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public SlidersController(IContenedor contenedor, IWebHostEnvironment hostingEnvironment)
        {
            _contenedor = contenedor;
            _hostingEnvironment = hostingEnvironment;
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
        public IActionResult Create(Slider slider)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                if (archivos.Count() > 0)
                {
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\sliders");
                    var extension = Path.GetExtension(archivos[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    slider.UrlImagen = @"\imagenes\sliders\" + nombreArchivo + extension;

                    _contenedor.Slider.Add(slider);
                    _contenedor.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Imagen", "Debes seleccionar una imagen");
                }

            }

            return View(slider);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if (id != null)
            {
                var slider = _contenedor.Slider.Get(id.GetValueOrDefault());
                return View(slider);
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Slider slider)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var sliderDdesdeBd = _contenedor.Slider.Get(slider.Id);

                if (archivos.Count() > 0)
                {
                    //Nuevo imagen slider
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\sliders");
                    var extension = Path.GetExtension(archivos[0].FileName);

                    //var nuevaExtension = Path.GetExtension(archivos[0].FileName);

                    var rutaImagen = Path.Combine(rutaPrincipal, sliderDdesdeBd.UrlImagen.TrimStart('\\'));

                    if (System.IO.File.Exists(rutaImagen))
                    {
                        System.IO.File.Delete(rutaImagen);
                    }

                    //Nuevamente subimos el archivo
                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }


                    slider.UrlImagen = @"\imagenes\sliders\" + nombreArchivo + extension;

                    _contenedor.Slider.Update(slider);
                    _contenedor.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //Aquí sería cuando la imagen ya existe y se conserva
                    slider.UrlImagen = sliderDdesdeBd.UrlImagen;
                }

                _contenedor.Slider.Update(slider);
                _contenedor.Save();

                return RedirectToAction(nameof(Index));

            }

            return View(slider);
        }
 

        #region LLamadas API

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new {data = _contenedor.Slider.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)     
        {
            var sliderDesdeBd = _contenedor.Slider.Get(id);
            string rutaDirectorioPrincipal = _hostingEnvironment.WebRootPath;
            var rutaImagen = Path.Combine(rutaDirectorioPrincipal, sliderDesdeBd.UrlImagen.TrimStart('\\'));
            if (System.IO.File.Exists(rutaImagen))
            {
                System.IO.File.Delete(rutaImagen);
            }


            if (sliderDesdeBd == null)
            {
                return Json(new { success = false, message = "Error borrando promoción" });
            }

            _contenedor.Slider.Remove(sliderDesdeBd);
            _contenedor.Save();
            return Json(new { success = true, message = "Promoción borrada Correctamente" });

        }
        #endregion

    }
}

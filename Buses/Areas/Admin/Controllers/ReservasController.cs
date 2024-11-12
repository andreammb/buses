using Buses.Data.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Buses.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservasController : Controller
    {
        private readonly IContenedor _contenedor;
        public ReservasController(IContenedor contenedor)
        {
            _contenedor = contenedor;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #region LLamadas API

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedor.Reserva.GetAll(includeProperties:"Ruta,Bus") });
        }

        #endregion
    }
}

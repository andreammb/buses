using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buses.Models.ViewModels
{
    public class BusVM
    {
        public Bus? Bus { get; set; }

        public Ruta? RutaId { get; set; }
        public IEnumerable<Bus> Buses { get; set; }

        public IEnumerable<SelectListItem> ListaRutas { get; set; }
    }
}

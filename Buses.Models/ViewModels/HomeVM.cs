using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buses.Models.ViewModels
{
    public class HomeVM
    {
        public Ruta Ruta { get; set; }
        public Reserva Reserva { get; set; }
        public IEnumerable<Bus> Buses{ get; set; }
        public IEnumerable<Ruta> Rutas { get; set; }
        public IEnumerable<Slider> Sliders { get; set; }
    }
}

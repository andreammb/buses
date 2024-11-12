using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buses.Models
{
    public class Ruta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el destino")]
        public required string Destino { get; set; }

        [Required(ErrorMessage = "Ingrese el origen")]
        public required string Origen { get; set; }

        [Required(ErrorMessage = "Ingrese la cantidad de buses disponibles")]
        public int BusesDisponibles { get; set; }
        [Display(Name = "Buses disponibles")]

        [Required(ErrorMessage = "Ingrese los horarios")]
        public required string Horarios { get; set; }

        [Required(ErrorMessage = "Ingrese el precio")]
        public required double Precio { get; set; }
        



    }
}

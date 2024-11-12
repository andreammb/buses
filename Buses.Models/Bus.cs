using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buses.Models
{
    public class Bus
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el horario")]
        public string Horario { get; set; }

        [Display(Name ="Asientos reservados")]
        public int[] AsientosReservados { get; set; }

        [Required(ErrorMessage = "La ruta es obligatoria")]
        public int RutaId { get; set; }

        [ForeignKey("RutaId")]
        public Ruta Ruta { get; set; }
    }
}

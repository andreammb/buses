using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buses.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }
        public string Asiento { get; set; }
        public required bool Pagado { get; set; }
        public int BusId { get; set; }

        [ForeignKey("BusId")]
        public Bus Bus { get; set; }
        public required string UsuarioId { get; set; }

    }
}

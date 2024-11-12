using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buses.Models
{
    public class AppUser : IdentityUser
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "La dirección es obligatorio")]
        public required string Direccion { get; set; }

        [Required(ErrorMessage = "El telefono electrónico es obligatorio")]

        public List<Reserva> ListaReservas { get; set; }
    }
}

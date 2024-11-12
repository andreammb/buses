using Buses.Data.Data.Repository.IRepository;
using Buses.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buses.Data.Data.Repository
{
    internal class RutaRepository : Repository<Ruta>, IRutaRepository
    {
        private readonly ApplicationDbContext _context;

        public RutaRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public IQueryable<Ruta> AsQueryable()
        {
            return _context.Set<Ruta>().AsQueryable();
        }

        public IEnumerable<SelectListItem> GetListaRutas()
        {
            return _context.Ruta.Select(i => new SelectListItem()
            {
                Text = i.Origen + " - " + i.Destino,
                Value = i.Id.ToString()
            });
        }
        public void Update(Ruta ruta)
        {
            var objFromDb = _context.Ruta.FirstOrDefault(r => r.Id == ruta.Id);
            objFromDb.Destino = ruta.Destino;
            objFromDb.Horarios = ruta.Horarios;
            objFromDb.BusesDisponibles = (int)(ruta?.BusesDisponibles);
            objFromDb.Precio = ruta.Precio;

            //_context.SaveChanges();
        }
    }
}

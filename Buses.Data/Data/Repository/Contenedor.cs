using Buses.Data.Data.Repository.IRepository;
using Buses.Models;
using Buses.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buses.Data.Data.Repository
{
    public class Contenedor : IContenedor
    {
        private readonly ApplicationDbContext _context;
        public Contenedor(ApplicationDbContext context)
        {
            _context = context;
            Ruta = new RutaRepository(_context);
            Reserva = new ReservaRepository(_context);
            Bus = new BusRepository(_context);
            Slider = new SliderRepository(_context);    
        }

        public IRutaRepository Ruta { get; private set; }
        public IReservaRepository Reserva { get; private set; }
        public IBusRepository Bus { get; private set; }
        public ISliderRepository Slider { get; private set; }

        public void Dispose()
        {
           _context.Dispose();

        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

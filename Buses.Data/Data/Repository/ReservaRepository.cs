using Buses.Data.Data.Repository.IRepository;
using Buses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buses.Data.Data.Repository
{
    internal class ReservaRepository : Repository<Reserva>, IReservaRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservaRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public void Update(Reserva reserva)
        {
            var objFromDb = _context.Reserva.FirstOrDefault(r => r.Id == reserva.Id);
            objFromDb.Asiento = reserva.Asiento;
            objFromDb.Pagado = reserva.Pagado;
            objFromDb.BusId = reserva.BusId;
            objFromDb.UsuarioId = reserva.UsuarioId;

            //_context.SaveChanges();
        }
    }
}

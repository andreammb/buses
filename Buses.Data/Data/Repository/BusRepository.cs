using Buses.Data.Data.Repository.IRepository;
using Buses.Models;
using Buses.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buses.Data.Migrations;

namespace Buses.Data.Data.Repository
{
    internal class BusRepository : Repository<Bus>, IBusRepository
    {
        private readonly ApplicationDbContext _context;

        public BusRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        } 

        public void Update(Bus bus)
        {
            var objFromDb = _context.Bus.FirstOrDefault(r => r.Id == bus.Id);
            objFromDb.AsientosReservados = bus.AsientosReservados;
            objFromDb.Horario = bus.Horario;
            objFromDb.RutaId = bus.RutaId;

            //_context.SaveChanges();
        }
    }
}

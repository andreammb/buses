using Buses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buses.Data.Data.Repository.IRepository
{
    public interface IReservaRepository : IRepository<Reserva>
    {
        void Update(Reserva reserva);
    }
}

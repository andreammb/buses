using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buses.Data.Data.Repository.IRepository
{
    public interface IContenedor : IDisposable
    {
        IReservaRepository Reserva {  get; }
        IRutaRepository Ruta { get; }
        IBusRepository Bus { get; }
        ISliderRepository Slider { get; }

        void Save();
    }
}

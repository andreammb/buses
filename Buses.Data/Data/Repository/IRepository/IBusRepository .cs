using Buses.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buses.Data.Data.Repository.IRepository
{
    public interface IBusRepository : IRepository<Bus>
    {
        void Update(Bus bus);
    }
}

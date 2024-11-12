﻿using Buses.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buses.Data.Data.Repository.IRepository
{
    public interface IRutaRepository : IRepository<Ruta>
    {
        void Update(Ruta ruta);
        IEnumerable<SelectListItem> GetListaRutas();

        IQueryable<Ruta> AsQueryable();
    }
}

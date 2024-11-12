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
    internal class SliderRepository : Repository<Slider>, ISliderRepository
    {
        private readonly ApplicationDbContext _context;

        public SliderRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        } 

        public void Update(Slider slider)
        {
            var objFromDb = _context.Slider.FirstOrDefault(r => r.Id == slider.Id);
            objFromDb.Nombre = slider.Nombre;
            objFromDb.Estado = slider.Estado;
            objFromDb.UrlImagen = slider.UrlImagen;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCaini_web.Models
{
    public class RezervareData
    {
        public IEnumerable<Rezervare> Rezervari { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<RezervareCategory> RezervareCategories { get; set; }
    }
}

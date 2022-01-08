using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCaini_web.Models
{
    public class RezervareCategory
    {
        public int ID { get; set; }

        
        public int RezervareID { get; set; }
        public Rezervare Rezervare { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}

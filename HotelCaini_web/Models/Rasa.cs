using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelCaini_web.Models
{
    public class Rasa
    {
        public int ID { get; set; }

        [Display(Name = "Rasa câinelui")]
        public string nume_rasa { get; set; } 
        public ICollection<Rezervare> Rezervari { get; set; }
    }
}

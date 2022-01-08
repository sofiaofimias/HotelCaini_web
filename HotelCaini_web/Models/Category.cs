using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCaini_web.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name = "Nume categorie")]
        public string Nume_category { get; set; }
        public ICollection<RezervareCategory> RezervareCategory { get; set; }
    }
}

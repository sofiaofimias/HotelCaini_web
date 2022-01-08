using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelCaini_web.Models
{
    public class Rezervare
    {
        public int ID { get; set; }

        [Display(Name = "Nume stăpân")]
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele stăpânului trebuie sa fie de forma 'Nume Prenume'"), Required, StringLength(50, MinimumLength = 3)]
        public string Nume_stapan { get; set; }



        [Display(Name = "Nume câine")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Numele câinelui trebuie sa fie de forma 'Nume'"), Required, StringLength(50, MinimumLength = 3)]

        public string Nume_caine { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Check-in")]
        public DateTime data_venire { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Check-out")]
        public DateTime data_plecare { get; set; }


        
        public int rasaID { get; set; }
        public Rasa Rasa { get; set; }


        [Display(Name = "Categorii")]
        public ICollection<RezervareCategory> RezervareCategories { get; set;  }

        
    }
}

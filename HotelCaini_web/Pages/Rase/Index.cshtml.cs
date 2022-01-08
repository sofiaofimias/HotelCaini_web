using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HotelCaini_web.Data;
using HotelCaini_web.Models;

namespace HotelCaini_web.Pages.Rase
{
    public class IndexModel : PageModel
    {
        private readonly HotelCaini_web.Data.HotelCaini_webContext _context;

        public IndexModel(HotelCaini_web.Data.HotelCaini_webContext context)
        {
            _context = context;
        }

        public IList<Rasa> Rasa { get;set; }

        public async Task OnGetAsync()
        {
            Rasa = await _context.Rasa.ToListAsync();
        }
    }
}

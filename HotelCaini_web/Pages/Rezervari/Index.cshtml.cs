using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HotelCaini_web.Data;
using HotelCaini_web.Models;

namespace HotelCaini_web.Pages.Rezervari
{
    public class IndexModel : PageModel
    {
        private readonly HotelCaini_web.Data.HotelCaini_webContext _context;

        public IndexModel(HotelCaini_web.Data.HotelCaini_webContext context)
        {
            _context = context;
        }

        public IList<Rezervare> Rezervare { get;set; }
        public RezervareData RezervareD { get; set; }
        public int RezervareID { get; set; }
        public int CategoryID { get; set; }


        public async Task OnGetAsync(int? id, int? categoryID)
        {
            RezervareD = new RezervareData();
            RezervareD.Rezervari = await _context.Rezervare
                .Include(b=>b.Rasa)
                .Include(b => b.RezervareCategories)
                .ThenInclude(b=>b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Nume_stapan)
                .ToListAsync();

            if (id != null)
            {
                RezervareID = id.Value;
                Rezervare rezervare = RezervareD.Rezervari
                   .Where(i => i.ID == id.Value).Single();
                RezervareD.Categories = rezervare.RezervareCategories.Select(s => s.Category);
            }


        }
    }
}

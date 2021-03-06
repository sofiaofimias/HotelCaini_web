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
    public class DeleteModel : PageModel
    {
        private readonly HotelCaini_web.Data.HotelCaini_webContext _context;

        public DeleteModel(HotelCaini_web.Data.HotelCaini_webContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rasa Rasa { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rasa = await _context.Rasa.FirstOrDefaultAsync(m => m.ID == id);

            if (Rasa == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rasa = await _context.Rasa.FindAsync(id);

            if (Rasa != null)
            {
                _context.Rasa.Remove(Rasa);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

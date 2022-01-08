using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelCaini_web.Data;
using HotelCaini_web.Models;

namespace HotelCaini_web.Pages.Rase
{
    public class CreateModel : PageModel
    {
        private readonly HotelCaini_web.Data.HotelCaini_webContext _context;

        public CreateModel(HotelCaini_web.Data.HotelCaini_webContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Rasa Rasa { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rasa.Add(Rasa);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

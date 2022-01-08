using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelCaini_web.Data;
using HotelCaini_web.Models;

namespace HotelCaini_web.Pages.Rezervari
{
    public class EditModel : RezervareCategoriesPageModel
    {
        private readonly HotelCaini_web.Data.HotelCaini_webContext _context;

        public EditModel(HotelCaini_web.Data.HotelCaini_webContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rezervare Rezervare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rezervare = await _context.Rezervare
                .Include(b=>b.Rasa)
                .Include(b=>b.RezervareCategories).ThenInclude(b=>b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Rezervare == null)
            {
                return NotFound();
            }


            PopulateAssignedCategoryData(_context, Rezervare);


            ViewData["rasaID"] = new SelectList(_context.Set<Rasa>(), "ID", "nume_rasa");
            
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervareToUpdate = await _context.Rezervare
                .Include(i => i.Rasa)
                .Include(i => i.RezervareCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);


            if(rezervareToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Rezervare>(
                rezervareToUpdate,
                "Rezervare",
                i=>i.Nume_stapan,
                i=>i.Nume_caine,
                i => i.data_venire,
                i => i.data_plecare,
                i => i.rasaID))
            {
                UpdateRezervareCategories(_context, selectedCategories, rezervareToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateRezervareCategories(_context, selectedCategories, rezervareToUpdate);
            PopulateAssignedCategoryData(_context, rezervareToUpdate);
            return Page();

        }

           
    }
}

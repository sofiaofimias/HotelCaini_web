using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelCaini_web.Data;
using HotelCaini_web.Models;

namespace HotelCaini_web.Pages.Rezervari
{
    public class CreateModel : RezervareCategoriesPageModel
    {
        private readonly HotelCaini_web.Data.HotelCaini_webContext _context;

        public CreateModel(HotelCaini_web.Data.HotelCaini_webContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["rasaID"] = new SelectList(_context.Rasa, "ID", "nume_rasa");

            var rezervare = new Rezervare();
            rezervare.RezervareCategories = new List<RezervareCategory>();
            PopulateAssignedCategoryData(_context, rezervare);

            return Page();
        }

        [BindProperty]
        public Rezervare Rezervare { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newRezervare = new Rezervare();
            if (selectedCategories != null)
            {
                newRezervare.RezervareCategories = new List<RezervareCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new RezervareCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newRezervare.RezervareCategories.Add(catToAdd);
                }
            }

            if (await TryUpdateModelAsync<Rezervare>(
                newRezervare,
                "Rezervare",
                 i => i.Nume_stapan,
                i => i.Nume_caine,
                i => i.data_venire,
                i => i.data_plecare,
                i => i.rasaID
            ))
            {
                _context.Rezervare.Add(newRezervare);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newRezervare);
            return Page();
        }
    }
}

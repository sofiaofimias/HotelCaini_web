using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HotelCaini_web.Data;
using HotelCaini_web.Models;

namespace HotelCaini_web.Models
{
    public class RezervareCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(HotelCaini_webContext context, Rezervare rezervare)
        {
            var allCategories = context.Category;
            var rezervareCategories = new HashSet<int>(
                rezervare.RezervareCategories.Select(c => c.CategoryID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.Nume_category,
                    Assigned = rezervareCategories.Contains(cat.ID)
                }) ;
            }

        }

        public void UpdateRezervareCategories(HotelCaini_webContext context, string[] selectedCategories, Rezervare rezervareToUpdate)
        {
            if (selectedCategories == null)
            {
                rezervareToUpdate.RezervareCategories = new List<RezervareCategory>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var rezervareCategories = new HashSet<int>(rezervareToUpdate.RezervareCategories.Select(c => c.CategoryID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if(!rezervareCategories.Contains(cat.ID))
                    {
                        rezervareToUpdate.RezervareCategories.Add(new RezervareCategory
                        {
                            RezervareID = rezervareToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if(rezervareCategories.Contains(cat.ID))
                    {
                        RezervareCategory courseToRemove = rezervareToUpdate.RezervareCategories.SingleOrDefault(i => i.CategoryID == cat.ID);

                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}

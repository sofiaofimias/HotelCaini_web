using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotelCaini_web.Models;

namespace HotelCaini_web.Data
{
    public class HotelCaini_webContext : DbContext
    {
        public HotelCaini_webContext (DbContextOptions<HotelCaini_webContext> options)
            : base(options)
        {
        }

        public DbSet<HotelCaini_web.Models.Rezervare> Rezervare { get; set; }

        public DbSet<HotelCaini_web.Models.Rasa> Rasa { get; set; }

        public DbSet<HotelCaini_web.Models.Category> Category { get; set; }


    }
}

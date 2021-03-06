// <auto-generated />
using System;
using HotelCaini_web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelCaini_web.Migrations
{
    [DbContext(typeof(HotelCaini_webContext))]
    [Migration("20220108083231_Rasa")]
    partial class Rasa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelCaini_web.Models.Rasa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nume_rasa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Rasa");
                });

            modelBuilder.Entity("HotelCaini_web.Models.Rezervare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nume_caine")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nume_stapan")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("data_plecare")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("data_venire")
                        .HasColumnType("datetime2");

                    b.Property<int>("rasaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("rasaID");

                    b.ToTable("Rezervare");
                });

            modelBuilder.Entity("HotelCaini_web.Models.Rezervare", b =>
                {
                    b.HasOne("HotelCaini_web.Models.Rasa", "Rasa")
                        .WithMany("Rezervari")
                        .HasForeignKey("rasaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rasa");
                });

            modelBuilder.Entity("HotelCaini_web.Models.Rasa", b =>
                {
                    b.Navigation("Rezervari");
                });
#pragma warning restore 612, 618
        }
    }
}

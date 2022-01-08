using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelCaini_web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rezervare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume_stapan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nume_caine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    data_venire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_plecare = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervare", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervare");
        }
    }
}

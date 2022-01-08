using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelCaini_web.Migrations
{
    public partial class Rasa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "rasaID",
                table: "Rezervare",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Rasa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nume_rasa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rasa", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervare_rasaID",
                table: "Rezervare",
                column: "rasaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervare_Rasa_rasaID",
                table: "Rezervare",
                column: "rasaID",
                principalTable: "Rasa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervare_Rasa_rasaID",
                table: "Rezervare");

            migrationBuilder.DropTable(
                name: "Rasa");

            migrationBuilder.DropIndex(
                name: "IX_Rezervare_rasaID",
                table: "Rezervare");

            migrationBuilder.DropColumn(
                name: "rasaID",
                table: "Rezervare");
        }
    }
}

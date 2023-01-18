using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication27.Migrations
{
    public partial class FacilityToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColectieID",
                table: "Institutie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Colectie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeleColectiilor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colectie", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Institutie_ColectieID",
                table: "Institutie",
                column: "ColectieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Institutie_Colectie_ColectieID",
                table: "Institutie",
                column: "ColectieID",
                principalTable: "Colectie",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institutie_Colectie_ColectieID",
                table: "Institutie");

            migrationBuilder.DropTable(
                name: "Colectie");

            migrationBuilder.DropIndex(
                name: "IX_Institutie_ColectieID",
                table: "Institutie");

            migrationBuilder.DropColumn(
                name: "ColectieID",
                table: "Institutie");
        }
    }
}

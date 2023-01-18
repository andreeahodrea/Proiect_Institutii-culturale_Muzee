using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication27.Migrations
{
    public partial class Exponat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExponatID",
                table: "Institutie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Exponat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireExponat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locatie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exponat", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Institutie_ExponatID",
                table: "Institutie",
                column: "ExponatID");

            migrationBuilder.AddForeignKey(
                name: "FK_Institutie_Exponat_ExponatID",
                table: "Institutie",
                column: "ExponatID",
                principalTable: "Exponat",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institutie_Exponat_ExponatID",
                table: "Institutie");

            migrationBuilder.DropTable(
                name: "Exponat");

            migrationBuilder.DropIndex(
                name: "IX_Institutie_ExponatID",
                table: "Institutie");

            migrationBuilder.DropColumn(
                name: "ExponatID",
                table: "Institutie");
        }
    }
}

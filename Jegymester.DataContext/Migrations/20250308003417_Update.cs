using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jegymester.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Screenings_MovieId",
                table: "Screenings");

            migrationBuilder.RenameColumn(
                name: "BuyerPhoneNumber",
                table: "Tickets",
                newName: "BuyerPhone");

            migrationBuilder.RenameColumn(
                name: "DurationMinutes",
                table: "Movies",
                newName: "Length");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_MovieId",
                table: "Screenings",
                column: "MovieId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Screenings_MovieId",
                table: "Screenings");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "BuyerPhone",
                table: "Tickets",
                newName: "BuyerPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Length",
                table: "Movies",
                newName: "DurationMinutes");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_MovieId",
                table: "Screenings",
                column: "MovieId");
        }
    }
}

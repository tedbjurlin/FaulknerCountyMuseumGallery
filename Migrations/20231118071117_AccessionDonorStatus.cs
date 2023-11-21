using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaulknerCountyMuseumGallery.Migrations
{
    /// <inheritdoc />
    public partial class AccessionDonorStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessionNumber",
                table: "Artwork",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Donor",
                table: "Artwork",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Artwork",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessionNumber",
                table: "Artwork");

            migrationBuilder.DropColumn(
                name: "Donor",
                table: "Artwork");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Artwork");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaulknerCountyMuseumGallery.Migrations
{
    /// <inheritdoc />
    public partial class AddedCollections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Artwork_CollectionID",
                table: "Artwork",
                column: "CollectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Artwork_Collection_CollectionID",
                table: "Artwork",
                column: "CollectionID",
                principalTable: "Collection",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artwork_Collection_CollectionID",
                table: "Artwork");

            migrationBuilder.DropIndex(
                name: "IX_Artwork_CollectionID",
                table: "Artwork");
        }
    }
}

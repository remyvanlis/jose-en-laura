using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JoseEnLaura.Migrations
{
    /// <inheritdoc />
    public partial class AddWeddingLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeddingLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VenueName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeddingLocations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "WeddingLocations",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "Icon", "Phone", "SortOrder", "Title", "TitleEn", "VenueName" },
                values: new object[,]
                {
                    { 1, "Almeloseweg 113, 7615 NA", "Harbrinkhoek", "&#9962;", "0546 629 962", 1, "Ceremonie", "Ceremony", "Kampkuiper" },
                    { 2, "Almeloseweg 113, 7615 NA", "Harbrinkhoek", "&#127860;", "0546 629 962", 2, "Diner", "Dinner", "Kampkuiper" },
                    { 3, "Almeloseweg 113, 7615 NA", "Harbrinkhoek", "&#127878;", "0546 629 962", 3, "Feest", "Party", "Kampkuiper" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeddingLocations");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test2.Migrations
{
    /// <inheritdoc />
    public partial class SeedPubHouses1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PublishingHouses",
                columns: new[] { "IdPublishingHouse", "City", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "Warsaw", "Poland", "Pub1" },
                    { 2, "Warsaw", "Poland", "Pub2" },
                    { 3, "Kharkiv", "Ukraine", "Pub3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PublishingHouses",
                keyColumn: "IdPublishingHouse",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PublishingHouses",
                keyColumn: "IdPublishingHouse",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PublishingHouses",
                keyColumn: "IdPublishingHouse",
                keyValue: 3);
        }
    }
}

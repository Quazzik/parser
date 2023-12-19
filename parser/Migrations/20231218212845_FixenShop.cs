using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace parser.Migrations
{
    /// <inheritdoc />
    public partial class FixenShop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ID", "ShopName", "Url" },
                values: new object[] { 1, "Fixen", "https://fixsen.ru" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace parser.Migrations
{
    /// <inheritdoc />
    public partial class addCersanit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ID", "ShopName", "Url" },
                values: new object[] { 2, "Cersanit", "https://cersanit.ru" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Name", "Price", "ShopID", "Url" },
                values: new object[] { 2, 1, "Зеркало Cersanit", 0u, 2, "https://cersanit.ru/catalog/3d-be/mebel-dlya-vannoy/zerkala/zerkalo-led-010-base-40/" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace parser.Migrations
{
    /// <inheritdoc />
    public partial class FixenProductAndCategoryedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "Url",
                value: "https://fixsen.ru/product/hotel-zerkalo-kosmeticheskoe-chernoe-d15-fx-31021b/");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "Url",
                value: "");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace parser.Migrations
{
    /// <inheritdoc />
    public partial class addedneptun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "Name",
                value: "Зеркало");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Name", "Url" },
                values: new object[] { "Газовый котёл", "https://neptun66.ru/catalog/kotly_i_vse_dlya_otopleniya/nastennyy_gazovyy_dvukhkonturnyy_kotel_federica_bugatti_varme_18/" });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ShopName", "Url" },
                values: new object[] { "Нептун66", "https://neptun66.ru" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "Name",
                value: "Товар");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Name", "Url" },
                values: new object[] { "Зеркало Cersanit", "https://cersanit.ru/catalog/3d-be/mebel-dlya-vannoy/zerkala/zerkalo-led-010-base-40/" });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ShopName", "Url" },
                values: new object[] { "Cersanit", "https://cersanit.ru" });
        }
    }
}

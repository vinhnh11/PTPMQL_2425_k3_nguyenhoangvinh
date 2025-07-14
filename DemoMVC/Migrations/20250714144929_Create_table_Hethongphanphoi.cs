using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoMVC.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_Hethongphanphoi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HethongphanphoiMaHTPP",
                table: "Dailys",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Hethongphanphois",
                columns: table => new
                {
                    MaHTPP = table.Column<string>(type: "TEXT", nullable: false),
                    TenHTPP = table.Column<string>(type: "TEXT", nullable: false),
                    TenHTPP2 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hethongphanphois", x => x.MaHTPP);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dailys_HethongphanphoiMaHTPP",
                table: "Dailys",
                column: "HethongphanphoiMaHTPP");

            migrationBuilder.AddForeignKey(
                name: "FK_Dailys_Hethongphanphois_HethongphanphoiMaHTPP",
                table: "Dailys",
                column: "HethongphanphoiMaHTPP",
                principalTable: "Hethongphanphois",
                principalColumn: "MaHTPP",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dailys_Hethongphanphois_HethongphanphoiMaHTPP",
                table: "Dailys");

            migrationBuilder.DropTable(
                name: "Hethongphanphois");

            migrationBuilder.DropIndex(
                name: "IX_Dailys_HethongphanphoiMaHTPP",
                table: "Dailys");

            migrationBuilder.DropColumn(
                name: "HethongphanphoiMaHTPP",
                table: "Dailys");
        }
    }
}

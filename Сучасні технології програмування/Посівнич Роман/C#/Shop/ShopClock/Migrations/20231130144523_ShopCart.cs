using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopClock.Migrations
{
    public partial class ShopCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopCartItems",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clockId = table.Column<int>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    ShopCartId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCartItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_ShopCartItems_Clocks_clockId",
                        column: x => x.clockId,
                        principalTable: "Clocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopCartItems_clockId",
                table: "ShopCartItems",
                column: "clockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopCartItems");
        }
    }
}

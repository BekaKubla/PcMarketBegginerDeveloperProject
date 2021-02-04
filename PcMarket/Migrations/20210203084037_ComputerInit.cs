using Microsoft.EntityFrameworkCore.Migrations;

namespace PcMarket.Migrations
{
    public partial class ComputerInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GetComputers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcesorType = table.Column<int>(type: "int", nullable: false),
                    ProcesorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Motherboard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemoryType = table.Column<int>(type: "int", nullable: false),
                    MemoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageType = table.Column<int>(type: "int", nullable: false),
                    StorageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPUType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPUName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Case = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PowerSupply = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetComputers", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetComputers");
        }
    }
}

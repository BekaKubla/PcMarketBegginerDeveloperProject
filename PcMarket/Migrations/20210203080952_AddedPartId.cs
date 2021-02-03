using Microsoft.EntityFrameworkCore.Migrations;

namespace PcMarket.Migrations
{
    public partial class AddedPartId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "GetPcParts");

            migrationBuilder.AddColumn<int>(
                name: "PartId",
                table: "GetOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartId",
                table: "GetOrders");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "GetPcParts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

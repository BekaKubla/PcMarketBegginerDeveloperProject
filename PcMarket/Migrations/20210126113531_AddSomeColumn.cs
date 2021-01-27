using Microsoft.EntityFrameworkCore.Migrations;

namespace PcMarket.Migrations
{
    public partial class AddSomeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PartName",
                table: "GetOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartPrice",
                table: "GetOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartName",
                table: "GetOrders");

            migrationBuilder.DropColumn(
                name: "PartPrice",
                table: "GetOrders");
        }
    }
}

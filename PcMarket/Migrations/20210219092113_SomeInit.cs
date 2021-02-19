using Microsoft.EntityFrameworkCore.Migrations;

namespace PcMarket.Migrations
{
    public partial class SomeInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartPriceWithoutC2",
                table: "GetPcParts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PartPrice",
                table: "GetOrders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartPriceWithoutC2",
                table: "GetPcParts");

            migrationBuilder.AlterColumn<int>(
                name: "PartPrice",
                table: "GetOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

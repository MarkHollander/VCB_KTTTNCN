using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qlud.KTTTNCN.Migrations
{
    public partial class AddToChucId_ChungtuKTTs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToChucId",
                table: "ChungTuKTTs",
                type: "int",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToChucId",
                table: "ChungTuKTTs");
        }
    }
}

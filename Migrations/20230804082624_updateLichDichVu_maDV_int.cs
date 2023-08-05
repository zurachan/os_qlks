using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quanlykhachsan.Migrations
{
    public partial class updateLichDichVu_maDV_int : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "madv",
                table: "lichdichvu",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "madv",
                table: "lichdichvu",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}

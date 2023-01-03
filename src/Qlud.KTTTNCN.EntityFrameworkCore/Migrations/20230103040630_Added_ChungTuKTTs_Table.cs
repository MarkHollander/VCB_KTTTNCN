using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qlud.KTTTNCN.Migrations
{
    public partial class Added_ChungTuKTTs_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BranchCode",
                table: "AbpUsers",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeptCode",
                table: "AbpUsers",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaCB",
                table: "AbpUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChungTuKTTs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaSoThue = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    QuocTich = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CuTru = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    NoiCap = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NgayCap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KhoanThuNhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BaoHiemBatBuoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ThoiDiemTraThuNhapThang = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ThoiDiemTraThuNhapNam = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    TongThuNhapChiuThue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TongThuNhapTinhThue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoThueTNCNDaKhauTru = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoThuNhapDuocNhan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KhoanDongGop = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ThoiGianNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianDuyet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserNhap = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserDuyet = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    MauSo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    KyHieu = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SoChungTu = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChungTuKTTs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToChucTraThuNhaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenToChuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaSoThue = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserNhap = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ThoiGianNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToChucTraThuNhaps", x => x.Id);
                });
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChungTuKTTs");

            migrationBuilder.DropTable(
                name: "ToChucTraThuNhaps");

            migrationBuilder.DropColumn(
                name: "BranchCode",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "DeptCode",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "MaCB",
                table: "AbpUsers");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quanlykhachsan.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chucvu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tencv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chucvu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "datdichvu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mapdp = table.Column<int>(type: "int", nullable: false),
                    madv = table.Column<int>(type: "int", nullable: false),
                    soluongdv = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datdichvu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dichvu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tendv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    giadv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dichvu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hoadon",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mapdp = table.Column<int>(type: "int", nullable: false),
                    manv = table.Column<int>(type: "int", nullable: false),
                    ngaythanhtoan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sotienthanhtoan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoadon", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "khanghang",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hoten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sdt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    diachi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khanghang", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lichdichvu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ngaygio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nhiemvu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    diadiem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ghichu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    madv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lichdichvu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "loaiphong",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenlp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    motaphong = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiphong", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nhanvien",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hoten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngaysinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    diachi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gioitinh = table.Column<bool>(type: "bit", nullable: false),
                    macv = table.Column<int>(type: "int", nullable: false),
                    cccd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngayvaolam = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sdt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhanvien", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "phieudatphong",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    makh = table.Column<int>(type: "int", nullable: false),
                    maphong = table.Column<int>(type: "int", nullable: false),
                    ngaynhanphong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngaytraphong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tongtien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phieudatphong", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "phong",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    malp = table.Column<int>(type: "int", nullable: false),
                    succhua = table.Column<int>(type: "int", nullable: false),
                    tang = table.Column<int>(type: "int", nullable: false),
                    giaphong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phong", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "quyen",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenquyen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quyen", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "taikhoan",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tendangnhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    matkhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    manv = table.Column<int>(type: "int", nullable: false),
                    maquyen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taikhoan", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chucvu");

            migrationBuilder.DropTable(
                name: "datdichvu");

            migrationBuilder.DropTable(
                name: "dichvu");

            migrationBuilder.DropTable(
                name: "hoadon");

            migrationBuilder.DropTable(
                name: "khanghang");

            migrationBuilder.DropTable(
                name: "lichdichvu");

            migrationBuilder.DropTable(
                name: "loaiphong");

            migrationBuilder.DropTable(
                name: "nhanvien");

            migrationBuilder.DropTable(
                name: "phieudatphong");

            migrationBuilder.DropTable(
                name: "phong");

            migrationBuilder.DropTable(
                name: "quyen");

            migrationBuilder.DropTable(
                name: "taikhoan");
        }
    }
}

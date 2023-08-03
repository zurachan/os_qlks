﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using quanlykhachsan.Domains;

#nullable disable

namespace quanlykhachsan.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("quanlykhachsan.Domains.Entities.Master.Chucvu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TenCV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tencv");

                    b.HasKey("Id");

                    b.ToTable("chucvu");
                });

            modelBuilder.Entity("quanlykhachsan.Domains.Entities.Master.Nhanvien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CCCD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cccd");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("diachi");

                    b.Property<bool>("GioiTinh")
                        .HasColumnType("bit")
                        .HasColumnName("gioitinh");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("hoten");

                    b.Property<int>("MaCV")
                        .HasColumnType("int")
                        .HasColumnName("macv");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngaysinh");

                    b.Property<DateTime>("NgayVaoLam")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngayvaolam");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("sdt");

                    b.HasKey("Id");

                    b.ToTable("nhanvien");
                });

            modelBuilder.Entity("quanlykhachsan.Domains.Entities.Master.Phanquyen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TenQuyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tenquyen");

                    b.HasKey("Id");

                    b.ToTable("quyen");
                });

            modelBuilder.Entity("quanlykhachsan.Domains.Entities.Master.Taikhoan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MaNV")
                        .HasColumnType("int")
                        .HasColumnName("manv");

                    b.Property<int>("MaQuyen")
                        .HasColumnType("int")
                        .HasColumnName("maquyen");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("matkhau");

                    b.Property<string>("TenDangNhap")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tendangnhap");

                    b.HasKey("Id");

                    b.ToTable("taikhoan");
                });

            modelBuilder.Entity("quanlykhachsan.Domains.Entities.Product.Datdichvu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MaDV")
                        .HasColumnType("int")
                        .HasColumnName("madv");

                    b.Property<int>("MaPDP")
                        .HasColumnType("int")
                        .HasColumnName("mapdp");

                    b.Property<int>("SoLuongDV")
                        .HasColumnType("int")
                        .HasColumnName("soluongdv");

                    b.HasKey("Id");

                    b.ToTable("datdichvu");
                });

            modelBuilder.Entity("quanlykhachsan.Domains.Entities.Product.Dichvu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GiaDV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("giadv");

                    b.Property<string>("TenDV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tendv");

                    b.HasKey("Id");

                    b.ToTable("dichvu");
                });

            modelBuilder.Entity("quanlykhachsan.Domains.Entities.Product.Hoadon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MaNV")
                        .HasColumnType("int")
                        .HasColumnName("manv");

                    b.Property<int>("MaPDP")
                        .HasColumnType("int")
                        .HasColumnName("mapdp");

                    b.Property<DateTime>("NgayThanhToan")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngaythanhtoan");

                    b.Property<int>("SoTienThanhToan")
                        .HasColumnType("int")
                        .HasColumnName("sotienthanhtoan");

                    b.HasKey("Id");

                    b.ToTable("hoadon");
                });

            modelBuilder.Entity("quanlykhachsan.Domains.Entities.Product.Khachhang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("diachi");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("hoten");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("sdt");

                    b.HasKey("Id");

                    b.ToTable("khanghang");
                });

            modelBuilder.Entity("quanlykhachsan.Domains.Entities.Product.Lichdichvu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DiaDiem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("diadiem");

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ghichu");

                    b.Property<string>("MaDV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("madv");

                    b.Property<DateTime>("NgayGio")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngaygio");

                    b.Property<string>("NhiemVu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nhiemvu");

                    b.HasKey("Id");

                    b.ToTable("lichdichvu");
                });

            modelBuilder.Entity("quanlykhachsan.Domains.Entities.Product.Loaiphong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MoTaPhong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("motaphong");

                    b.Property<string>("TenLP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tenlp");

                    b.HasKey("Id");

                    b.ToTable("loaiphong");
                });

            modelBuilder.Entity("quanlykhachsan.Domains.Entities.Product.Phieudatphong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MaKH")
                        .HasColumnType("int")
                        .HasColumnName("makh");

                    b.Property<int>("MaPhong")
                        .HasColumnType("int")
                        .HasColumnName("maphong");

                    b.Property<DateTime>("NgayNhanPhong")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngaynhanphong");

                    b.Property<DateTime>("NgayTraPhong")
                        .HasColumnType("datetime2")
                        .HasColumnName("ngaytraphong");

                    b.Property<int>("TongTien")
                        .HasColumnType("int")
                        .HasColumnName("tongtien");

                    b.HasKey("Id");

                    b.ToTable("phieudatphong");
                });

            modelBuilder.Entity("quanlykhachsan.Domains.Entities.Product.Phong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GiaPhong")
                        .HasColumnType("int")
                        .HasColumnName("giaphong");

                    b.Property<int>("MaLP")
                        .HasColumnType("int")
                        .HasColumnName("malp");

                    b.Property<int>("SucChua")
                        .HasColumnType("int")
                        .HasColumnName("succhua");

                    b.Property<int>("Tang")
                        .HasColumnType("int")
                        .HasColumnName("tang");

                    b.HasKey("Id");

                    b.ToTable("phong");
                });
#pragma warning restore 612, 618
        }
    }
}

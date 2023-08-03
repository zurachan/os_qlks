using Microsoft.EntityFrameworkCore;
using quanlykhachsan.Domains.Entities.Master;
using quanlykhachsan.Domains.Entities.Product;

namespace quanlykhachsan.Domains
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Chucvu> Chucvus { get; set; }
        public DbSet<Nhanvien> Nhanviens { get; set; }
        public DbSet<Quyen> Quyens { get; set; }
        public DbSet<Taikhoan> Taikhoans { get; set; }
        public DbSet<Datdichvu> Datdichvus { get; set; }
        public DbSet<Dichvu> Dichvus { get; set; }
        public DbSet<Hoadon> Hoadons { get; set; }
        public DbSet<Khachhang> Khachhangs { get; set; }
        public DbSet<Lichdichvu> Lichdichvus { get; set; }
        public DbSet<Loaiphong> Loaiphongs { get; set; }
        public DbSet<Phieudatphong> Phieudatphongs { get; set; }
        public DbSet<Phong> Phongs { get; set; }
    }
}

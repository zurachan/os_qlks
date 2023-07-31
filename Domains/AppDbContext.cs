using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using quanlykhachsan.Domains.Entities.Master;
using quanlykhachsan.Domains.Entities.Product;

namespace quanlykhachsan.Domains
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            try
            {
                if (Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator dbCreator)
                {
                    if (!dbCreator.CanConnect()) dbCreator.Create();
                    if (!dbCreator.HasTables()) dbCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DbSet<Chucvu> Chucvus { get; set; }
        public DbSet<Nhanvien> Nhanviens { get; set; }
        public DbSet<Phanquyen> Phanquyens { get; set; }
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

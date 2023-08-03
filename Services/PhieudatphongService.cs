using quanlykhachsan.Domains;
using quanlykhachsan.Domains.Entities.Product;

namespace quanlykhachsan.Services
{
    public interface IPhieudatphongService
    {
        List<Phieudatphong> GetAll();
        Phieudatphong GetById(int id);
        Phieudatphong Create(Phieudatphong model);
        Phieudatphong Update(Phieudatphong model);
        bool Delete(int id);
    }
    public class PhieudatphongService : IPhieudatphongService
    {
        private AppDbContext _context;
        public PhieudatphongService(AppDbContext context)
        {
            _context = context;
        }

        public Phieudatphong Create(Phieudatphong model)
        {
            var entity = new Phieudatphong
            {
                MaKH = model.MaKH,
                MaPhong = model.MaPhong,
                NgayNhanPhong = model.NgayNhanPhong,
                NgayTraPhong = model.NgayTraPhong,
                TongTien = model.TongTien,
            };

            _context.Phieudatphongs.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _context.Phieudatphongs.Find(id);
            if (entity == null) return false;
            _context.Phieudatphongs.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<Phieudatphong> GetAll()
        {
            return _context.Phieudatphongs.ToList();
        }

        public Phieudatphong GetById(int id)
        {
            return _context.Phieudatphongs.Find(id) ?? throw new Exception("Không tìm thấy phiếu đặt phòng");
        }

        public Phieudatphong Update(Phieudatphong model)
        {
            var entity = _context.Phieudatphongs.Find(model.Id) ?? throw new Exception("Không tìm thấy phiếu đặt phòng");
            entity.MaKH = model.MaKH;
            entity.MaPhong = model.MaPhong;
            entity.NgayNhanPhong = model.NgayNhanPhong;
            entity.NgayTraPhong = model.NgayTraPhong;
            entity.TongTien = model.TongTien;

            _context.Phieudatphongs.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}

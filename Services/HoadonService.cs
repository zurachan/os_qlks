using quanlykhachsan.Domains;
using quanlykhachsan.Domains.Entities.Product;

namespace quanlykhachsan.Services
{
    public interface IHoadonService
    {
        List<Hoadon> GetAll();
        Hoadon GetById(int id);
        Hoadon Create(Hoadon model);
        Hoadon Update(Hoadon model);
        bool Delete(int id);
    }

    public class HoadonService : IHoadonService
    {
        private AppDbContext _context;
        public HoadonService(AppDbContext context)
        {
            _context = context;
        }

        public Hoadon Create(Hoadon model)
        {
            var entity = new Hoadon
            {
                MaPDP = model.MaPDP,
                MaNV = model.MaNV,
                NgayThanhToan = model.NgayThanhToan,
                SoTienThanhToan = model.SoTienThanhToan,
            };

            _context.Hoadons.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _context.Hoadons.Find(id);
            if (entity == null) return false;
            _context.Hoadons.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<Hoadon> GetAll()
        {
            return _context.Hoadons.ToList();
        }

        public Hoadon GetById(int id)
        {
            return _context.Hoadons.Find(id) ?? throw new Exception("Không tìm thấy hóa đơn");
        }

        public Hoadon Update(Hoadon model)
        {
            var entity = _context.Hoadons.Find(model.Id) ?? throw new Exception("Không tìm thấy hóa đơn");
            entity.MaPDP = model.MaPDP;
            entity.MaNV = model.MaNV;
            entity.NgayThanhToan = model.NgayThanhToan;
            entity.SoTienThanhToan = model.SoTienThanhToan;

            _context.Hoadons.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}

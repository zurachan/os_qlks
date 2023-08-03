using quanlykhachsan.Domains;
using quanlykhachsan.Domains.Entities.Product;

namespace quanlykhachsan.Services
{
    public interface IKhachhangService
    {
        List<Khachhang> GetAll();
        Khachhang GetById(int id);
        Khachhang Create(Khachhang model);
        Khachhang Update(Khachhang model);
        bool Delete(int id);
    }
    public class KhachhangService : IKhachhangService
    {
        private AppDbContext _context;
        public KhachhangService(AppDbContext context)
        {
            _context = context;
        }

        public Khachhang Create(Khachhang model)
        {
            var entity = new Khachhang
            {
                HoTen = model.HoTen,
                SDT = model.SDT,
                DiaChi = model.DiaChi,
                Email = model.Email,
            };

            _context.Khachhangs.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _context.Khachhangs.Find(id);
            if (entity == null) return false;
            _context.Khachhangs.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<Khachhang> GetAll()
        {
            return _context.Khachhangs.ToList();
        }

        public Khachhang GetById(int id)
        {
            return _context.Khachhangs.Find(id) ?? throw new Exception("Không tìm thấy quyền");
        }

        public Khachhang Update(Khachhang model)
        {
            var entity = _context.Khachhangs.Find(model.Id) ?? throw new Exception("Không tìm thấy quyền");
            entity.HoTen = model.HoTen;
            entity.SDT = model.SDT;
            entity.Email = model.Email;
            entity.DiaChi = model.DiaChi;

            _context.Khachhangs.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}

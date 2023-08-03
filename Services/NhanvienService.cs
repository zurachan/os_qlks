using quanlykhachsan.Domains;
using quanlykhachsan.Domains.Entities.Master;

namespace quanlykhachsan.Services
{
    public interface INhanvienService
    {
        List<Nhanvien> GetAll();
        Nhanvien GetById(int id);
        Nhanvien Create(Nhanvien model);
        Nhanvien Update(Nhanvien model);
        bool Delete(int id);
    }
    public class NhanvienService : INhanvienService
    {
        private AppDbContext _context;
        public NhanvienService(AppDbContext context)
        {
            _context = context;
        }

        public Nhanvien Create(Nhanvien model)
        {
            _context.Nhanviens.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _context.Nhanviens.Find(id);
                if (entity == null) return false;

                var account = _context.Taikhoans.FirstOrDefault(x => x.MaNV == entity.Id);
                if (account == null) return false;

                _context.Taikhoans.Remove(account);
                _context.Nhanviens.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Nhanvien> GetAll()
        {
            return _context.Nhanviens.ToList();
        }

        public Nhanvien GetById(int id)
        {
            return _context.Nhanviens.Find(id) ?? throw new Exception("Không tìm thấy nhân viên");
        }

        public Nhanvien Update(Nhanvien model)
        {
            var entity = _context.Nhanviens.Find(model.Id) ?? throw new Exception("Không tìm thấy nhân viên");

            entity.HoTen = model.HoTen;
            entity.NgaySinh = model.NgaySinh;
            entity.DiaChi = model.DiaChi;
            entity.GioiTinh = model.GioiTinh;
            entity.MaCV = model.MaCV;
            entity.CCCD = model.CCCD;
            entity.NgayVaoLam = model.NgayVaoLam;
            entity.SDT = model.SDT;

            _context.Nhanviens.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}

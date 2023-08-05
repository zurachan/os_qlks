using quanlykhachsan.Domains;
using quanlykhachsan.Domains.Entities.Master;

namespace quanlykhachsan.Services
{
    public interface ITaikhoanService
    {
        List<Taikhoan> GetAll();
        Taikhoan GetById(int id);
        Taikhoan Create(Taikhoan model);
        Taikhoan Update(Taikhoan model);
        bool Delete(int id);
        Taikhoan? GetByUsername(string username);
    }

    public class TaikhoanService : ITaikhoanService
    {
        private AppDbContext _context;
        public TaikhoanService(AppDbContext context)
        {
            _context = context;
        }
        public Taikhoan Create(Taikhoan model)
        {
            var entity = new Taikhoan
            {
                TenDangNhap = model.TenDangNhap,
                MatKhau = model.MatKhau,
                MaNV = model.MaNV,
                MaQuyen = model.MaQuyen,
            };

            _context.Taikhoans.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _context.Taikhoans.Find(id);
            if (entity == null) return false;
            _context.Taikhoans.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<Taikhoan> GetAll()
        {
            return _context.Taikhoans.ToList();
        }

        public Taikhoan GetById(int id)
        {
            return _context.Taikhoans.Find(id) ?? throw new Exception("Không tìm thấy tài khoản");
        }

        public Taikhoan? GetByUsername(string username)
        {
            return _context.Taikhoans.FirstOrDefault(x => x.TenDangNhap == username);
        }

        public Taikhoan Update(Taikhoan model)
        {
            var entity = _context.Taikhoans.Find(model.Id) ?? throw new Exception("Không tìm thấy tài khoản");
            entity.TenDangNhap = model.TenDangNhap;
            entity.MatKhau = model.MatKhau;
            entity.MaQuyen = model.MaQuyen;
            entity.MaNV = model.MaNV;

            _context.Taikhoans.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}

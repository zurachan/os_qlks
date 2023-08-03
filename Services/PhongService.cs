using quanlykhachsan.Domains;
using quanlykhachsan.Domains.Entities.Product;

namespace quanlykhachsan.Services
{
    public interface IPhongService
    {
        List<Loaiphong> GetAllLoaiphong();
        Loaiphong GetByIdLoaiphong(int id);
        Loaiphong CreateLoaiphong(Loaiphong model);
        Loaiphong UpdateLoaiphong(Loaiphong model);
        bool DeleteLoaiphong(int id);

        List<Phong> GetAllPhong();
        Phong GetByIdPhong(int id);
        Phong CreatePhong(Phong model);
        Phong UpdatePhong(Phong model);
        bool DeletePhong(int id);

    }
    public class PhongService : IPhongService
    {
        private AppDbContext _context;
        public PhongService(AppDbContext context)
        {
            _context = context;
        }

        public Loaiphong CreateLoaiphong(Loaiphong model)
        {
            var entity = new Loaiphong
            {
                TenLP = model.TenLP,
                MoTaPhong = model.MoTaPhong,
            };

            _context.Loaiphongs.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Phong CreatePhong(Phong model)
        {
            var entity = new Phong
            {
                MaLP = model.MaLP,
                SucChua = model.SucChua,
                Tang = model.Tang,
                GiaPhong = model.GiaPhong,
            };

            _context.Phongs.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool DeleteLoaiphong(int id)
        {
            var entity = _context.Loaiphongs.Find(id);
            if (entity == null) return false;
            _context.Loaiphongs.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public bool DeletePhong(int id)
        {
            var entity = _context.Phongs.Find(id);
            if (entity == null) return false;
            _context.Phongs.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<Loaiphong> GetAllLoaiphong()
        {
            return _context.Loaiphongs.ToList();
        }

        public List<Phong> GetAllPhong()
        {
            return _context.Phongs.ToList();
        }

        public Loaiphong GetByIdLoaiphong(int id)
        {
            return _context.Loaiphongs.Find(id) ?? throw new Exception("Không tìm thấy loại phòng");
        }

        public Phong GetByIdPhong(int id)
        {
            return _context.Phongs.Find(id) ?? throw new Exception("Không tìm thấy phòng");
        }

        public Loaiphong UpdateLoaiphong(Loaiphong model)
        {
            var entity = _context.Loaiphongs.Find(model.Id) ?? throw new Exception("Không tìm thấy loại phòng");
            entity.TenLP = model.TenLP;
            entity.MoTaPhong = model.MoTaPhong;

            _context.Loaiphongs.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public Phong UpdatePhong(Phong model)
        {
            var entity = _context.Phongs.Find(model.Id) ?? throw new Exception("Không tìm thấy phòng");
            entity.MaLP = model.MaLP;
            entity.SucChua = model.SucChua;
            entity.Tang = model.Tang;
            entity.GiaPhong = model.GiaPhong;

            _context.Phongs.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}

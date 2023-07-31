using quanlykhachsan.Domains;
using quanlykhachsan.Domains.Entities.Master;

namespace quanlykhachsan.Services
{
    public interface IChucvuService
    {
        List<Chucvu> GetAll();
        Chucvu GetById(int id);
        Chucvu Create(Chucvu model);
        Chucvu Update(Chucvu model);
        bool Delete(int id);
    }
    public class ChucvuService : IChucvuService
    {
        private AppDbContext _context;
        public ChucvuService(AppDbContext context)
        {
            _context = context;
        }

        public Chucvu Create(Chucvu model)
        {
            var entity = new Chucvu
            {
                TenCV = model.TenCV,
            };

            _context.Chucvus.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _context.Chucvus.Find(id);
            if (entity == null) return false;
            _context.Chucvus.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<Chucvu> GetAll()
        {
            return _context.Chucvus.ToList();
        }

        public Chucvu GetById(int id)
        {
            return _context.Chucvus.Find(id) ?? throw new Exception("Không tìm thấy chức vụ");
        }

        public Chucvu Update(Chucvu model)
        {
            var entity = _context.Chucvus.Find(model.Id) ?? throw new Exception("Không tìm thấy chức vụ");
            entity.TenCV = model.TenCV;

            _context.Chucvus.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}

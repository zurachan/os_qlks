using quanlykhachsan.Domains;
using quanlykhachsan.Domains.Entities.Master;

namespace quanlykhachsan.Services
{
    public interface IQuyenService
    {
        List<Quyen> GetAll();
        Quyen GetById(int id);
        Quyen Create(Quyen model);
        Quyen Update(Quyen model);
        bool Delete(int id);
    }
    public class QuyenService : IQuyenService
    {
        private AppDbContext _context;
        public QuyenService(AppDbContext context)
        {
            _context = context;
        }

        public Quyen Create(Quyen model)
        {
            var entity = new Quyen
            {
                TenQuyen = model.TenQuyen,
            };

            _context.Quyens.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _context.Quyens.Find(id);
            if (entity == null) return false;
            _context.Quyens.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<Quyen> GetAll()
        {
            return _context.Quyens.ToList();
        }

        public Quyen GetById(int id)
        {
            return _context.Quyens.Find(id) ?? throw new Exception("Không tìm thấy quyền");
        }

        public Quyen Update(Quyen model)
        {
            var entity = _context.Quyens.Find(model.Id) ?? throw new Exception("Không tìm thấy quyền");
            entity.TenQuyen = model.TenQuyen;

            _context.Quyens.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}

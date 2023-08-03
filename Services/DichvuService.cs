using quanlykhachsan.Domains;
using quanlykhachsan.Domains.Entities.Product;

namespace quanlykhachsan.Services
{
    public interface IDichvuService
    {
        List<Dichvu> GetAllDichvu();
        Dichvu GetByIdDichvu(int id);
        Dichvu CreateDichvu(Dichvu model);
        Dichvu UpdateDichvu(Dichvu model);
        bool DeleteDichvu(int id);

        List<Lichdichvu> GetAllLichdichvu();
        Lichdichvu GetByIdLichdichvu(int id);
        Lichdichvu CreateLichdichvu(Lichdichvu model);
        Lichdichvu UpdateLichdichvu(Lichdichvu model);
        bool DeleteLichdichvu(int id);

        List<Datdichvu> GetAllDatdichvu();
        Datdichvu GetByIdDatdichvu(int id);
        Datdichvu CreateDatdichvu(Datdichvu model);
        Datdichvu UpdateDatdichvu(Datdichvu model);
        bool DeleteDatdichvu(int id);
    }

    public class DichvuService : IDichvuService
    {
        private AppDbContext _context;
        public DichvuService(AppDbContext context)
        {
            _context = context;
        }

        public Datdichvu CreateDatdichvu(Datdichvu model)
        {
            var entity = new Datdichvu
            {
                MaDV = model.MaDV,
                MaPDP = model.MaPDP,
                SoLuongDV = model.SoLuongDV,
            };

            _context.Datdichvus.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Dichvu CreateDichvu(Dichvu model)
        {
            var entity = new Dichvu
            {
                TenDV = model.TenDV,
                GiaDV = model.GiaDV,
            };

            _context.Dichvus.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Lichdichvu CreateLichdichvu(Lichdichvu model)
        {
            var entity = new Lichdichvu
            {
                NgayGio = model.NgayGio,
                NhiemVu = model.NhiemVu,
                GhiChu = model.GhiChu,
                DiaDiem = model.DiaDiem,
                MaDV = model.MaDV,
            };

            _context.Lichdichvus.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool DeleteDatdichvu(int id)
        {
            var entity = _context.Datdichvus.Find(id);
            if (entity == null) return false;
            _context.Datdichvus.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteDichvu(int id)
        {
            var entity = _context.Dichvus.Find(id);
            if (entity == null) return false;
            _context.Dichvus.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteLichdichvu(int id)
        {
            var entity = _context.Lichdichvus.Find(id);
            if (entity == null) return false;
            _context.Lichdichvus.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<Datdichvu> GetAllDatdichvu()
        {
            return _context.Datdichvus.ToList();
        }

        public List<Dichvu> GetAllDichvu()
        {
            return _context.Dichvus.ToList();
        }

        public List<Lichdichvu> GetAllLichdichvu()
        {
            return _context.Lichdichvus.ToList();
        }

        public Datdichvu GetByIdDatdichvu(int id)
        {
            return _context.Datdichvus.Find(id) ?? throw new Exception("Không tìm thấy đặt dịch vụ");
        }

        public Dichvu GetByIdDichvu(int id)
        {
            return _context.Dichvus.Find(id) ?? throw new Exception("Không tìm thấy dịch vụ");
        }

        public Lichdichvu GetByIdLichdichvu(int id)
        {
            return _context.Lichdichvus.Find(id) ?? throw new Exception("Không tìm thấy lịch dịch vụ");
        }

        public Datdichvu UpdateDatdichvu(Datdichvu model)
        {
            var entity = _context.Datdichvus.Find(model.Id) ?? throw new Exception("Không tìm thấy đặt dịch vụ");
            entity.MaDV = model.MaDV;
            entity.MaPDP = model.MaPDP;
            entity.SoLuongDV = model.SoLuongDV;

            _context.Datdichvus.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public Dichvu UpdateDichvu(Dichvu model)
        {
            var entity = _context.Dichvus.Find(model.Id) ?? throw new Exception("Không tìm thấy dịch vụ");
            entity.TenDV = model.TenDV;
            entity.GiaDV = model.GiaDV;

            _context.Dichvus.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public Lichdichvu UpdateLichdichvu(Lichdichvu model)
        {
            var entity = _context.Lichdichvus.Find(model.Id) ?? throw new Exception("Không tìm thấy lịch dịch vụ");
            entity.NgayGio = model.NgayGio;
            entity.NhiemVu = model.NhiemVu;
            entity.DiaDiem = model.DiaDiem;
            entity.GhiChu = model.GhiChu;
            entity.MaDV = model.MaDV;
            _context.Lichdichvus.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}

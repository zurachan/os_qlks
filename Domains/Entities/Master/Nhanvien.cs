using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quanlykhachsan.Domains.Entities.Master
{
    [Table("nhanvien")]
    public class Nhanvien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("hoten")]
        public string HoTen { get; set; }
        [Column("ngaysinh")]
        public DateTime NgaySinh { get; set; }
        [Column("diachi")]
        public string DiaChi { get; set; }
        [Column("gioitinh")]
        public bool GioiTinh { get; set; }
        [Column("macv")]
        public int MaCV { get; set; }
        [Column("cccd")]
        public int CCCD { get; set; }
        [Column("ngayvaolam")]
        public DateTime NgayVaoLam { get; set; }
        [Column("sdt")]
        public string SDT { get; set; }
    }
}

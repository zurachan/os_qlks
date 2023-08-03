using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quanlykhachsan.Domains.Entities.Master
{
    [Table("taikhoan")]
    public class Taikhoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("tendangnhap")]
        public string TenDangNhap { get; set; }
        [Column("matkhau")]
        public string MatKhau { get; set; } = "123456";
        [Column("manv")]
        public int MaNV { get; set; }
        [Column("maquyen")]
        public int MaQuyen { get; set; }
    }
}

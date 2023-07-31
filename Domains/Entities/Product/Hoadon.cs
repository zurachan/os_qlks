using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quanlykhachsan.Domains.Entities.Product
{
    [Table("hoadon")]
    public class Hoadon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("mapdp")]
        public int MaPDP { get; set; }
        [Column("manv")]
        public int MaNV { get; set; }
        [Column("ngaythanhtoan")]
        public DateTime NgayThanhToan { get; set; }
        [Column("sotienthanhtoan")]
        public int SoTienThanhToan { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quanlykhachsan.Domains.Entities.Master
{
    [Table("phanquyen")]
    public class Phanquyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("vaitro")]
        public string VaiTro { get; set; }
        [Column("quyenhan")]
        public string QuyenHan { get; set; }
        [Column("ngayhieuluc")]
        public DateTime NgayHieuLuc { get; set; }
        [Column("nguoipheduyet")]
        public string NguoiPheDuyet { get; set; }
        [Column("matk")]
        public int MaTK { get; set; }
    }
}

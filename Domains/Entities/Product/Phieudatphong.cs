using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quanlykhachsan.Domains.Entities.Product
{
    [Table("phieudatphong")]
    public class Phieudatphong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("makh")]
        public int MaKH { get; set; }
        [Column("maphong")]
        public int MaPhong { get; set; }
        [Column("ngaynhanphong")]
        public DateTime NgayNhanPhong { get; set; }
        [Column("ngaytraphong")]
        public DateTime NgayTraPhong { get; set; }
        [Column("tongtien")]
        public int TongTien { get; set; }
    }
}

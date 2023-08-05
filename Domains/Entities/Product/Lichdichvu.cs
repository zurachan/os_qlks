using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quanlykhachsan.Domains.Entities.Product
{
    [Table("lichdichvu")]
    public class Lichdichvu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("ngaygio")]
        public DateTime NgayGio { get; set; }
        [Column("nhiemvu")]
        public string NhiemVu { get; set; }
        [Column("diadiem")]
        public string DiaDiem { get; set; }
        [Column("ghichu")]
        public string GhiChu { get; set; }
        [Column("madv")]
        public int MaDV { get; set; }
    }
}

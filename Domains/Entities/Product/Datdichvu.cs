using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quanlykhachsan.Domains.Entities.Product
{
    [Table("datdichvu")]
    public class Datdichvu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("mapdp")]
        public int MaPDP { get; set; }
        [Column("madv")]
        public int MaDV { get; set; }
        [Column("soluongdv")]
        public int SoLuongDV { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quanlykhachsan.Domains.Entities.Product
{
    [Table("loaiphong")]
    public class Loaiphong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("tenlp")]
        public string TenLP { get; set; }
        [Column("motaphong")]
        public string MoTaPhong { get; set; }
    }
}

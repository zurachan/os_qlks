using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quanlykhachsan.Domains.Entities.Product
{
    [Table("dichvu")]
    public class Dichvu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("tendv")]
        public string TenDV { get; set; }
        [Column("giadv")]
        public string GiaDV { get; set; }
    }
}

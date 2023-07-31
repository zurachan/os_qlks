using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace quanlykhachsan.Domains.Entities.Master
{
    [Table("chucvu")]
    public class Chucvu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("tencv")]
        [Required]
        public string TenCV { get; set; }
    }
}

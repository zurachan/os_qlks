using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace quanlykhachsan.Domains.Entities.Product
{
    [Table("phong")]
    public class Phong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("malp")]
        public int MaLP { get; set; }
        [Column("succhua")]
        public int SucChua { get; set; }
        [Column("tang")]
        public int Tang { get; set; }
        [Column("giaphong")]
        public int GiaPhong { get; set; }
    }
}

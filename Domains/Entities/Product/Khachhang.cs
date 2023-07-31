using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quanlykhachsan.Domains.Entities.Product
{
    [Table("khanghang")]
    public class Khachhang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("hoten")]
        public string HoTen { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("sdt")]
        public string SDT { get; set; }
        [Column("diachi")]
        public string DiaChi { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Model.Models
{
    [Table("ProductTags")]
    public class ProductTag
    {
        [Key]
        public int Cou_ID { get; set; }

        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Tag_ID { get; set; }

        [ForeignKey("Cou_ID")]
        public virtual Course Course { get; set; }

        [ForeignKey("Tag_ID")]
        public virtual Tag Tag { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Model.Models
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        [MaxLength(50)]
        public string Tag_ID { get; set; }

        [MaxLength(50)]
        [Required]
        public string Tag_Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Tag_Type { get; set; }
    }
}

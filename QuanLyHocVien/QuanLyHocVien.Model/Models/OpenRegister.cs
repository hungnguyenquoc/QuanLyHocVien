using QuanLyHocVien.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Model.Models
{
    [Table("OpenRegisters")]
    public class OpenRegister : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Re_ID { get; set; }

        [MaxLength(256)]
        public string Re_Name { get; set; }

        public DateTime Time_Start { get; set; }

        public DateTime Time_End { get; set; }

        public virtual IEnumerable<Course> Courses { get; set; }

    }
}

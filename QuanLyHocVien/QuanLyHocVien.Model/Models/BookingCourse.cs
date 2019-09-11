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
    [Table("BookingCourses")]
    public class BookingCourse: Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Book_ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Book_Name { get; set; }

        [MaxLength(100)]
        public string Book_Email { get; set; }

        [MaxLength(100)]
        public string Book_Phone { get; set; }

        [MaxLength(100)]
        public string Book_CodeDiscount { get; set; }

        [MaxLength(256)]
        public string PaymentMethod { get; set; }

        [MaxLength(256)]
        public string PaymentStatus { get; set; }

        public virtual IEnumerable<BookingDetail> BookingDetails { get; set; }
    }
}

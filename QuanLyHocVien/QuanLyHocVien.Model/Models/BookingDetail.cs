using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Model.Models
{
    [Table("BookingDetails")]
    public class BookingDetail
    {
        [Key ,Column(Order = 0)]
        public int Book_ID { get; set; }

        [Key, Column(Order = 1)]
        public int Cou_ID { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Book_ID")]
        public virtual BookingCourse BookingCourse { get; set; }

        [ForeignKey("Cou_ID")]
        public virtual Course Course { get; set; }

    }
}

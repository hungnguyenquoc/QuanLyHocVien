using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHocVien.Web.Models
{
    public class BookingCourseViewModel
    {
       
        public int Book_ID { get; set; }

       
        public string Book_Name { get; set; }

        public string Book_Email { get; set; }

        public string Book_Phone { get; set; }

        public string Book_CodeDiscount { get; set; }

        public string PaymentMethod { get; set; }

        public string PaymentStatus { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public bool Status { get; set; }

        public virtual IEnumerable<BookingDetailViewModel> BookingDetails { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHocVien.Web.Models
{
    public class BookingDetailViewModel
    {
        public int Book_ID { get; set; }

        public int Cou_ID { get; set; }

        public int Quantity { get; set; }

        public virtual BookingCourseViewModel BookingCourse { get; set; }

        public virtual CourseViewModel Course { get; set; }
    }
}
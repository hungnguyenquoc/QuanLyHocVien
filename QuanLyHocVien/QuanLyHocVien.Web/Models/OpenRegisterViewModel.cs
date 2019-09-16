using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHocVien.Web.Models
{
    public class OpenRegisterViewModel
    {
        
        public int Re_ID { get; set; }

        public string Re_Name { get; set; }

        public DateTime Time_Start { get; set; }

        public DateTime Time_End { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public bool Status { get; set; }

        public virtual IEnumerable<CourseViewModel> Courses { get; set; }
    }
}
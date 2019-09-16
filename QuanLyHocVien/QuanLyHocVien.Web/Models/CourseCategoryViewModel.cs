using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHocVien.Web.Models
{
    public class CourseCategoryViewModel
    {
        
        public int Cate_ID { get; set; }

      
        public string Cate_Name { get; set; }

      
        public string Cate_Alias { get; set; }

    
        public string Cate_Description { get; set; }

      
        public string Cate_Image { get; set; }

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
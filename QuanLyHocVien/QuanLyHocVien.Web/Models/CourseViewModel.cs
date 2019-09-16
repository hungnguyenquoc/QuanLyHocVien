using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHocVien.Web.Models
{
    public class CourseViewModel
    {
        
        public int Cou_ID { get; set; }

        public string Cou_Name { get; set; }

        public string Cou_Alias { get; set; }

        public string Cou_Description { get; set; }

        public string Cou_Content { get; set; }

        public string Cou_Image { get; set; }

        public string Cou_MoreImages { get; set; }

        public decimal Cou_Price { get; set; }

        public decimal Cou_PromotionPrice { get; set; }

        public int? Cou_ViewCount { get; set; }

        public int CategoryID { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public bool Status { get; set; }

        public virtual CourseCategoryViewModel CourseCategory { get; set; }

        public int Re_ID { get; set; }

        public virtual OpenRegisterViewModel OpenRegister { get; set; }

        public virtual IEnumerable<BookingDetailViewModel> BookingDetails { get; set; }
    }
}
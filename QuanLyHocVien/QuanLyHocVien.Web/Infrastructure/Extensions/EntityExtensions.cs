using QuanLyHocVien.Model.Models;
using QuanLyHocVien.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHocVien.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateCourseCategory(this CourseCategory courseCategory, CourseCategoryViewModel courseCategoryViewModel)
        {
            
            courseCategory.Cate_Alias = courseCategoryViewModel.Cate_Alias;
            courseCategory.Cate_Description = courseCategoryViewModel.Cate_Description;
            courseCategory.Cate_ID = courseCategoryViewModel.Cate_ID;
            courseCategory.Cate_Image = courseCategoryViewModel.Cate_Image;
            courseCategory.Cate_Name = courseCategoryViewModel.Cate_Name;
            courseCategory.CreatedBy = courseCategoryViewModel.CreatedBy;
            courseCategory.CreatedDate = courseCategoryViewModel.CreatedDate;
            courseCategory.MetaDescription = courseCategory.MetaDescription;
            courseCategory.Status = courseCategoryViewModel.Status;
            courseCategory.UpdatedBy = courseCategoryViewModel.UpdatedBy;
            courseCategory.UpdatedDate = courseCategoryViewModel.UpdatedDate;
            courseCategory.MetaKeyword = courseCategoryViewModel.MetaKeyword;

        }
        public static void UpdateCourse(this Course course, CourseViewModel courseVm)
        {
            course.Cou_Alias = courseVm.Cou_Alias;
            course.Cou_Content = courseVm.Cou_Content;
            course.Cou_Description = courseVm.Cou_Description;
            course.Cou_ID = courseVm.Cou_ID;
            course.Cou_Image = courseVm.Cou_Image;
            course.Cou_MoreImages = courseVm.Cou_MoreImages;
            course.Cou_Name = courseVm.Cou_Name;
            course.Cou_Price = courseVm.Cou_Price;
            course.Cou_PromotionPrice = courseVm.Cou_PromotionPrice;
            course.Cou_ViewCount = courseVm.Cou_ViewCount;
            course.CreatedBy = courseVm.CreatedBy;
            course.CreatedDate = courseVm.CreatedDate;
            course.MetaDescription = course.MetaDescription;
            course.Status = courseVm.Status;
            course.UpdatedBy = courseVm.UpdatedBy;
            course.UpdatedDate = courseVm.UpdatedDate;
            course.MetaKeyword = courseVm.MetaKeyword;
        }
    }
}
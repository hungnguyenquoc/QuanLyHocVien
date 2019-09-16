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
    }
}
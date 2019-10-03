namespace QuanLyHocVien.Data.Migrations
{
    using QuanLyHocVien.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QuanLyHocVien.Data.QuanLyHocVienDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(QuanLyHocVien.Data.QuanLyHocVienDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            CreateCourseCategorySample(context);
        }
        private void CreateCourseCategorySample(QuanLyHocVien.Data.QuanLyHocVienDbContext context)
        {
            if(context.CourseCategories.Count() == 0)
            {
                List<CourseCategory> listCourseCategory = new List<CourseCategory>()
                {
                    new CourseCategory()
                    {
                        Cate_Name ="lập trình", Cate_Alias = "lap-trinh", Status =true
                    },
                    new CourseCategory()
                    {
                        Cate_Name="tin học", Cate_Alias="tin-hoc", Status = true
                    },
                    new CourseCategory()
                    {
                        Cate_Name="anh van", Cate_Alias="anh-van", Status = true
                    }
                };
                context.CourseCategories.AddRange(listCourseCategory);
                context.SaveChanges();
            }          
        }
    }
}

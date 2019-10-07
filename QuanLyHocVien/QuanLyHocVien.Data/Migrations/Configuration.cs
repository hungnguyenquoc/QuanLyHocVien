namespace QuanLyHocVien.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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
            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new QuanLyHocVienDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new QuanLyHocVienDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "tedu",
                Email = "tedu.international@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Technology Education"

            };

            manager.Create(user, "123654$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("tedu.international@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });

            //if(context.CourseCategories.Count() == 0)
            //{
            //    List<CourseCategory> listCourseCategory = new List<CourseCategory>()
            //    {
            //        new CourseCategory()
            //        {
            //            Cate_Name ="lập trình", Cate_Alias = "lap-trinh", Status =true
            //        },
            //        new CourseCategory()
            //        {
            //            Cate_Name="tin học", Cate_Alias="tin-hoc", Status = true
            //        },
            //        new CourseCategory()
            //        {
            //            Cate_Name="anh van", Cate_Alias="anh-van", Status = true
            //        }
            //    };
            //    context.CourseCategories.AddRange(listCourseCategory);
            //    context.SaveChanges();
            //}          
        }
    }
}

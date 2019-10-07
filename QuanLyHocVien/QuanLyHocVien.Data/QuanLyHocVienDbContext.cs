using Microsoft.AspNet.Identity.EntityFramework;
using QuanLyHocVien.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Data
{
    public class QuanLyHocVienDbContext : IdentityDbContext<ApplicationUser>
    {
        public QuanLyHocVienDbContext(): base("AcademyConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<BookingCourse> BookingCourses { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<OpenRegister> OpenRegisters { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }

        public static QuanLyHocVienDbContext Create()
        {
            return new QuanLyHocVienDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            //base.OnModelCreating(builder);
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }
    }
}

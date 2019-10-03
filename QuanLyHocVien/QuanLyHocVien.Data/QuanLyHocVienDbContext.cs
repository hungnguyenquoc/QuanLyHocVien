using QuanLyHocVien.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Data
{
    public class QuanLyHocVienDbContext : DbContext
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
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

using QuanLyHocVien.Data.Infrastructure;
using QuanLyHocVien.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Data.Repositories
{
    public interface ICourseRepository { }
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

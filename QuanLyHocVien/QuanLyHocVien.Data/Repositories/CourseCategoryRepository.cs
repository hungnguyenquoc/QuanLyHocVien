using QuanLyHocVien.Data.Infrastructure;
using QuanLyHocVien.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Data.Repositories
{
    public interface ICourseCategoryRepository : IRepository<CourseCategory>
    {
    }

    public class CourseCategoryRepository : RepositoryBase<CourseCategory>, ICourseCategoryRepository
    {
        public CourseCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
    //public interface ICourseCategoryRepository: IRepository<CourseCategory>
    //{
    //    IEnumerable<CourseCategory> GetByAlias(string alias);
    //}

    //public class CourseCategoryRepository : RepositoryBase<CourseCategory>, ICourseCategoryRepository
    //{
    //    public CourseCategoryRepository(IDbFactory dbFactory)
    //        : base(dbFactory)
    //    {
    //    }

    //    public IEnumerable<CourseCategory> GetByAlias(string alias)
    //    {
    //        return this.DbContext.CourseCategories.Where(x => x.Cate_Alias == alias);
    //    }
    //}
}

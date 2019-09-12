using QuanLyHocVien.Data.Infrastructure;
using QuanLyHocVien.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace QuanLyHocVien.Data.Repositories
{
    public interface ICourseRepository: IRepository<Course>
    {
        IEnumerable<Course> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow);

    }

    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<Course> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from c in DbContext.Courses
                        join pt in DbContext.ProductTags
                        on c.Cou_ID equals pt.Cou_ID
                        where pt.Tag_ID == tag && c.Status
                        orderby c.CreatedDate descending
                        select c;

            totalRow = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return query;
        }
    }
}

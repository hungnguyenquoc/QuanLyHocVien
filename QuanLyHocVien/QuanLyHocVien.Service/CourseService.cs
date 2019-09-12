using QuanLyHocVien.Data.Infrastructure;
using QuanLyHocVien.Data.Repositories;
using QuanLyHocVien.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Service
{
    public interface ICourseService
    {
        void Add(Course course);
        void Update(Course course);
        void Delete(int id);
        IEnumerable<Course> GetAll();
        IEnumerable<Course> GetAllPaging(int page, int pageSize, out int totalRow);
        IEnumerable<Course> GetAllByCategoryPaging(int Cate_ID, int page, int pageSize, out int totalRow);
        Course GetByID(int id);
        IEnumerable<Course> GetAllByTagPaging(string tag,int page, int pageSize, out int totalRow);
        void SaveChanges();
    }
    public class CourseService : ICourseService
    {
        ICourseRepository _courseRepository;
        IUnitOfWork _unitOfWork;

        public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            this._courseRepository = courseRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(Course course)
        {
            _courseRepository.Add(course);
        }

        public void Delete(int id)
        {
            _courseRepository.Delete(id);
        }

        public IEnumerable<Course> GetAll()
        {
            return _courseRepository.GetAll(new string[] { "CourseCategory" });
        }

        public IEnumerable<Course> GetAllByCategoryPaging(int Cate_ID, int page, int pageSize, out int totalRow)
        {
            return _courseRepository.GetMultiPaging(x => x.Status && x.CategoryID == Cate_ID, out totalRow, page, pageSize, new string[] { "CourseCateogry" });
        }

        public IEnumerable<Course> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            return _courseRepository.GetAllByTag(tag, page, pageSize, out totalRow);
        }

        public IEnumerable<Course> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _courseRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Course GetByID(int id)
        {
            return _courseRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Course course)
        {
            _courseRepository.Update(course);
        }
    }
}

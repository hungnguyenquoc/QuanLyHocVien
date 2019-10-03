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
    public interface ICourseCategoryService
    {
        void Add(CourseCategory courseCategory);

        void Update(CourseCategory courseCategory);

        void Delete(int id);

        IEnumerable<CourseCategory> GetAll();

        IEnumerable<CourseCategory> GetAll(string keyword);

        //IEnumerable<CourseCategory> GetByID(int id);
        CourseCategory GetById(int Cate_ID);

        void Save();
    }
    public class CourseCategoryService : ICourseCategoryService
    {
        private ICourseCategoryRepository _courseCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public CourseCategoryService(ICourseCategoryRepository courseCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._courseCategoryRepository = courseCategoryRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(CourseCategory courseCategory)
        {
            _courseCategoryRepository.Add(courseCategory);
        }

        public void Delete(int id)
        {
            _courseCategoryRepository.Delete(id);
        }

        public IEnumerable<CourseCategory> GetAll()
        {
            return _courseCategoryRepository.GetAll();
        }

        public IEnumerable<CourseCategory> GetAll(string keyword)
        {
            if(!string.IsNullOrEmpty(keyword))
            {
                return _courseCategoryRepository.GetMulti(x => x.Cate_Name.Contains(keyword) || x.Cate_Description.Contains(keyword));
            }
            else
            {

            }
            return _courseCategoryRepository.GetAll();
        }

        public CourseCategory GetById(int Cate_ID)
        {
            return _courseCategoryRepository.GetSingleById(Cate_ID);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CourseCategory courseCategory)
        {
            _courseCategoryRepository.Update(courseCategory);
        }

        
    }
}

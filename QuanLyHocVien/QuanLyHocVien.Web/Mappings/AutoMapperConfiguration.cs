using AutoMapper;
using QuanLyHocVien.Model.Models;
using QuanLyHocVien.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHocVien.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure() =>
            //CreateMap<Course, CourseViewModel>()
            
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Course, CourseViewModel>();
                cfg.CreateMap<CourseCategory, CourseCategoryViewModel>();
            });//var config = new MapperConfiguration(cfg => {//cfg.CreateMap<Course, CourseViewModel>();//    cfg.CreateMap<CourseCategory, CourseCategoryViewModel>();//});//IMapper mapper = config.CreateMapper();//var course = new Course();//var dest = mapper.Map<Course, CourseViewModel>(course);////var courseCategory = new CourseCategory();//var dest = mapper.Map<CourseCategory, CourseCategoryViewModel>(courseCategory);//Mapper.CreateMp//Mapper.CreateMap<Course, CourseViewModel>();//Mapper.CreateMap<CourseCategory, CourseCategoryViewModel>();//Mapper.CreateMap<OpenRegister, OpenRegisterViewModel>();//Mapper.CreateMap<BookingCourse, BookingCourseViewModel>();//Mapper.CreateMap<BookingDetail, BookingDetailViewModel>();
    }
}
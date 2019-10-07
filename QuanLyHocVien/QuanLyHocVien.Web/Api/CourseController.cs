using AutoMapper;
using QuanLyHocVien.Model.Models;
using QuanLyHocVien.Service;
using QuanLyHocVien.Web.Infrastructure.Core;
using QuanLyHocVien.Web.Infrastructure.Extensions;
using QuanLyHocVien.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuanLyHocVien.Web.Api
{
    [RoutePrefix("api/course")]
    public class CourseController : ApiControllerBase
    {
        //#region Initialize
        //private ICourseService _courseService;

        //public CourseController(IErrorService errorService, ICourseService courseService)
        //    : base(errorService)
        //{
        //    this._courseService = courseService;
        //}

        //#endregion

        private ICourseService _courseService;

        public CourseController(IErrorService errorService, ICourseService courseService)
            : base(errorService)
        {
            this._courseService = courseService;
        }


        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _courseService.GetByID(id);

                var responseData = Mapper.Map<Course, CourseViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _courseService.GetAll();

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(query);

                var paginationSet = new PaginationSet<CourseViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }


        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, CourseViewModel courseCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newCourse = new Course();
                    newCourse.UpdateCourse(courseCategoryVm);
                    newCourse.CreatedDate = DateTime.Now;
                    _courseService.Add(newCourse);
                    _courseService.SaveChanges();

                    var responseData = Mapper.Map<Course, CourseViewModel>(newCourse);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, CourseViewModel courseVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbCourse = _courseService.GetByID(courseVm.Cou_ID);

                    dbCourse.UpdateCourse(courseVm);
                    dbCourse.UpdatedDate = DateTime.Now;

                    _courseService.Update(dbCourse);
                    _courseService.SaveChanges();

                    var responseData = Mapper.Map<Course, CourseViewModel>(dbCourse);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

    }
    }

using AutoMapper;
using QuanLyHocVien.Model.Models;
using QuanLyHocVien.Service;
using QuanLyHocVien.Web.Infrastructure.Core;
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
        ICourseService _courseService;
        public CourseController(IErrorService errorService, ICourseService courseService):base(errorService)
        {
            this._courseService = courseService;
        }
        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _courseService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
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
    }
}

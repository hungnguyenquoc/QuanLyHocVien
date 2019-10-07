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
using System.Web;
using System.Web.Mvc;

namespace QuanLyHocVien.Web.Api
{
    [RoutePrefix("api/coursecategory")]
    public class CourseCategoryController : ApiControllerBase
    {

        ICourseCategoryService _courseCategoryService;
        public CourseCategoryController(IErrorService errorService, ICourseCategoryService courseCategoryService) :
           base(errorService)
        {
            this._courseCategoryService = courseCategoryService;
        }
        //#region Initialize
        //private ICourseCategoryService _courseCategoryService;

        //#endregion

        //ICourseCategoryService _courseCategoryService;
        [HttpGet]
        [Route("getbyid/{Cate_ID:int}")]
        public HttpResponseMessage GetById(HttpRequestMessage request, int Cate_ID)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _courseCategoryService.GetById(Cate_ID);

                var responseData = Mapper.Map<CourseCategory, CourseCategoryViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getall")]
        //[HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request,string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _courseCategoryService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<CourseCategory>, IEnumerable<CourseCategoryViewModel>>(query);

                var paginationSet = new PaginationSet<CourseCategoryViewModel>()
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
        //[Route("create")]
        //[HttpPost]
        //[AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, CourseCategoryViewModel courseCategoryVm)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            var newCourseCategory = new CourseCategory();
        //            newCourseCategory.UpdateCourseCategory(courseCategoryVm);

        //            _courseCategoryService.Add(newCourseCategory);
        //            _courseCategoryService.Save();

        //            var responseData = Mapper.Map<CourseCategory, CourseCategoryViewModel>(newCourseCategory);
        //            response = request.CreateResponse(HttpStatusCode.Created, responseData);
        //        }

        //        return response;
        //    });
        //}
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, CourseCategoryViewModel courseCategoryVM)
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
                    var newCourseCategory = new CourseCategory();
                    newCourseCategory.UpdateCourseCategory(courseCategoryVM);

                    _courseCategoryService.Add(newCourseCategory);
                    _courseCategoryService.Save();

                    var responseData = Mapper.Map<CourseCategory, CourseCategoryViewModel>(newCourseCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        //[Route("create")]
        //[HttpPost]
        //[AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, CourseCategoryViewModel courseCategoryViewModel)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if(!ModelState.IsValid)
        //        {
        //            response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            var newCourseCategory = new CourseCategory();
        //            newCourseCategory.UpdateCourseCategory(courseCategoryViewModel);

        //            _courseCategoryService.Add(newCourseCategory);
        //            _courseCategoryService.Save();

        //            var responseData = Mapper.Map<CourseCategory, CourseCategoryViewModel>(newCourseCategory);
        //            response = request.CreateResponse(HttpStatusCode.Created, responseData);

        //        }
        //        return response;
        //    });
        //}




        //[Route("getbyid/{id:int}")]
        //[HttpGet]
        //public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        var model = new CourseCategory();
        //        _courseCategoryService.GetByID(id);

        //        var responseData = Mapper.Map<CourseCategory, CourseCategoryViewModel>(model);

        //        var response = request.CreateResponse(HttpStatusCode.OK, responseData);

        //        return response;
        //    });
        //}

        //[Route("getbyid/{id:int}")]
        //[HttpGet]
        ////[AllowAnonymous]
        //public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        var model = new CourseCategory();
        //        _courseCategoryService.GetByID(id);
        //        var responseData = Mapper.Map<CourseCategory,CourseCategoryViewModel > (model);
        //        var response = request.CreateResponse(HttpStatusCode.OK, responseData);
        //        return response;
        //    });
        //}



        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, CourseCategoryViewModel courseCategoryViewModel)
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
                    //var dbCourseCategory = new CourseCategory();
                    var dbCourseCategory = _courseCategoryService.GetById(courseCategoryViewModel.Cate_ID);

                    dbCourseCategory.UpdateCourseCategory(courseCategoryViewModel);
                    dbCourseCategory.UpdatedDate = DateTime.Now;

                    _courseCategoryService.Update(dbCourseCategory);
                    _courseCategoryService.Save();

                    var responseData = Mapper.Map<CourseCategory, CourseCategoryViewModel>(dbCourseCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

       
    }
}
       
       
    
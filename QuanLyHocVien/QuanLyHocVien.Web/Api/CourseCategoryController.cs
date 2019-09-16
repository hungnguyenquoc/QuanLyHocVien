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
using System.Web;
using System.Web.Mvc;

namespace QuanLyHocVien.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class CourseCategoryController : ApiControllerBase
    {
        ICourseCategoryService _courseCategoryService;
        public CourseCategoryController( IErrorService errorService, ICourseCategoryService courseCategoryService):base(errorService)
        {
            this._courseCategoryService = courseCategoryService;
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCategory = _courseCategoryService.GetAll();

                //var listPostCategoryVm = Mapper.Map<List<CourseCategoryViewModel>>(listCategory).ToList();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);

                return response;
            });
        }
        //public  HttpResponseMessage Get(HttpRequestMessage request)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (ModelState.IsValid)
        //        {
        //            request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            var listCategory = _courseCategoryService.GetAll();
        //            CourseCategoryViewModel courseCategoryViewModel = new CourseCategoryViewModel();
        //            //var listCourseCategoryVM = Mapper.Map<List<CourseCategoryViewModel>>(listCategory);
        //            //var listCourseCategoryVM = Mapper.Map<List<CourseCategoryViewModel>>(listCategory);

        //            response = request.CreateResponse(HttpStatusCode.OK, listCourseCategoryVM);

        //        }
        //        return response;
        //    });
        //}

        public HttpResponseMessage Post(HttpRequestMessage request, CourseCategory courseCategory)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _courseCategoryService.Add(courseCategory);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, CourseCategory courseCategory)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _courseCategoryService.Update(courseCategory);
                    _courseCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _courseCategoryService.Delete(id);
                    _courseCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
        //public HttpResponseMessage Post(HttpRequestMessage request)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (ModelState.IsValid)
        //        {
        //            request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            var category = _courseCategoryService.Add(courseCategory);
        //            _courseCategoryService.Save();
        //            response = request.CreateResponse(HttpStatusCode.OK, category);
        //        }
        //        return response;
        //    });
        //}
        // GET: CourseCategory
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}
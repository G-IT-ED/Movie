using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using HttpClientSample.Models;
using User = HttpClientSample.Models.User;

namespace HttpClient.Controllers
{
    public class RegistrationController : Controller
    {
        MoviesEntities _moviesEntities = new MoviesEntities();

        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult Create(Movie movie)
        {
            movie.Guid = Guid.NewGuid().ToString();
            _moviesEntities.Movies.Add(movie);
            _moviesEntities.SaveChanges();
            return Json("Успешное создание сеанса!");
        }
        
        public ActionResult Create()
        {
            return View();
        }


        
        public JsonResult UrlResponse()     //accessable using Url
        {
            return Json(new { Name = "UrlResponse", Response = "Response from Get", Date = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") }, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult TypedResponse()    //error if try to access using Url
        {
            return Json(new { Name = "TypedResponse", Response = "Response from Get", Date = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") }, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        //or [AcceptVerbs("GET","POST")]
        public JsonResult MultipleTypedResponse()
        {
            return Json(new { Name = "MultipleTypedResponse", Response = "Response from Get", Date = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") }, JsonRequestBehavior.AllowGet);
        }


    }
}
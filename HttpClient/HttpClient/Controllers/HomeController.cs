using System.Collections.Generic;
using System.Web.Mvc;
using HttpClientSample.Models;

namespace HttpClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       
       
        [System.Web.Http.HttpPost]
        public JsonResult Create(string movie)
        {
            return Json("Response from Create");
        }
    }
}

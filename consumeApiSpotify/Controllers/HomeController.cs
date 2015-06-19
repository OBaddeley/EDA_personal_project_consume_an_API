using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using consumeApiSpotify.Models;

namespace consumeApiSpotify.Controllers
{
    public class HomeController : Controller
    {
        private ApiDAL dal = new ApiDAL();

        public ActionResult Index()
        {

            return View();

        }

        public ActionResult SearchResult(string reportName)
        {
            var searchresult = dal.GetMusicInfo(reportName);
            return View(searchresult);
        }

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}
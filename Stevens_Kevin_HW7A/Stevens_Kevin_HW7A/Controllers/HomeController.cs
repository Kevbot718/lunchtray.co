//Author: Kevin Stevens
//Date: April 14, 2017
//Assignment: Homework 7
//Description: Implement identity into expanded member tracker MVC website linked with entity framework

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stevens_Kevin_HW7A.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //Redirect to index home view
        public ActionResult Index()
        {
            return View();
        }

        //Redirect to about page view when implemented
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //Redirect to contact page view when implemented
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
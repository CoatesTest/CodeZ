using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace CodeZ.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var log = LogManager.GetLogger("test");
            log.Info("hello");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            HttpClient httpclient = new HttpClient();
            httpclient.SendAsync(null).Wait();

            return View();
        }

        public ActionResult Contact(decimal amount, int type, int years)
        {
            ViewBag.Message = "Your contact page.";

            decimal result = 0;
            decimal disc = (years > 5) ? (decimal)5 / 100 : (decimal)years / 100;
            if (type == 1)
            {
                result = amount;
            }
            else if (type == 2)
            {
                result = (amount - (0.1m * amount)) - disc * (amount - (0.1m * amount));
            }
            else if (type == 3)
            {
                result = (0.7m * amount) - disc * (0.7m * amount);
            }
            else if (type == 4)
            {
                result = (amount - (0.5m * amount)) - disc * (amount - (0.5m * amount));
            }

            return View();
        }

        public ActionResult Test()
        {
            return View();

            var test = 3;
            ViewBag.Test = test;

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NowasteBLL;
using NowasteBLL.DTO;
using NowasteBLL.Services;
//using Nowaste.DAL;

namespace Nowaste.Controllers
{
    public class HomeController : Controller
    {
        ClientRequestService serv = new ClientRequestService();
        public ActionResult Index()
        {
           // IList<RequestDTO> list = serv.GetClientRequestsList(Guid.Parse("4166c85b-5a2e-4267-bd6e-a22e81f1804a"));
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

       

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

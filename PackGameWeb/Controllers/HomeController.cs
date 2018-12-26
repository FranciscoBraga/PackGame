using PackGameApplicationLayer.ApplicationImplemation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PackGameWeb.Controllers
{
    
    public class HomeController : Controller
    {
        private JogoApplication jogoApplication = new JogoApplication();
        public ActionResult Index()
        {

            return View(jogoApplication.GetJogo());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
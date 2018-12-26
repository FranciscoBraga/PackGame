using PackGameApplicationLayer.ApplicationImplemation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PackGameWeb.Areas.Usuario.Controllers
{
    public class AreaController : Controller
    {
        private JogoApplication jogoApplication = new JogoApplication();
        // GET: Usuario/Home
        public ActionResult Index()
        {
            return View(jogoApplication.GetJogo());
        }

        public ActionResult Create()
        {
            return  RedirectToAction("../Jogo/Create");
        }
        public ActionResult Delete(int id)
        {
            return RedirectToAction("../Jogo/Delete",new { id });
        }
        public ActionResult Details(int id)
        {
            return RedirectToAction("../Jogo/Details", new { id });
        }
        public ActionResult Edit(int id )
        {
            return RedirectToAction("../Jogo/Edit", new { id });
        }
        public ActionResult UploadGame(int id)
        {
            return RedirectToAction("../Jogo/UploadGame", new { id });
        }

    }
}
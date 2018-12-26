using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PackGameApplicationLayer;
using PackGameData.DataContext;

namespace PackGameWeb.Areas.Admin.Controllers
{
    public class EtapasController : Controller
    {
        private EtapaApplication etapaApplication = new EtapaApplication();

        // GET: Admin/Etapas
        public ActionResult Index()
        {
            return View(etapaApplication.GetEtapa());
        }

        // GET: Admin/Etapas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa etapa = etapaApplication.ProcurarEtapa(id);
            if (etapa == null)
            {
                return HttpNotFound();
            }
            return View(etapa);
        }

        // GET: Admin/Etapas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Etapas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEtapa,etapaGame")] Etapa etapa)
        {
            if (ModelState.IsValid)
            {
                etapaApplication.AdicionarEtapa(etapa);
                
                return RedirectToAction("Index");
            }

            return View(etapa);
        }

        // GET: Admin/Etapas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa etapa = etapaApplication.ProcurarEtapa(id);
            if (etapa == null)
            {
                return HttpNotFound();
            }
            return View(etapa);
        }

        // POST: Admin/Etapas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEtapa,etapaGame")] Etapa etapa)
        {
            if (ModelState.IsValid)
            {
                etapaApplication.AlterarEtapa(etapa);
                
                return RedirectToAction("Index");
            }
            return View(etapa);
        }

        // GET: Admin/Etapas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa etapa = etapaApplication.ProcurarEtapa(id);
            if (etapa == null)
            {
                return HttpNotFound();
            }
            return View(etapa);
        }

        // POST: Admin/Etapas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etapa etapa = etapaApplication.ProcurarEtapa(id);
            etapaApplication.ExcluirEtapa(etapa);
       
            return RedirectToAction("Index");
        }

        
    }
}

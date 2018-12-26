using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PackGameApplicationLayer.ApplicationImplemation;
using PackGameData.DataContext;

namespace PackGameWeb.Areas.Admin.Controllers
{
    public class GeneroController : Controller
    {
        private GeneroApplication  generoApplication = new GeneroApplication();

        // GET: Admin/Genero
        public ActionResult Index()
        {
            return View(generoApplication.GetGenero());
        }

        // GET: Admin/Genero/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genero genero = generoApplication.ProcurarGenero(id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }

        // GET: Admin/Genero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Genero/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idGenero,generoGame,descricao")] Genero genero)
        {
            if (ModelState.IsValid)
            {
                generoApplication.AdicionarGenero(genero);
               
                return RedirectToAction("Index");
            }

            return View(genero);
        }

        // GET: Admin/Genero/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genero genero = generoApplication.ProcurarGenero(id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }

        // POST: Admin/Genero/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idGenero,generoGame,descricao")] Genero genero)
        {
            if (ModelState.IsValid)
            {
                generoApplication.AlterarGenero(genero);
                
                return RedirectToAction("Index");
            }
            return View(genero);
        }

        // GET: Admin/Genero/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genero genero = generoApplication.ProcurarGenero(id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }

        // POST: Admin/Genero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genero genero = generoApplication.ProcurarGenero(id);
            generoApplication.ExcluirGenero(genero);
          
            return RedirectToAction("Index");
        }

    
    }
}

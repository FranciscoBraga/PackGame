using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PackGameData.DataContext;
using PackGameData.RepositoryImplemetation;

namespace PackGameWeb.Areas.Admin.Controllers
{
    public class PerfilController : Controller
    {
        private PerfilApplication perfilApplication = new PerfilApplication();

        // GET: Admin/Perfil
        public ActionResult Index()
        {
            return View(perfilApplication.GetPerfil());
        }

        // GET: Admin/Perfil/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = perfilApplication.ProcurarPerfil(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // GET: Admin/Perfil/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Perfil/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPerfil,nomePerfil,nivel")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                perfilApplication.AdicionarPerfil(perfil);
                
                return RedirectToAction("Index");
            }

            return View(perfil);
        }

        // GET: Admin/Perfil/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = perfilApplication.ProcurarPerfil(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // POST: Admin/Perfil/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPerfil,nomePerfil,nivel")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                perfilApplication.AlterarPerfil(perfil);
             
                return RedirectToAction("Index");
            }
            return View(perfil);
        }

        // GET: Admin/Perfil/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = perfilApplication.ProcurarPerfil(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // POST: Admin/Perfil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Perfil perfil = perfilApplication.ProcurarPerfil(id);
            perfilApplication.AlterarPerfil(perfil);
            
            return RedirectToAction("Index");
        }

      
    }
}

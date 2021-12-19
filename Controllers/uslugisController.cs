using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using newbarbershop;

namespace newbarbershop.Controllers
{
    [Authorize]
    public class uslugisController : Controller
    {
        private barbershopEntities db = new barbershopEntities();

        // GET: uslugis
        public ActionResult Index()
        {
            return View(db.uslugi.ToList());
        }

        // GET: uslugis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uslugi uslugi = db.uslugi.Find(id);
            if (uslugi == null)
            {
                return HttpNotFound();
            }
            return View(uslugi);
        }

        // GET: uslugis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: uslugis/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_uslugi,nazwa,cena,czas_wykonania_w_minutach_")] uslugi uslugi)
        {
            if (ModelState.IsValid)
            {
                db.uslugi.Add(uslugi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uslugi);
        }

        // GET: uslugis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uslugi uslugi = db.uslugi.Find(id);
            if (uslugi == null)
            {
                return HttpNotFound();
            }
            return View(uslugi);
        }

        // POST: uslugis/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_uslugi,nazwa,cena,czas_wykonania_w_minutach_")] uslugi uslugi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uslugi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uslugi);
        }

        // GET: uslugis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uslugi uslugi = db.uslugi.Find(id);
            if (uslugi == null)
            {
                return HttpNotFound();
            }
            return View(uslugi);
        }

        // POST: uslugis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            uslugi uslugi = db.uslugi.Find(id);
            db.uslugi.Remove(uslugi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

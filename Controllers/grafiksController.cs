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
    public class grafiksController : Controller
    {
        private barbershopEntities db = new barbershopEntities();

        // GET: grafiks
        public ActionResult Index()
        {
            var grafik = db.grafik.Include(g => g.pracownicy);
            return View(grafik.ToList());
        }

        // GET: grafiks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grafik grafik = db.grafik.Find(id);
            if (grafik == null)
            {
                return HttpNotFound();
            }
            return View(grafik);
        }

        // GET: grafiks/Create
        public ActionResult Create()
        {
            ViewBag.id_pracownika = new SelectList(db.pracownicy, "id_pracownika", "imie");
            return View();
        }

        // POST: grafiks/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_zmiany,id_pracownika,data,od_godziny,do_godziny")] grafik grafik)
        {
            if (ModelState.IsValid)
            {
                db.grafik.Add(grafik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_pracownika = new SelectList(db.pracownicy, "id_pracownika", "imie", grafik.id_pracownika);
            return View(grafik);
        }

        // GET: grafiks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grafik grafik = db.grafik.Find(id);
            if (grafik == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pracownika = new SelectList(db.pracownicy, "id_pracownika", "imie", grafik.id_pracownika);
            return View(grafik);
        }

        // POST: grafiks/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_zmiany,id_pracownika,data,od_godziny,do_godziny")] grafik grafik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grafik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pracownika = new SelectList(db.pracownicy, "id_pracownika", "imie", grafik.id_pracownika);
            return View(grafik);
        }

        // GET: grafiks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grafik grafik = db.grafik.Find(id);
            if (grafik == null)
            {
                return HttpNotFound();
            }
            return View(grafik);
        }

        // POST: grafiks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            grafik grafik = db.grafik.Find(id);
            db.grafik.Remove(grafik);
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

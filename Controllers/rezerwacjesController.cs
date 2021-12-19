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
    public class rezerwacjesController : Controller
    {
        private barbershopEntities db = new barbershopEntities();

        // GET: rezerwacjes
        public ActionResult Index()
        {
            var rezerwacje = db.rezerwacje.Include(r => r.klienci).Include(r => r.pracownicy).Include(r => r.uslugi);
            return View(rezerwacje.ToList());
        }

        // GET: rezerwacjes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rezerwacje rezerwacje = db.rezerwacje.Find(id);
            if (rezerwacje == null)
            {
                return HttpNotFound();
            }
            return View(rezerwacje);
        }

        // GET: rezerwacjes/Create
        public ActionResult Create()
        {
            ViewBag.id_klienta = new SelectList(db.klienci, "id_klienta", "imie");
            ViewBag.id_pracownika = new SelectList(db.pracownicy, "id_pracownika", "imie");
            ViewBag.id_uslugi = new SelectList(db.uslugi, "id_uslugi", "nazwa");
            return View();
        }

        // POST: rezerwacjes/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_rezerwacji,id_klienta,id_pracownika,id_uslugi,data,godzina")] rezerwacje rezerwacje)
        {
            if (ModelState.IsValid)
            {
                db.rezerwacje.Add(rezerwacje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_klienta = new SelectList(db.klienci, "id_klienta", "imie", rezerwacje.id_klienta);
            ViewBag.id_pracownika = new SelectList(db.pracownicy, "id_pracownika", "imie", rezerwacje.id_pracownika);
            ViewBag.id_uslugi = new SelectList(db.uslugi, "id_uslugi", "nazwa", rezerwacje.id_uslugi);
            return View(rezerwacje);
        }

        // GET: rezerwacjes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rezerwacje rezerwacje = db.rezerwacje.Find(id);
            if (rezerwacje == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_klienta = new SelectList(db.klienci, "id_klienta", "imie", rezerwacje.id_klienta);
            ViewBag.id_pracownika = new SelectList(db.pracownicy, "id_pracownika", "imie", rezerwacje.id_pracownika);
            ViewBag.id_uslugi = new SelectList(db.uslugi, "id_uslugi", "nazwa", rezerwacje.id_uslugi);
            return View(rezerwacje);
        }

        // POST: rezerwacjes/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_rezerwacji,id_klienta,id_pracownika,id_uslugi,data,godzina")] rezerwacje rezerwacje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rezerwacje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_klienta = new SelectList(db.klienci, "id_klienta", "imie", rezerwacje.id_klienta);
            ViewBag.id_pracownika = new SelectList(db.pracownicy, "id_pracownika", "imie", rezerwacje.id_pracownika);
            ViewBag.id_uslugi = new SelectList(db.uslugi, "id_uslugi", "nazwa", rezerwacje.id_uslugi);
            return View(rezerwacje);
        }

        // GET: rezerwacjes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rezerwacje rezerwacje = db.rezerwacje.Find(id);
            if (rezerwacje == null)
            {
                return HttpNotFound();
            }
            return View(rezerwacje);
        }

        // POST: rezerwacjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rezerwacje rezerwacje = db.rezerwacje.Find(id);
            db.rezerwacje.Remove(rezerwacje);
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

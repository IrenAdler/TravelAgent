using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelStores.Models;
using System.Data.Entity;
//using TravelStores.Util;

namespace TravelStores.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        TravelDb db = new TravelDb();

        public ActionResult HotTour()
        {
            

            return View(db.Travels);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Travel travel)  // Добавляем данные в модель
        {
            db.Entry(travel).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id) // Удаляем данные из модели
        {
            Travel b = db.Travels.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Travel b = db.Travels.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Travels.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditTravel(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Travel travel = db.Travels.Find(id);
            if (travel != null)
            {
                return View(travel);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditTravel(Travel travel)
        {
            db.Entry(travel).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Контакты";

            return View();
        }

        [HttpGet]   // при получении запроса get
        public ActionResult Buy(int id)
        {
            ViewBag.PurchesId = id;
            return View();
        }

        [HttpPost] // при получении запроса Post
        public string Buy(Purches purches)
        {

            // добавляем информацию о покупке в базу данных
            db.Purcheses.Add(purches);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо, " + purches.Name + ", за покупку!";
        }

        protected override void Dispose(bool disposing) //закрытие подключения к базе данных
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        private DateTime getToday()
        {
            return DateTime.Now;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trainee_Recruitment_Application.Models;

namespace Trainee_Recruitment_Application.Controllers
{
    [Authorize]
    public class BatchesController : Controller
    {
        TraineeDbContext db = new TraineeDbContext();
        // GET: Batches
        public ActionResult Index()
        {
            return View(db.Batches.ToList());
        }

        // GET: Batches/Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Batch b)
        {
            if (ModelState.IsValid)
            {
                db.Batches.Add(b);
                db.SaveChanges();
                return PartialView("_Success");
            }
            return PartialView("_Fail");
        }

        public ActionResult Edit(int id)
        {
            return View(db.Batches.First(x => x.BatchId == id));
        }

        [HttpPost]
        public ActionResult Edit(Batch b)
        {
            if (ModelState.IsValid)
            {
                db.Entry(b).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(b);
        }

        public ActionResult Delete(int id)
        {
            return View(db.Batches.First(x => x.BatchId == id));
        }

        [HttpPost]
        [ActionName("Delete")]

        public ActionResult DeleteConfirm(Batch b)
        {
            if (ModelState.IsValid)
            {

                db.Entry(b).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(b);
        }
    }
}
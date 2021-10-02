using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trainee_Recruitment_Application.Models;
using Trainee_Recruitment_Application.ViewModels;

namespace Trainee_Recruitment_Application.Controllers
{
    [Authorize]
    public class TraineesController : Controller
    {
        TraineeDbContext db = new TraineeDbContext();
        // GET: Trainees
        public ActionResult Index()
        {
            return View(db.Trainees.ToList());
        }

        public ActionResult Create()
        {

            ViewBag.SelectList = new SelectList(db.Batches.ToList(), "BatchId", "BatchName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(TraineeVM tr)
        {
            if (ModelState.IsValid)
            {
                string fName = "no-pic.png";
                if (tr.Picture != null)
                {
                    fName = Guid.NewGuid() + Path.GetExtension(tr.Picture.FileName);
                    tr.Picture.SaveAs(Server.MapPath("~/Uploads/") + fName);
                }

                db.Trainees.Add(new Trainee { TraineeName = tr.TraineeName, Round = tr.Round, Picture = fName, BatchId = tr.BatchId });
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.SelectList = new SelectList(db.Batches.ToList(), "BatchId", "BatchName");
            return View(tr);
        }

        public ActionResult Edit(int id)
        {
            var data = db.Trainees.First(x => x.TraineeId == id);
            ViewBag.Pic = data.Picture;
            ViewBag.SelectList = new SelectList(db.Batches.ToList(), "BatchId", "BatchName");
            return View(new TraineeVM
            {
                TraineeId = data.TraineeId,
                TraineeName = data.TraineeName,
                Round = data.Round,
                BatchId = data.BatchId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TraineeVM t)
        {
            if (ModelState.IsValid)
            {
                var tvm = db.Trainees.First(x => x.TraineeId == t.TraineeId);
                if (t.Picture != null && t.Picture.FileName != "")
                {
                    var f = Server.MapPath("~/Uploads/");
                    string fName = Guid.NewGuid() + Path.GetExtension(t.Picture.FileName);
                    t.Picture.SaveAs(f + fName);
                    tvm.Picture = fName;
                }
                tvm.TraineeName = t.TraineeName;
                tvm.Round = t.Round;
                tvm.BatchId = t.BatchId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SelectList = new SelectList(db.Batches.ToList(), "BatchId", "BatchName");
            //ViewBag.TypeList = db.Batches.ToList();
            return View(t);
        }

        public ActionResult Delete(int id)
        {

            return View(db.Trainees.First(x => x.TraineeId == id));
        }
        [HttpPost]
        public ActionResult Delete(Trainee t)
        {
            db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
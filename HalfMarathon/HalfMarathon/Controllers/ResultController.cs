using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HalfMarathon.Models;

namespace HalfMarathon.Controllers
{
    public class ResultController : Controller
    {
        private ParticipantModel db = new ParticipantModel();

        // GET: Result
        public ActionResult Index(bool? timeAscSortOrder, string year)
        {
            var dbResult = db.Result.Include(r => r.Participant);
            var result = from r in dbResult select r;

            if ( timeAscSortOrder ?? true )
            {
                result = result.OrderBy(r => r.Time);
            }
            else
            {
                result = result.OrderByDescending(t => t.Time);
            }

            if (!string.IsNullOrEmpty(year))
            {
                int yearInt;
                bool res = int.TryParse(year, out yearInt);
                if (res == true)
                {
                    result = result.Where(r => r.Year == yearInt);
                }
            }

            var vm = new ResultViewModel()
            {
                Results = result.ToList(),
                TimeAscSortOrder = timeAscSortOrder ?? true,
                Year = year,
                Years = result.Select(r => r.Year).Distinct().OrderBy(r => r).ToList()
        };
            //ModelState.Clear();
            return View(vm);
        }

        [HttpGet]
        public PartialViewResult ResultPartial(bool timeAscSortOrder, string year)
        {
            var dbResult = db.Result.Include(r => r.Participant);
            //var result = from r in dbResult select r;

            if (timeAscSortOrder == true)
            {
                dbResult = dbResult.OrderBy(t => t.Time);
            }
            else
            {
                dbResult = dbResult.OrderByDescending(t => t.Time);
            }

            if (!string.IsNullOrEmpty(year))
            {
                int yearInt;
                bool res = int.TryParse(year, out yearInt);
                if (res == true)
                {
                    if (yearInt > 0)
                    {
                        dbResult = dbResult.Where(r => r.Year == yearInt);
                    }
                }
            }

            var vm = new ResultViewModel()
            {
                Results = dbResult.ToList(),
                TimeAscSortOrder = timeAscSortOrder,
                Year = year,
                Years = dbResult.Select(r => r.Year).Distinct().OrderBy(r => r).ToList()
            };
            //ModelState.Clear();
            return PartialView("ResultPartial", vm);
        }

        // GET: Result/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Result.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // GET: Result/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Participant_Id = new SelectList(db.Participant, "Id", "FirstName");
            return View();
        }

        // POST: Result/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Time,Year,Participant_Id")] Result result)
        {
            if (ModelState.IsValid)
            {
                db.Result.Add(result);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Participant_Id = new SelectList(db.Participant, "Id", "FirstName", result.Participant_Id);
            return View(result);
        }

        // GET: Result/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Result.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            ViewBag.Participant_Id = new SelectList(db.Participant, "Id", "FirstName", result.Participant_Id);
            return View(result);
        }

        // POST: Result/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Time,Year,Participant_Id")] Result result)
        {
            if (ModelState.IsValid)
            {
                db.Entry(result).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Participant_Id = new SelectList(db.Participant, "Id", "FirstName", result.Participant_Id);
            return View(result);
        }

        // GET: Result/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Result.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // POST: Result/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Result result = db.Result.Find(id);
            db.Result.Remove(result);
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

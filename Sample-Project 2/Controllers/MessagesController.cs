using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sample_Project_2.Models;

namespace Sample_Project_2.Controllers
{
    public class MessagesController : Controller
    {
        private MessagesContext db = new MessagesContext();

        // GET: MessageEntries
        public ActionResult Index()
        {
            return View(db.MessageEntries.ToList());
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(MessageEntry messageEntry)
        //{
        //    messageEntry.Timestamp = DateTime.UtcNow;
        //    messageEntry.Edited = false;

        //    if (ModelState.IsValid)
        //    {
        //        db.MessageEntries.Add(messageEntry);
        //        db.SaveChanges();
        //    }

        //    return View();
        //}

        // GET: MessageEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MessageEntry messageEntry = db.MessageEntries.Find(id);

            if (messageEntry == null)
            {
                return HttpNotFound();
            }

            return View(messageEntry); //messageEntry is the MODEL that the view requires.
        }

        // GET: MessageEntries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MessageEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Message,Timestamp")] MessageEntry messageEntry)
        {
            messageEntry.Timestamp = DateTime.UtcNow;

            if (ModelState.IsValid)
            {
                db.MessageEntries.Add(messageEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messageEntry);
        }

        // GET: MessageEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageEntry messageEntry = db.MessageEntries.Find(id);
            if (messageEntry == null)
            {
                return HttpNotFound();
            }
            return View(messageEntry);
        }

        // POST: MessageEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MessageEntry messageEntry)
        {
            var entry = db.Set<MessageEntry>().First(a => a.ID == messageEntry.ID);

            entry.Edited = true;
            entry.Timestamp = DateTime.UtcNow;
            entry.Message = messageEntry.Message;

            if (ModelState.IsValid)
            {
                db.Entry(entry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(messageEntry);
        }

        // GET: MessageEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageEntry messageEntry = db.MessageEntries.Find(id);
            if (messageEntry == null)
            {
                return HttpNotFound();
            }
            return View(messageEntry);
        }

        // POST: MessageEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MessageEntry messageEntry = db.MessageEntries.Find(id);
            db.MessageEntries.Remove(messageEntry);
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

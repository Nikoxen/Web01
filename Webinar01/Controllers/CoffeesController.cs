using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Webinar01.Data;
using Webinar01.Models;
using System.Net.Http;

namespace Webinar01.Controllers
{
    public class CoffeesController : Controller
    {
        private Webinar01Context db = new Webinar01Context();

        // GET: Coffees
        public async Task<ActionResult> Index()
        {
            return View(await db.Coffees.ToListAsync());
        }

        // GET: Coffees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffee coffee = await db.Coffees.FindAsync(id);
            if (coffee == null)
            {
                return HttpNotFound();
            }
            return View(coffee);
        }

        // GET: Coffees/Create
        public ActionResult Create()
        {
            return View(new CoffeCreate()
            {
                Companies = new List<Company>()
                {
                    new Company
                    {
                        CompanyName = "mahmut",
                        Id = 1
                    },
                    new Company
                    {
                        CompanyName = "mahmut2",
                        Id = 2
                    },
                    new Company
                    {
                        CompanyName = "mahmut3",
                        Id = 3
                    }
                }
            });
        }

        // POST: Coffees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Volume")] Coffee coffee)
        {
            if (ModelState.IsValid)
            {
                db.Coffees.Add(coffee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(coffee);
        }

        // GET: Coffees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffee coffee = await db.Coffees.FindAsync(id);
            if (coffee == null)
            {
                return HttpNotFound();
            }
            return View(coffee);
        }

        // POST: Coffees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Volume")] Coffee coffee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coffee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(coffee);
        }

        // GET: Coffees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffee coffee = await db.Coffees.FindAsync(id);
            if (coffee == null)
            {
                return HttpNotFound();
            }
            return View(coffee);
        }

        // POST: Coffees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Coffee coffee = await db.Coffees.FindAsync(id);
            db.Coffees.Remove(coffee);
            await db.SaveChangesAsync();
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

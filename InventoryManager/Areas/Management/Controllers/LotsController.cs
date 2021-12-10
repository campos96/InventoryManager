using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryManager.Models;

namespace InventoryManager.Areas.Management.Controllers
{
    [Authorize]
    public class LotsController : Controller
    {
        private InventoryManagementContext db = new InventoryManagementContext();

        // GET: Management/Lots
        public async Task<ActionResult> Index()
        {
            var lots = db.Lots.Include(l => l.Product)
                .Where(l => l.Quantity > 0)
                .OrderByDescending(l => l.ReceivedAt);
            return View(await lots.ToListAsync());
        }

        // GET: Management/Lots/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lot lot = await db.Lots.FindAsync(id);
            if (lot == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", lot.ProductSku);
            return View(lot);
        }

        // GET: Management/Lots/Create
        public ActionResult Create()
        {
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name");
            return View();
        }

        // POST: Management/Lots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Lot lot)
        {
            if (ModelState.IsValid)
            {
                db.Lots.Add(lot);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", lot.ProductSku);
            return View(lot);
        }

        // GET: Management/Lots/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lot lot = await db.Lots.FindAsync(id);
            if (lot == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", lot.ProductSku);
            return View(lot);
        }

        // POST: Management/Lots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Lot lot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lot).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", lot.ProductSku);
            return View(lot);
        }

        // GET: Management/Lots/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lot lot = await db.Lots.FindAsync(id);
            if (lot == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", lot.ProductSku);
            return View(lot);
        }

        // POST: Management/Lots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Lot lot = await db.Lots.FindAsync(id);
            db.Lots.Remove(lot);
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

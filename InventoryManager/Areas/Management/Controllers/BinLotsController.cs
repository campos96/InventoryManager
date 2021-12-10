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
    public class BinLotsController : Controller
    {
        private InventoryManagementContext db = new InventoryManagementContext();

        // GET: Management/BinLots
        public async Task<ActionResult> Index()
        {
            var binLots = db.BinLots
                .Where(b => b.Lot.Quantity > 0)
                .Include(b => b.Bin)
                .Include(b => b.Lot);
            return View(await binLots.ToListAsync());
        }

        // GET: Management/BinLots/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinLot binLot = await db.BinLots.FindAsync(id);
            if (binLot == null)
            {
                return HttpNotFound();
            }
            ViewBag.BinNumber = new SelectList(db.Bins, "Number", "Number", binLot.BinNumber);
            ViewBag.LotNumber = new SelectList(db.Lots, "Number", "ProductSku", binLot.LotNumber);
            return View(binLot);
        }

        // GET: Management/BinLots/Create
        public ActionResult Create()
        {
            ViewBag.BinNumber = new SelectList(db.Bins, "Number", "Number");
            ViewBag.LotNumber = new SelectList(db.Lots, "Number", "ProductSku");
            return View();
        }

        // POST: Management/BinLots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BinLot binLot)
        {
            if (ModelState.IsValid)
            {
                binLot.ID = Guid.NewGuid();
                db.BinLots.Add(binLot);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BinNumber = new SelectList(db.Bins, "Number", "Number", binLot.BinNumber);
            ViewBag.LotNumber = new SelectList(db.Lots, "Number", "ProductSku", binLot.LotNumber);
            return View(binLot);
        }

        // GET: Management/BinLots/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinLot binLot = await db.BinLots.FindAsync(id);
            if (binLot == null)
            {
                return HttpNotFound();
            }
            ViewBag.BinNumber = new SelectList(db.Bins, "Number", "Number", binLot.BinNumber);
            ViewBag.LotNumber = new SelectList(db.Lots, "Number", "ProductSku", binLot.LotNumber);
            return View(binLot);
        }

        // POST: Management/BinLots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(BinLot binLot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(binLot).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BinNumber = new SelectList(db.Bins, "Number", "Number", binLot.BinNumber);
            ViewBag.LotNumber = new SelectList(db.Lots, "Number", "ProductSku", binLot.LotNumber);
            return View(binLot);
        }

        // GET: Management/BinLots/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinLot binLot = await db.BinLots.FindAsync(id);
            if (binLot == null)
            {
                return HttpNotFound();
            }
            ViewBag.BinNumber = new SelectList(db.Bins, "Number", "Number", binLot.BinNumber);
            ViewBag.LotNumber = new SelectList(db.Lots, "Number", "ProductSku", binLot.LotNumber);
            return View(binLot);
        }

        // POST: Management/BinLots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            BinLot binLot = await db.BinLots.FindAsync(id);
            db.BinLots.Remove(binLot);
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

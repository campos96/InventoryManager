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
    public class InventoryTransactionsController : Controller
    {
        private InventoryManagementContext db = new InventoryManagementContext();

        // GET: Management/InventoryTransactions
        public async Task<ActionResult> Index()
        {
            var inventoryTransactions = db.InventoryTransactions
                .Include(i => i.BinLot)
                .Include(i => i.User)
                .OrderByDescending(i => i.Date);
            return View(await inventoryTransactions.ToListAsync());
        }

        // GET: Management/InventoryTransactions/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryTransaction inventoryTransaction = await db.InventoryTransactions.FindAsync(id);
            if (inventoryTransaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.BinLotID = new SelectList(db.BinLots, "ID", "BinNumber", inventoryTransaction.BinLotID);
            ViewBag.Username = new SelectList(db.Users, "UserName", "Name", inventoryTransaction.Username);
            return View(inventoryTransaction);
        }

        // GET: Management/InventoryTransactions/Create
        public ActionResult Create()
        {
            ViewBag.BinLotID = new SelectList(db.BinLots, "ID", "BinNumber");
            ViewBag.Username = new SelectList(db.Users, "UserName", "Name");
            return View();
        }

        // POST: Management/InventoryTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(InventoryTransaction inventoryTransaction)
        {
            if (ModelState.IsValid)
            {
                inventoryTransaction.ID = Guid.NewGuid();
                db.InventoryTransactions.Add(inventoryTransaction);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BinLotID = new SelectList(db.BinLots, "ID", "BinNumber", inventoryTransaction.BinLotID);
            ViewBag.Username = new SelectList(db.Users, "UserName", "Name", inventoryTransaction.Username);
            return View(inventoryTransaction);
        }

        // GET: Management/InventoryTransactions/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryTransaction inventoryTransaction = await db.InventoryTransactions.FindAsync(id);
            if (inventoryTransaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.BinLotID = new SelectList(db.BinLots, "ID", "BinNumber", inventoryTransaction.BinLotID);
            ViewBag.Username = new SelectList(db.Users, "UserName", "Name", inventoryTransaction.Username);
            return View(inventoryTransaction);
        }

        // POST: Management/InventoryTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(InventoryTransaction inventoryTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventoryTransaction).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BinLotID = new SelectList(db.BinLots, "ID", "BinNumber", inventoryTransaction.BinLotID);
            ViewBag.Username = new SelectList(db.Users, "UserName", "Name", inventoryTransaction.Username);
            return View(inventoryTransaction);
        }

        // GET: Management/InventoryTransactions/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryTransaction inventoryTransaction = await db.InventoryTransactions.FindAsync(id);
            if (inventoryTransaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.BinLotID = new SelectList(db.BinLots, "ID", "BinNumber", inventoryTransaction.BinLotID);
            ViewBag.Username = new SelectList(db.Users, "UserName", "Name", inventoryTransaction.Username);
            return View(inventoryTransaction);
        }

        // POST: Management/InventoryTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            InventoryTransaction inventoryTransaction = await db.InventoryTransactions.FindAsync(id);
            db.InventoryTransactions.Remove(inventoryTransaction);
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

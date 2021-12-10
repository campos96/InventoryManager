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
    public class InventoryController : Controller
    {
        private InventoryManagementContext db = new InventoryManagementContext();

        // GET: Management/Inventory
        public async Task<ActionResult> Index()
        {
            var inventories = db.Inventories.Include(i => i.Product);
            return View(await inventories.ToListAsync());
        }

        // GET: Management/Inventory/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = await db.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", inventory.ProductSku);
            return View(inventory);
        }

        // GET: Management/Inventory/Create
        public ActionResult Create()
        {
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name");
            return View();
        }

        // POST: Management/Inventory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                inventory.ID = Guid.NewGuid();
                db.Inventories.Add(inventory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", inventory.ProductSku);
            return View(inventory);
        }

        // GET: Management/Inventory/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = await db.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", inventory.ProductSku);
            return View(inventory);
        }

        // POST: Management/Inventory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", inventory.ProductSku);
            return View(inventory);
        }

        // GET: Management/Inventory/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = await db.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", inventory.ProductSku);
            return View(inventory);
        }

        // POST: Management/Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Inventory inventory = await db.Inventories.FindAsync(id);
            db.Inventories.Remove(inventory);
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

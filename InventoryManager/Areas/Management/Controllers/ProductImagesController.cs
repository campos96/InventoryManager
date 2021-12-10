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
    public class ProductImagesController : Controller
    {
        private InventoryManagementContext db = new InventoryManagementContext();

        // GET: Management/ProductImages
        public async Task<ActionResult> Index()
        {
            var productImages = db.ProductImages.Include(p => p.Product);
            return View(await productImages.ToListAsync());
        }

        // GET: Management/ProductImages/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImage productImage = await db.ProductImages.FindAsync(id);
            if (productImage == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", productImage.ProductSku);
            return View(productImage);
        }

        // GET: Management/ProductImages/Create
        public ActionResult Create()
        {
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name");
            return View();
        }

        // POST: Management/ProductImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductImage productImage)
        {
            if (ModelState.IsValid)
            {
                productImage.ID = Guid.NewGuid();
                db.ProductImages.Add(productImage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", productImage.ProductSku);
            return View(productImage);
        }

        // GET: Management/ProductImages/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImage productImage = await db.ProductImages.FindAsync(id);
            if (productImage == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", productImage.ProductSku);
            return View(productImage);
        }

        // POST: Management/ProductImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductImage productImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productImage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", productImage.ProductSku);
            return View(productImage);
        }

        // GET: Management/ProductImages/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImage productImage = await db.ProductImages.FindAsync(id);
            if (productImage == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", productImage.ProductSku);
            return View(productImage);
        }

        // POST: Management/ProductImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ProductImage productImage = await db.ProductImages.FindAsync(id);
            db.ProductImages.Remove(productImage);
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

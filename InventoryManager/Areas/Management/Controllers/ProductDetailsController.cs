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
    public class ProductDetailsController : Controller
    {
        private InventoryManagementContext db = new InventoryManagementContext();

        // GET: Management/ProductDetails
        public async Task<ActionResult> Index()
        {
            var productDetails = db.ProductDetails.Include(p => p.Product);
            return View(await productDetails.ToListAsync());
        }

        // GET: Management/ProductDetails/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetail productDetail = await db.ProductDetails.FindAsync(id);
            if (productDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", productDetail.ProductSku);
            return View(productDetail);
        }

        // GET: Management/ProductDetails/Create
        public ActionResult Create()
        {
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name");
            return View();
        }

        // POST: Management/ProductDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductDetail productDetail)
        {
            if (ModelState.IsValid)
            {
                productDetail.ID = Guid.NewGuid();
                db.ProductDetails.Add(productDetail);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", productDetail.ProductSku);
            return View(productDetail);
        }

        // GET: Management/ProductDetails/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetail productDetail = await db.ProductDetails.FindAsync(id);
            if (productDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", productDetail.ProductSku);
            return View(productDetail);
        }

        // POST: Management/ProductDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductDetail productDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productDetail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", productDetail.ProductSku);
            return View(productDetail);
        }

        // GET: Management/ProductDetails/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetail productDetail = await db.ProductDetails.FindAsync(id);
            if (productDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", productDetail.ProductSku);
            return View(productDetail);
        }

        // POST: Management/ProductDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ProductDetail productDetail = await db.ProductDetails.FindAsync(id);
            db.ProductDetails.Remove(productDetail);
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

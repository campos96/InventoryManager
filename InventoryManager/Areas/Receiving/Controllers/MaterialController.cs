using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InventoryManager.Areas.Receiving.Controllers
{
    [Authorize]
    public class MaterialController : Controller
    {
        private InventoryManagementContext db = new InventoryManagementContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Receive()
        {
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name");
            ViewBag.BinNumber = new SelectList(db.Bins, "Number", "Number");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Receive(vmReceive vmReceive)
        {
            if (ModelState.IsValid)
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var lot = new Lot
                        {
                            Number = vmReceive.LotNumber,
                            ProductSku = vmReceive.ProductSku,
                            Quantity = vmReceive.Quantity,
                            ReceivedAt = DateTime.Now,
                            ExpirationDate = vmReceive.ExpirationDate
                        };

                        db.Lots.Add(lot);
                        await db.SaveChangesAsync();

                        var binLot = new BinLot
                        {
                            ID = Guid.NewGuid(),
                            LotNumber = lot.Number,
                            BinNumber = vmReceive.BinNumber
                        };

                        db.BinLots.Add(binLot);
                        await db.SaveChangesAsync();

                        var inventory = db.Inventories.Where(i => i.ProductSku == vmReceive.ProductSku).FirstOrDefault();
                        if (inventory == null)
                        {
                            throw new Exception("Inventory not found");
                        }

                        inventory.QuantityAvailable += vmReceive.Quantity;
                        db.Entry(inventory).State = EntityState.Modified;
                        await db.SaveChangesAsync();


                        var inventoryTransaction = new InventoryTransaction
                        {
                            ID = Guid.NewGuid(),
                            BinLotID = binLot.ID,
                            TransactionType = TransactionType.Receive,
                            Quantity = vmReceive.Quantity,
                            Date = DateTime.Now,
                            Username = User.Identity.Name
                        };

                        db.InventoryTransactions.Add(inventoryTransaction);
                        await db.SaveChangesAsync();


                        transaction.Commit();

                        return RedirectToAction("Index", "Lots", new { Area = "Management" });
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        ModelState.AddModelError("Error", ex.Message);
                    }
                }
            }

            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", vmReceive.ProductSku);
            ViewBag.BinNumber = new SelectList(db.Bins, "Number", "Number", vmReceive.BinNumber);
            return View(vmReceive);
        }

        public ActionResult Issue()
        {
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Issue(vmIssue vmIssue)
        {
            if (ModelState.IsValid)
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var inventory = await db.Inventories.Where(i => i.ProductSku == vmIssue.ProductSku).FirstOrDefaultAsync();
                        if (inventory == null)
                        {
                            throw new Exception("Inventory no encontrado");
                        }

                        if (vmIssue.Quantity > inventory.QuantityAvailable)
                        {
                            ModelState.AddModelError("Quantity", $"Cantidad mayor a la disponible... (Cantidad disponible: {inventory.QuantityAvailable})");
                            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", vmIssue.ProductSku);
                            return View(vmIssue);
                        }


                        var lots = await db.Lots
                            .Where(l => l.ProductSku == vmIssue.ProductSku && l.Quantity > 0)
                            .OrderBy(l => l.ReceivedAt)
                            .ToListAsync();

                        var quantityIssued = 0;
                        var affectedquantity = 0;

                        foreach (var lot in lots)
                        {
                            if (lot.Quantity >= vmIssue.Quantity - quantityIssued)
                            {
                                affectedquantity = vmIssue.Quantity - quantityIssued;
                                lot.Quantity -= vmIssue.Quantity - quantityIssued;
                                db.Entry(lot).State = EntityState.Modified;
                                await db.SaveChangesAsync();
                                quantityIssued += vmIssue.Quantity - quantityIssued;
                                break;
                            }
                            else
                            {
                                quantityIssued += lot.Quantity;
                                affectedquantity = lot.Quantity;
                                lot.Quantity = 0;
                                db.Entry(lot).State = EntityState.Modified;
                                await db.SaveChangesAsync();
                            }

                            var inventoryTransaction = new InventoryTransaction
                            {
                                ID = Guid.NewGuid(),
                                BinLotID = db.BinLots.Where(b => b.LotNumber == lot.Number).FirstOrDefault().ID,
                                TransactionType = TransactionType.Issue,
                                Quantity = lot.Quantity,
                                Date = DateTime.Now,
                                Username = User.Identity.Name
                            };

                            db.InventoryTransactions.Add(inventoryTransaction);
                            await db.SaveChangesAsync();

                        }


                        inventory.QuantityAvailable -= vmIssue.Quantity;
                        db.Entry(inventory).State = EntityState.Modified;
                        await db.SaveChangesAsync();

                        transaction.Commit();

                        return RedirectToAction("Index", "Lots", new { Area = "Management" });
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        ModelState.AddModelError("Error", ex.Message);
                    }
                }
            }

            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", vmIssue.ProductSku);
            return View(vmIssue);
        }


        public ActionResult Transfer()
        {
            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name");
            ViewBag.BinNumber = new SelectList(db.Bins, "Number", "Number");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Transfer(vmReceive vmReceive)
        {
            if (ModelState.IsValid)
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var lot = new Lot
                        {
                            Number = vmReceive.LotNumber,
                            ProductSku = vmReceive.ProductSku,
                            Quantity = vmReceive.Quantity,
                            ReceivedAt = DateTime.Now,
                            ExpirationDate = vmReceive.ExpirationDate
                        };

                        db.Lots.Add(lot);
                        await db.SaveChangesAsync();

                        var binLot = new BinLot
                        {
                            ID = Guid.NewGuid(),
                            LotNumber = lot.Number,
                            BinNumber = vmReceive.BinNumber
                        };

                        db.BinLots.Add(binLot);
                        await db.SaveChangesAsync();

                        var inventory = db.Inventories.Where(i => i.ProductSku == vmReceive.ProductSku).FirstOrDefault();
                        if (inventory == null)
                        {
                            throw new Exception("Inventory not found");
                        }

                        inventory.QuantityAvailable += vmReceive.Quantity;
                        db.Entry(inventory).State = EntityState.Modified;
                        await db.SaveChangesAsync();


                        var inventoryTransaction = new InventoryTransaction
                        {
                            ID = Guid.NewGuid(),
                            BinLotID = binLot.ID,
                            TransactionType = TransactionType.Receive,
                            Quantity = vmReceive.Quantity,
                            Date = DateTime.Now.Date,
                            Username = User.Identity.Name
                        };

                        db.InventoryTransactions.Add(inventoryTransaction);
                        await db.SaveChangesAsync();


                        transaction.Commit();

                        return RedirectToAction("Index", "Lots", new { Area = "Management" });
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        ModelState.AddModelError("Error", ex.Message);
                    }
                }
            }

            ViewBag.ProductSku = new SelectList(db.Products, "Sku", "Name", vmReceive.ProductSku);
            ViewBag.BinNumber = new SelectList(db.Bins, "Number", "Number", vmReceive.BinNumber);
            return View(vmReceive);
        }
    }
}
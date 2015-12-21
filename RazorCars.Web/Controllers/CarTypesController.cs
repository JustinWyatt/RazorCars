using RazorCars.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorCars.Web.Controllers
{
    public class InventoriesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: CarTypes
        public ActionResult List()
        {
            return PartialView(db.CarTypes.ToList());
        }

        public ActionResult RentalHistory(int inventoryId)
        {
            //Displays rental history for each inventory
            var inventory = db.Inventories.Find(inventoryId);

            var model = new InventoryVM
            {
                TotalStock = inventory.Stock,
                AvailableStock = inventory.Stock - inventory.Histories.Count(x => x.ReturnDate == null),

                Histories = inventory.Histories.Select(x => new RentalHistoryVM
                {
                    RentalDate = x.RentDate,
                    ReturnDate = x.ReturnDate
                }).ToList()

            };
            return View(model);
        }

        public ActionResult InventoryStore(int inventoryId)
        {

            return View();
        }
    }
}
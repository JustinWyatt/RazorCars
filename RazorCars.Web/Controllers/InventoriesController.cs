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
        
        [HttpGet]    
        public ActionResult Inventory(int locationId)
        {
            var model = db.Inventories.Where(x => x.Location.Id == locationId).Select(i => new StoreInventoryVM { Avaiable = i.Stock - i.Histories.Count(x => x.ReturnDate == null),
                                                                                                                  InventoryId = i.Id,
                                                                                                                  Make = i.CarType.Make,
                                                                                                                  Model = i.CarType.Model,
                                                                                                                  Year = i.CarType.Year }).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult ListCarTypes()
        {
            return View(db.CarTypes.ToList());
        }

        [HttpGet]
        public ActionResult CreateCar()
        {
            return View(db.CarTypes.ToList());
        }

        [HttpPost]
        public ActionResult CreateCar(CarType car)
        {
            var newCar = new CarType()
            {
                Make = car.Make,
                Model = car.Model,
                Year = car.Year
                
            };

            db.CarTypes.Add(newCar);
            db.SaveChanges();
            return RedirectToAction("ListCarTypes", "Inventories");
        }

        [HttpPost]
        public ActionResult RentCar(int inventoryId)
        {
            var inventory = db.Inventories.Find(inventoryId);
            var newRental = new RentalHistory()
            {
                RentDate = DateTime.Now
                
            };
            inventory.Histories.Add(newRental);
            
            db.SaveChanges();

            return RedirectToAction("RentalHistory", "Inventories");
        }

        [HttpPost]
        public ActionResult ReturnCar(int rentalId)
        {
            var history = db.RentalHistories.Find(rentalId);

            history.ReturnDate = DateTime.Now;
            db.SaveChanges();

            return RedirectToAction("RentalHistory", "Inventories");
        }
    }
}
using RazorCars.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorCars.Web.Controllers
{
    public class CarTypesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: CarTypes
        public ActionResult List()
        {
            return PartialView(db.CarTypes.ToList());
        }

        public ActionResult RentalHistory(int carTypeId)
        {
            //Displays rental history for each car type

            var currentCarRentalHistory = db.RentalHistories.Where(x => x.Inventory.CarType.Id == carTypeId);

            var carStock = currentCarRentalHistory.Select(x => x.Inventory.Stock).Count();
            var nullDates = currentCarRentalHistory.Select(x => x.ReturnDate == null).Count();
            var availableCars = carStock - nullDates;

            var rentalHistory = currentCarRentalHistory.Select(x => new RentalHistoryVM { Model = x.Inventory.CarType.Model,
                                                                             Make = x.Inventory.CarType.Make,
                                                                             Year = x.Inventory.CarType.Year,
                                                                             LocationName = x.Inventory.Location.Name,
                                                                             RentalDate = x.RentDate,
                                                                             ReturnDate = (DateTime)x.ReturnDate,
                                                                             TotalSupply = x.Inventory.Stock,
                                                                             AvailableForRent = availableCars});
            

            return View(rentalHistory);
        }

        public ActionResult InventoryStore()
        {   
            return View();
        }
    }   
}
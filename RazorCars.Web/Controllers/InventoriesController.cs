using Microsoft.AspNet.Identity;
using RazorCars.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorCars.Web.Controllers
{
    [Authorize]
    public class InventoriesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        string CurrentUserId;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (User.Identity.IsAuthenticated)
                CurrentUserId = User.Identity.GetUserId();

            base.OnActionExecuting(filterContext);
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = db.Users.Find(CurrentUserId).Location.Inventories
                        .Select(i => new StoreInventoryVM
                        {
                            Avaiable = i.Stock - i.Histories.Count(x => x.ReturnDate == null),
                            InventoryId = i.Id,
                            Make = i.CarType.Make,
                            Model = i.CarType.Model,
                            Year = i.CarType.Year
                        }).ToList();

            return View(model);
        }


        public ActionResult RentalHistory(int id)
        {
            //Displays rental history for each inventory
            var inventory = db.Inventories.Find(id);

            var model = new InventoryVM
            {
                Photo = inventory.CarType.Photo,
                Description = inventory.CarType.Description,
                Id = inventory.Id,
                Make = inventory.CarType.Make,
                Model = inventory.CarType.Model,
                Year = inventory.CarType.Year,
                TotalStock = inventory.Stock,
                AvailableStock = inventory.Stock - inventory.Histories.Count(x => x.ReturnDate == null),
                Histories = inventory.Histories.Select(x => new RentalHistoryVM
                {
                    Id = x.Id,
                    RentalDate = x.RentDate,
                    ReturnDate = x.ReturnDate
                }).ToList()

            };


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
            return View();
        }

        [HttpPost]
        public ActionResult CreateCar(CarType car)
        {

            db.CarTypes.Add(car);
            db.SaveChanges();
            return RedirectToAction("ListCarTypes");
        }

        [HttpGet]
        public ActionResult RentCar(int inventoryId)
        {
            var inventory = db.Inventories.Find(inventoryId);
            var newRental = new RentalHistory()
            {
                RentDate = DateTime.Now,
                Inventory = inventory

            };
            inventory.Histories.Add(newRental);

            db.SaveChanges();

            return RedirectToAction("RentalHistory", new { id= inventoryId});
        }

        [HttpGet]
        public ActionResult ReturnCar(int rentalId)
        {
            var history = db.RentalHistories.Find(rentalId);
            if (history.ReturnDate == null)
            {
                history.ReturnDate = DateTime.Now;
            }
            
            db.SaveChanges();

            return RedirectToAction("RentalHistory", new { id = history.Inventory.Id } );
        }

        public ActionResult UploadImage()
        {
            return PartialView();
        }

        public ActionResult UploadImage(Image img, HttpPostedFileBase file, int carTypeId)
        {
            var car = db.CarTypes.Find(carTypeId);
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Images/")
                                                          + file.FileName);
                    img.ImagePath = file.FileName;
                }
                car.Images.Add(img);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(img);
        }

        public ActionResult ViewImages (int carTypeId)
        {
            return PartialView();
        }
    }
}
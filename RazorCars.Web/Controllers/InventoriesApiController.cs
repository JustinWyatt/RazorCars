using Microsoft.AspNet.Identity;
using RazorCars.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace RazorCars.Web.Controllers
{
    public class InventoriesApiController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("api/inventoriesapi/index")]
        public IHttpActionResult Index()
        {
            string CurrentUserId = "f1c98424-9930-46c1-82f8-be3c3ca4454a";

            var model = db.Users.Find(CurrentUserId).Location.Inventories
                    .Select(i => new StoreInventoryVM
                    {
                        Available = i.Stock - i.Histories.Count(x => x.ReturnDate == null),
                        InventoryId = i.Id,
                        Make = i.CarType.Make,
                        Model = i.CarType.Model,
                        Year = i.CarType.Year
                    }).ToList();

            return Json(model);
        }
        
        [HttpGet]
        [Route("api/inventoriesapi/rentals")]
        public IHttpActionResult RentalHistory(int id)
        {
            //Displays rental history for each inventory
            var inventory = db.Inventories.Find(id);

            var model = new InventoryVM
            {
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

            return Json(model);
        }

        [HttpGet]
        [Route("api/inventoriesapi/users")]
        public IHttpActionResult Users()
        {
            return Json(db.Users.ToList());
        }

        [HttpGet]
        [Route("api/inventoriesapi/user/id")]
        public IHttpActionResult Users(int id)
        {
            var user = db.Users.Find(id);
            return Json(user);
        }
    }
}

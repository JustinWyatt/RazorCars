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
                        Avaiable = i.Stock - i.Histories.Count(x => x.ReturnDate == null),
                        InventoryId = i.Id,
                        Make = i.CarType.Make,
                        Model = i.CarType.Model,
                        Year = i.CarType.Year
                    }).ToList();

            return Json(model);
        }
        
    }
}

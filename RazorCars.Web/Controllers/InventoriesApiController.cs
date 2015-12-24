using Microsoft.AspNet.Identity;
using RazorCars.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RazorCars.Web.Controllers
{
    public class InventoriesApiController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        string CurrentUserId;

        //[Authorize(Roles = "Admin")]
        [Route("api/inventoriesapi/index")]
        public IHttpActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                CurrentUserId = User.Identity.GetUserId();

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

using Host_Car.DataAccess;
using Host_Car.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Host_Car.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CarController(ApplicationDbContext db)
        {
            _db = db;
        }



        public IActionResult OficeAdress()
        {
            return View();
        }


        #region CarFilterPartial
        public IActionResult _CarFilterPartial()
        {
            return View();
        }
        public IActionResult AllCars()
        {
            var carDetails = _db.CarDetails.ToList();
            return View(carDetails);
        }
        public IActionResult SuperCarShow()
        {
            var superCar = _db.CarDetails.Where(i => i.CarClassId == 2).ToList();
            return View(superCar.ToList());
        }
        public IActionResult PoorCarShow()
        {
            var poorCar = _db.CarDetails.Where(i => i.CarClassId == 3).ToList();
            return View(poorCar);
        }
        public IActionResult MuscleCarShow()
        {
            var muscleCar = _db.CarDetails.Where(i => i.CarClassId == 1).ToList();
            return View(muscleCar);
        }
        #endregion
    }

}

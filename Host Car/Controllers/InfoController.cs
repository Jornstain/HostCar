using Host_Car.DataAccess;
using Host_Car.Models;
using Host_Car.Models.DTos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Host_Car.Controllers
{
    public class InfoController : Controller
    {
        private readonly ApplicationDbContext _db;
        public InfoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var oficeTime = _db.OficeTimes.FirstOrDefault();
            var adress = _db.Adresses.Where(i => i.Id != 0).ToList();

            ViewBag.Time = oficeTime.OficeWorkHours.ToString();
            ViewBag.OficeDay = oficeTime.OficeWorkDays.ToString();
            ViewBag.Adresses = new SelectList(adress, "Id", "OficeAdress");
            return View();
        }

        public IActionResult OrderComplete()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ContactUs()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactUs(FeedbackDTO feedback)
        {
            var f = new Feedback()
            {
                Name = feedback.Name,
                Subject = feedback.Subject,
                Email = feedback.Email,
                Message = feedback.Message,
            };

            await  _db.Feedbacks.AddAsync(f);
            await _db.SaveChangesAsync();


            return RedirectToAction("PreOrderSearch", "Rent");

            //else 
            //{
            //    return;
            //}
        }


        //[HttpPost]
        //public IActionResult OrderComplete(string userId)
        //{
        //    userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    //var orderDetail = _db.OrderDetails;
        //    return View();
        //}
    }
}

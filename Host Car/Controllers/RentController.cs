using Host_Car.DataAccess;
using Host_Car.DataAccess.Repository.IRepository;
using Host_Car.Models;
using Host_Car.Models.AdressModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Stripe;
using Stripe.Checkout;
using System.Security.Claims;

namespace Host_Car.Controllers
{
    public class RentController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<RentController> _logger;
        private readonly IPreOrderSearchRepository _pOS;
        public RentController(ApplicationDbContext db, IPreOrderSearchRepository pOS)
        {
            _db = db;
            _pOS = pOS;
            StripeConfiguration.ApiKey = "sk_test_51M55NXHq6eKLkxPUclRKq1IZ9bxuMA304NXrxR4OzBwV6U8BHiL8xHHcO5CY4Lu1zrh4w1xYkW5qYeFYBA5yiLPj006FUizDBo";
        }

        #region Add Date Detail and move on to choose car
        public IActionResult PreOrderSearch()
        {
            var orderSearchs = _db.PreOrderSearchs.Include(i => i.Adresses);
            foreach (var item in orderSearchs)
            {
                var address = item.Adresses;
            }
            var result = orderSearchs.ToList();

            var adress = _db.Adresses.Where(i => i.Id != 0).ToList();
            ViewBag.Adresses = new SelectList(adress, "Id", "OficeAdress");

            return View();
        }

        [HttpPost]
        public IActionResult PreOrderSearch(int ConfirmAdressId, int GiveBackAdressId, DateTime OrderStartDate, DateTime OrderEndDate)
        {
            var adress = _db.PreOrderSearchs.Include(i => i.Adresses).ToList();
            var some = _db.Adresses.Where(o => o.Id != 0);

            var entity = new PreOrderSearch()
            {
                ConfirmAdressId = ConfirmAdressId,
                GiveBackAdressId = GiveBackAdressId,
                SpecialOrderDetailId = Guid.NewGuid(),
                OrderStartDate = OrderStartDate,
                OrderEndDate = OrderEndDate,
                OrderSearchStatus = "active"
            };
            _db.PreOrderSearchs.Add(entity);
            _db.SaveChanges();

            return RedirectToAction("Order");
        }

        public JsonResult GetAdress()
        {
            var adress = _db.Adresses.OrderBy(x => x.OficeAdress).ToList();
            return new JsonResult(adress);
        }

        #endregion


        #region Choose Car and Complete OrderDetails  
        public IActionResult Order()
        {
            var carSelect = _db.Orders.Where(o => o.CarDetails.Id != 0);
            var car = _db.CarDetails.ToList();
            var result = carSelect.ToList();

            ViewBag.OrderTime = DateTime.Now.ToString();

            return View(car);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Order(int carId, int AdressId)
        {
            //ViewBag.Car = _db.CarDetail.ToList();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                userId = Guid.NewGuid().ToString();
            }
            var orderSearchId = _db.PreOrderSearchs.FirstOrDefault(i => i.SpecialOrderDetailId != null && i.OrderSearchStatus == "active");
            var carDetails = _db.CarDetails.ToList().FirstOrDefault(); 
            var orderCheck = _db.Orders.FirstOrDefault(i => i.IdentityUserId == userId);

            if(carDetails.CarQuantity <= 0)
            {
               
            }
            else
            {
                if (orderCheck == null)
                {
                    var entity = new Order()
                    {
                        CarDetailsId = carId,
                        OrderStatus = "check",
                        UserId = userId,
                        OrderTime = DateTime.Now,
                        PreOrderSearchId = orderSearchId.Id,
                        IdentityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                    };
                    //_db.PreOrderSearchs.Update(order);
                    _db.Orders.Add(entity);
                }
                orderCheck.CarDetails.CarQuantity -= 1;
            }
          
           
            _db.SaveChanges();

            return RedirectToAction("Checkout");
        }
        #endregion

        #region Show Order Details
        public IActionResult OrderDetailShow()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orderId = _db.Orders.FirstOrDefault(i => i.IdentityUserId == userId);
            var orderDetail = new OrderDetail()
            {
                OrderId = orderId.Id
            };

            return View(orderDetail);
        }
        [HttpPost]
        public IActionResult OrderDetailShow(int id)
        {

            return RedirectToAction("Payment");
        }
        #endregion

        #region Payment

        public async Task<IActionResult> Checkout()
        
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orderShow = _db.Orders.FirstOrDefault(i => i.IdentityUserId == userId);


            //var checkOutDetails = _db.CarDetails.FirstOrDefault(i => i.Id = orderDetail);
            return View(orderShow);
        }


        [HttpPost("create-checkout-session")]
        public IActionResult CreateCheckoutSession()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var dbPriceModel = _db.CarPrices.FirstOrDefault(i => i.Id != 0);
            //var price = _db.CarDetails.Where(i => i.CarPriceId == dbPriceModel.Id);
            var order = _db.Orders.FirstOrDefault(i => i.IdentityUserId == userId);
            var onlinePrice = order.CarDetails.CarPrices.OnlinePrice;
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
        {
          new SessionLineItemOptions
          {
            PriceData = new SessionLineItemPriceDataOptions
            {
                UnitAmountDecimal = onlinePrice * 100,
              Currency = "eur",
              ProductData = new SessionLineItemPriceDataProductDataOptions
              {
                Name = "Rent Price",
              },
            },
            Quantity = 1,
          },
        },
                Mode = "payment",
                SuccessUrl = "https://localhost:44323/Info/OrderComplete",
                CancelUrl = "https://localhost:44323/",
            };
            var service = new SessionService();
            Session session = service.Create(options);
            Response.Headers.Add("Location", session.Url);

            var entity = new OrderDetail()
            {
                OrderId = order.Id,
                PaymentStatus = "processing"
            };

            _db.OrderDetails.Add(entity);
            _db.SaveChanges();

            return new StatusCodeResult(303);
        }
    }
    #endregion
}


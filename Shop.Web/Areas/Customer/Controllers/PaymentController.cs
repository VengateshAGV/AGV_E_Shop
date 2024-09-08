using Microsoft.AspNetCore.Mvc;
using Shop.ModelArea.Models;
using Stripe.Checkout;

namespace Shop.Web.Areas.Customer.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCheckOut()
        {
            var domain = "https://localhost:7091";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>(),
                
                Mode = "payment",
                SuccessUrl = domain + "/Customer/Payment/Success",
                CancelUrl = domain + "/Customer/Cencel/Success",
            };


            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);

            return new StatusCodeResult(303);
        }

        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Cencel()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SubscriptionTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionTracker.Controllers
{
    public class RegisterCustomerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerRespository _customerRespository;

        public RegisterCustomerController(ILogger<HomeController> logger, ICustomerRespository customerRespository)
        {
            _logger = logger;
            _customerRespository = customerRespository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Renew(int customerId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerSubscription customerSubscription)
        {
            var addedCustomer = _customerRespository.AddCustomer(customerSubscription);
            // return View("Views/RegisterCustomer/CustomerDetail.cshtml", addedCustomer);
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
    }
}
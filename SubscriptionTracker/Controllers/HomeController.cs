using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SubscriptionTracker.Models;
using SubscriptionTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerRespository _customerRespository;

        public HomeController(ILogger<HomeController> logger, ICustomerRespository customerRespository)
        {
            _logger = logger;
            _customerRespository = customerRespository;
        }

        public IActionResult Index()
        {
            var customerSubscriptionExpired = _customerRespository.GetPaymentPendingCustomers().ToList();
            var customerSubscriptionExpiring = _customerRespository.GetUpcomingPaymentCustomer().ToList();
            var customerViewModel = new CustomerSubscriptionViewModel { CustomerSubscriptionExpired = customerSubscriptionExpired, CustomerSubscriptionExpiring = customerSubscriptionExpiring };
            //customerWithSubscription.Customer = customers;
            return View(customerViewModel);
        }

        public IActionResult GetAllCustomers()
        {
            var customer = _customerRespository.GetAllCustomersWithSubscription();
            return View("Customers", customer);
        }

        public IActionResult Renew(int customerId)
        {
            if (_customerRespository.Renew(customerId))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            return View("Views/Shared/Error.cshtml");
        }

        public IActionResult UpdatePlan(int customerId)
        {
            var customerSubscription = _customerRespository.GetCustomerWithSubscription(customerId);
            return View("RenewWithChanges", customerSubscription);
        }

        [HttpPost]
        public IActionResult RenewWithChanges(CustomerSubscription customerSubscription)
        {
            _customerRespository.RenewWithChanges(customerSubscription);
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
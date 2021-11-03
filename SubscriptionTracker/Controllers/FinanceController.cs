using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SubscriptionTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionTracker.Controllers
{
    public class FinanceController : Controller
    {
        private readonly IExpenseRepository _expenseRepository;

        public FinanceController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddExpense()
        {
            return View();
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetReport([FromQuery] string reportName, [FromQuery] string fromDate, [FromQuery] string toDate)
        {
            if (reportName == "2")
            {
                var data = _expenseRepository.GetFeesReport(Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate)).ToList();
                return Json(JsonConvert.SerializeObject(data));
            }
            else if (reportName == "1")
            {
                var data = _expenseRepository.GetExpenseReport(Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate)).ToList();
                return Json(JsonConvert.SerializeObject(data));
            }
            else
            {
                var data = _expenseRepository.GetCustomerJoiningReport(Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate)).ToList();
                return Json(JsonConvert.SerializeObject(data));
            }
        }
    }
}
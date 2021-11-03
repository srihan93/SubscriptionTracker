using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SubscriptionTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionTracker.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IExpenseRepository _expenseRepository;

        public ReportsController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public IActionResult Expense()
        {
            return View();
        }

        public IActionResult Customer()
        {
            return View();
        }

        public IActionResult Fees()
        {
            return View();
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetCustomerJoiningReport([FromQuery] string fromDate, [FromQuery] string toDate)
        {
            var data = _expenseRepository.GetCustomerJoiningReport(Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate)).ToList();
            return Json(JsonConvert.SerializeObject(data));
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetFeesReport([FromQuery] string fromDate, [FromQuery] string toDate)
        {
            var data = _expenseRepository.GetFeesReport(Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate)).ToList();
            return Json(JsonConvert.SerializeObject(data));
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetExpenseReport([FromQuery] string fromDate, [FromQuery] string toDate)
        {
            var data = _expenseRepository.GetExpenseReport(Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate)).ToList();
            return Json(JsonConvert.SerializeObject(data));
        }
    }
}
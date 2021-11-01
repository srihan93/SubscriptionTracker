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

        [HttpPost]
        public IActionResult GetExpenseReport()
        {
            List<Expense> expense = _expenseRepository.GetAllExpense().ToList();
            return Json(JsonConvert.SerializeObject(expense));
        }
    }
}
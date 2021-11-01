using Microsoft.AspNetCore.Mvc;
using SubscriptionTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionTracker.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddExpense(Expense expense)
        {
            if (_expenseRepository.AddExpense(expense))
            {
                return View("Index");
            }
            else
            {
                return View("/Views/Shared/Error.cshtml");
            }
        }
    }
}
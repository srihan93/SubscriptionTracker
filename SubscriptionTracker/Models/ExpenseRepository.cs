using System;
using System.Collections.Generic;

namespace SubscriptionTracker.Models
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _appDbContext;

        public ExpenseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool AddExpense(Expense expense)
        {
            try
            {
                expense.SpentOn = DateTime.Now;
                _appDbContext.Expenses.Add(expense);
                _appDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<Expense> GetAllExpense()
        {
            return _appDbContext.Expenses;
        }
    }
}
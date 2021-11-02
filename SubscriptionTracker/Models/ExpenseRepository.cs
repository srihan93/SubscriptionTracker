using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Expense> GetExpenseReport(DateTime fromDate, DateTime toDate)
        {
            return _appDbContext.Expenses.Where(x => x.SpentOn >= fromDate && x.SpentOn <= toDate.AddDays(1));
        }

        public IEnumerable<Transaction> GetFeesReport(DateTime fromDate, DateTime toDate)
        {
            return _appDbContext.Transactions.Where(x => x.TransactedOn >= fromDate && x.TransactedOn <= toDate.AddDays(1));
        }

        public IEnumerable<Customer> GetCustomerJoiningReport(DateTime fromDate, DateTime toDate)
        {
            return _appDbContext.Customers.Where(x => x.JoiningDate >= fromDate && x.JoiningDate <= toDate.AddDays(1));
        }

        public IEnumerable<Expense> GetAllExpense()
        {
            throw new NotImplementedException();
        }
    }
}
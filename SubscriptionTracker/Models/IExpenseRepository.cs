using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionTracker.Models
{
    public interface IExpenseRepository
    {
        public bool AddExpense(Expense expense);

        public IEnumerable<Expense> GetAllExpense();

        public IEnumerable<Expense> GetExpenseReport(DateTime fromDate, DateTime toDate);

        public IEnumerable<Transaction> GetFeesReport(DateTime fromDate, DateTime toDate);

        public IEnumerable<Customer> GetCustomerJoiningReport(DateTime fromDate, DateTime toDate);
    }
}
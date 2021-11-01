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
    }
}
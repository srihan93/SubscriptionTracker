using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace SubscriptionTracker.Models
{
    public class Expense
    {
        [BindNever]
        public int ExpenseId { get; set; }

        public ExpenseType ExpenseType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime SpentOn { get; set; }

        public string SpentBy { get; set; }
    }

    public enum ExpenseType
    {
        Rent, EB, Maintainence, Food, Payout, Others
    }
}
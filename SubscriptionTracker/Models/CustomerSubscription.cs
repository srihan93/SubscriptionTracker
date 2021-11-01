using System;

namespace SubscriptionTracker.Models
{
    public class CustomerSubscription
    {
        public int CustomerSubscriptionId { get; set; }
        public DateTime PaidOn { get; set; }
        public DateTime Expiry { get; set; }
        public bool IsActive { get; set; }
        public int PlanId { get; set; }
        public Plan Plan { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
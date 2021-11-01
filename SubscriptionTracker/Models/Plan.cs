namespace SubscriptionTracker.Models
{
    public class Plan
    {
        public int PlanId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int DurationMonths { get; set; }
    }
}
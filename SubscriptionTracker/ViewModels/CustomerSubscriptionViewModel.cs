using SubscriptionTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionTracker.ViewModels
{
    public class CustomerSubscriptionViewModel
    {
        public List<CustomerSubscription> CustomerSubscriptionExpiring { get; set; }
        public List<CustomerSubscription> CustomerSubscriptionExpired { get; set; }
    }
}
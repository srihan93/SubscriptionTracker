using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionTracker.Models
{
    public class Report
    {
        public string reportName { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
    }
}
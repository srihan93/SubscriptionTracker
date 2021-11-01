using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionTracker.Models
{
    public interface ICustomerRespository
    {
        public IEnumerable<Customer> GetAllCustomers();

        public IEnumerable<CustomerSubscription> GetPaymentPendingCustomers();

        public IEnumerable<CustomerSubscription> GetUpcomingPaymentCustomer();

        public CustomerSubscription GetCustomerWithSubscription(int customerId);

        public Customer AddCustomer(CustomerSubscription customer);

        public bool Renew(int customerId);

        public bool RenewWithChanges(CustomerSubscription customerSubscription);

        public IEnumerable<CustomerSubscription> GetAllCustomersWithSubscription();
    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionTracker.Models
{
    public class CustomerRepository : ICustomerRespository
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _appDbContext.Customers.ToList();
        }

        public CustomerSubscription GetCustomerWithSubscription(int customerId)
        {
            var customerSub = _appDbContext.CustomerSubscriptions.Include(x => x.Customer).Include(y => y.Plan).Where(x => x.CustomerId == customerId).FirstOrDefault();
            if (customerSub == null)
            {
                var customer = _appDbContext.Customers.Where(x => x.CustomerId == customerId).FirstOrDefault();
                customerSub.Customer = customer;
            }
            return customerSub;
        }

        public CustomerSubscription GetAllCustomerWithSubscription(int customerId)
        {
            return _appDbContext.CustomerSubscriptions.Include(x => x.Customer).Include(y => y.Plan).Where(x => x.CustomerId == customerId).FirstOrDefault();
        }

        public IEnumerable<CustomerSubscription> GetPaymentPendingCustomers()
        {
            var paymentExpiredCustomers = _appDbContext.CustomerSubscriptions.Include(x => x.Customer).Include(y => y.Plan).Where(p => p.Expiry.AddHours(23).AddMinutes(59) <= DateTime.Now);
            return paymentExpiredCustomers;
        }

        public IEnumerable<CustomerSubscription> GetUpcomingPaymentCustomer()
        {
            var paymentExpiredCustomers = _appDbContext.CustomerSubscriptions.Include(x => x.Customer).Include(y => y.Plan).Where(p => p.Expiry.AddHours(23).AddMinutes(59) > DateTime.Now
            && p.Expiry.AddHours(23).AddMinutes(59) < DateTime.Now.AddDays(3));
            return paymentExpiredCustomers;
        }

        public bool RenewWithChanges(CustomerSubscription customerSubscription)
        {
            var contextTransaction = _appDbContext.Database.BeginTransaction();
            try
            {
                var cs = _appDbContext.CustomerSubscriptions.Where(c => c.CustomerSubscriptionId == customerSubscription.CustomerSubscriptionId).FirstOrDefault();
                var transaction = new Transaction();
                transaction.Amount = customerSubscription.Plan.Cost;
                transaction.Description = "Subscription Fees";
                transaction.TransactedOn = DateTime.Now;
                if (customerSubscription.Customer == null)
                {
                    transaction.CustomerId = customerSubscription.CustomerId;
                }
                else
                {
                    transaction.CustomerId = customerSubscription.Customer.CustomerId;
                }

                _appDbContext.Transactions.Add(transaction);
                _appDbContext.SaveChanges();

                var plan = _appDbContext.Plans.Where(p => p.PlanId == customerSubscription.PlanId).FirstOrDefault();

                if (cs == null)
                {
                    cs = customerSubscription;
                }
                cs.PlanId = customerSubscription.PlanId;
                cs.PaidOn = DateTime.Now;
                cs.Expiry = Convert.ToDateTime(DateTime.Now.AddMonths(plan.DurationMonths).ToShortDateString());
                cs.IsActive = true;
                if (cs.CustomerId != 0)
                {
                    _appDbContext.CustomerSubscriptions.Update(cs);
                    _appDbContext.SaveChanges();
                    contextTransaction.Commit();
                    return true;
                }
                else
                {
                    cs.Plan = plan;
                    cs.Plan.Cost = customerSubscription.Plan.Cost;
                    _appDbContext.CustomerSubscriptions.Add(customerSubscription);
                    _appDbContext.SaveChanges();

                    contextTransaction.Commit();
                    return true;
                }
            }
            catch (Exception e)
            {
                contextTransaction.Rollback();
                return false;
            }
        }

        public bool Renew(int customerId)
        {
            var contextTransaction = _appDbContext.Database.BeginTransaction();
            try
            {
                var customer = _appDbContext.Customers.Where(c => c.CustomerId == customerId).FirstOrDefault();
                if (customer != null)
                {
                    var customerSubscription = _appDbContext.CustomerSubscriptions.Where(c => c.CustomerId == customerId).FirstOrDefault();
                    if (customerSubscription != null)
                    {
                        var plan = _appDbContext.Plans.Where(p => p.PlanId == customerSubscription.PlanId).FirstOrDefault();
                        customerSubscription.PaidOn = DateTime.Today;
                        customerSubscription.Expiry = Convert.ToDateTime(DateTime.Today.AddMonths(plan.DurationMonths).ToShortDateString());
                        _appDbContext.Update(customerSubscription);
                        _appDbContext.SaveChanges();
                        var transaction = new Transaction();
                        transaction.Amount = plan.Cost;
                        transaction.Description = "Subscription Fees";
                        transaction.TransactedOn = DateTime.Now;
                        transaction.CustomerId = customerId;
                        _appDbContext.Transactions.Add(transaction);
                        _appDbContext.SaveChanges();
                        contextTransaction.Commit();
                        return true;
                    }
                    else
                    {
                        contextTransaction.Rollback();
                        return false;
                    }
                }
                contextTransaction.Rollback();
                return false;
            }
            catch (Exception)
            {
                contextTransaction.Rollback();
                return false;
            }
        }

        public Customer AddCustomer(CustomerSubscription customer)
        {
            var contextTransaction = _appDbContext.Database.BeginTransaction();
            try
            {
                customer.IsActive = true;
                customer.Customer.JoiningDate = DateTime.Today;
                _appDbContext.Customers.Add(customer.Customer);
                _appDbContext.SaveChanges();
                var transaction = new Transaction();
                transaction.Amount = 200;
                transaction.Description = "Registration Fees";
                transaction.TransactedOn = DateTime.Now;
                transaction.CustomerId = customer.Customer.CustomerId;
                _appDbContext.Transactions.Add(transaction);
                _appDbContext.SaveChanges();
                contextTransaction.Commit();

                if (RenewWithChanges(customer))
                {
                    return _appDbContext.Customers.Where(x => x.MobileNumber == customer.Customer.MobileNumber).FirstOrDefault();
                }
                else
                {
                    contextTransaction.Rollback();
                    return null;
                }
            }
            catch (Exception e)
            {
                contextTransaction.Rollback();
                return null;
            }
        }

        public IEnumerable<CustomerSubscription> GetAllCustomersWithSubscription()
        {
            return _appDbContext.CustomerSubscriptions.Include(x => x.Customer).Include(y => y.Plan);
        }
    }
}
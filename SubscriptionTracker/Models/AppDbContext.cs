using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionTracker.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerSubscription> CustomerSubscriptions { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PaymentMode> PaymentModes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<TransactionType> TransactionTypes { get; set; }
        //public DbSet<CustomerWallet> CustomerWallets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Plan>().HasData(new Plan { PlanId = 1, Name = "Monthly", Cost = 1500, DurationMonths = 1 });
            modelBuilder.Entity<Plan>().HasData(new Plan { PlanId = 2, Name = "Quartely", Cost = 3000, DurationMonths = 3 });
            modelBuilder.Entity<Plan>().HasData(new Plan { PlanId = 3, Name = "Half-Yearly", Cost = 4500, DurationMonths = 6 });
            modelBuilder.Entity<Plan>().HasData(new Plan { PlanId = 4, Name = "Annualy", Cost = 7500, DurationMonths = 12 });

            modelBuilder.Entity<PaymentMode>().HasData(new PaymentMode { PaymentModeId = 1, PaymentModeName = "GPay", IsActive = true });
            modelBuilder.Entity<PaymentMode>().HasData(new PaymentMode { PaymentModeId = 2, PaymentModeName = "Cash", IsActive = true });
            modelBuilder.Entity<PaymentMode>().HasData(new PaymentMode { PaymentModeId = 3, PaymentModeName = "PhonePe", IsActive = true });
        }
    }
}
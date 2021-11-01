using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace SubscriptionTracker.Models
{
    public class Customer
    {
        [BindNever]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter FullName")]
        [Display(Name = "Full Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Mobile Number")]
        [Display(Name = "Mobile Number")]
        [MinLength(10)]
        [MaxLength(10)]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        [Display(Name = "Address")]
        [StringLength(300)]
        public string Address { get; set; }

        [BindNever]
        public bool IsActive { get; set; }
    }

    public class CustomerWallet
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal Amount { get; set; }
        public bool IsActive { get; set; }
    }
}
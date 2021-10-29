using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst_Example.Model
{
    public class Customer
    {
        public Customer()
        {

        }

        public Customer(int customerId, string companyName, string companyAddress, string companyPhoneNumber, string companyEmail, string companyTaxCode, string representiveName, string representiveEmail, string representivePhoneNumber)
        {
            CustomerId = customerId;
            CompanyName = companyName;
            CompanyAddress = companyAddress;
            CompanyPhoneNumber = companyPhoneNumber;
            CompanyEmail = companyEmail;
            CompanyTaxCode = companyTaxCode;
            RepresentiveName = representiveName;
            RepresentiveEmail = representiveEmail;
            RepresentivePhoneNumber = representivePhoneNumber;
        }

        public int CustomerId { get; set; }

        [Required]
        [MaxLength(225)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(225)]
        public string CompanyAddress { get; set; }

        [Required]
        [MaxLength(20)]
        public string CompanyPhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string CompanyEmail { get; set; }

        [Required]
        [MaxLength(20)]
        public string CompanyTaxCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string RepresentiveName { get; set; }

        [Required]
        [MaxLength(50)]
        public string RepresentiveEmail { get; set; }

        [Required]
        [MaxLength(20)]
        public string RepresentivePhoneNumber { get; set; }

        public virtual List<Contract> Contracts { get; set; }
    }
}

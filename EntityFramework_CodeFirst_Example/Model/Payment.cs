using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst_Example.Model
{
    public class Payment
    {
        public int PaymentId { get; set; }

        [Required]
        public int PaymentNumber { get; set; }

        [Required]
        [MaxLength(20)]
        public string PaymentCode { get; set; }

        [Required]
        public decimal PaymentAmount { get; set; }

        [Required]
        [MaxLength(225)]
        public string Representative { get; set; }

        [Required]
        [MaxLength(20)]
        public string InvoiceCode { get; set; }

        public virtual Contract Contract { get; set; }
    }
}

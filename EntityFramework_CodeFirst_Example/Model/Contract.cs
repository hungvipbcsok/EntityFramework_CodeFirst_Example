using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst_Example.Model
{
    public class Contract
    {
        public int ContractId { get; set; }

        [Required]
        [MaxLength(225)]
        public string ContractName { get; set; }

        [Required]
        public int ContractTypeId { get; set; }

        [Required]
        [MaxLength(20)]
        public string AttendName { get; set; }

        [Required]
        public DateTime ContractDate { get; set; }

        public DateTime ContractStart { get; set; }
        public DateTime ContractEnd { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

       /* public decimal TotalPaid
        {
            get
            {
                return this.Payments.Sum(p => p.PaymentAmount);               
            }
        }*/
        /*public decimal TotalRemaining
        {
            get
            {
                return this.TotalAmount - this.TotalPaid;
            }
        }*/
        public int TestColumn { get; set; }

        public virtual IList<Payment> Payments { get; set; }
        public virtual ContractType ContractType { get; set; }
        public virtual Customer Customer { get; set; }
    }
}

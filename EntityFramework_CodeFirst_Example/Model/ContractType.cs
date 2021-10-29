using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst_Example.Model
{
    public class ContractType
    {
        public int Id { get; set; }

        [Required]
        public string ContractTypeName { get; set; }

        [Required]
        public decimal MinValue { get; set; }

        [Required]
        public decimal MaxValue { get; set; }

        public List<Contract> Contracts { get; set; }
    }
}

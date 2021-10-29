using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst_Example.Model
{
    public class ManagePaymentContext : DbContext
    {
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }

        /*public ManagePaymentContext() : base("ManagerContextConnectionString")
        {
            Database.SetInitializer<ManagePaymentContext>(null);
        }*/
    }
}

using EntityFramework_CodeFirst_Example.Interface;
using EntityFramework_CodeFirst_Example.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract = EntityFramework_CodeFirst_Example.Model.Contract;

namespace EntityFramework_CodeFirst_Example.Service
{
    public class ContractService : IService
    {
        public ManagePaymentContext dataContext = new ManagePaymentContext();

        public List<Contract> GetActiveContract()
        {

            return dataContext.Contracts.Where(c => c.ContractEnd >= DateTime.Today).ToList();
        }

        /*public List<Contract> GetRemainingContract()
        {
            return dataContext.Contracts.Where(c => c.TotalRemaining > 0).ToList();
        }*/
    }
}

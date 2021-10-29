using EntityFramework_CodeFirst_Example.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst_Example.Interface
{
    public interface IService
    {
        List<Contract> GetActiveContract();
        /*List<Contract> GetRemainingContract();*/
    }
}

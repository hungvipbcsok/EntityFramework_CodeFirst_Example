using EntityFramework_CodeFirst_Example.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagePaymentContext context = new ManagePaymentContext();

            context.SaveChanges();
        }
    }
}

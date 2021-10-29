using EntityFramework_CodeFirst_Example.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst_Example.Service
{
    public class ContractTypeService : IDisposable
    {
        private readonly ManagePaymentContext dataContext = new ManagePaymentContext();
        private bool disposedValue;



        public List<ContractType> GetAll()
        {
            var result = dataContext.ContractTypes.ToList();
            return result;
        }



        public void Remove(int id)
        {
            var contractType = dataContext.ContractTypes.Find(id);
            if (contractType != null)
            {
                dataContext.ContractTypes.Remove(contractType);
                dataContext.SaveChanges();
            }
        }



        public ContractType GetById(int id)
        {
            return dataContext.ContractTypes.Find(id);
        }



        public void Create(ContractType contractType)
        {
            dataContext.ContractTypes.Add(contractType);
            dataContext.SaveChanges();
        }



        public void Update(ContractType contractType)
        {
            dataContext.Entry(contractType).State = EntityState.Modified;
            dataContext.SaveChanges();
        }



        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    dataContext.Dispose();
                }



                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }



        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ContactTypeService()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }



        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

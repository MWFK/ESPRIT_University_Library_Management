using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BibData.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBase<T> getRepository<T>() where T : class; 
        
        void Commit();
       
    }

}

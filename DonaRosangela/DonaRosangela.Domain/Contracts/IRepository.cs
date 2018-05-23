using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Domain.Contracts
{
    public interface IRepository<T>
    {
        T Add(T obj);
        T Update(T obj);
        T Get(long id);
        IList<T> GetAll();
        void Delete(long id);
    }
}

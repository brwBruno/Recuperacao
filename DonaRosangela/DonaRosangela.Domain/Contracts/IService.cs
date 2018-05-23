using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Domain.Contracts
{
    public interface IService<T>
    {
        T Add(T obj);
        T Update(T obj);
        T Get(T obj);
        IList<T> GetAll();
        void Delete(T obj);
    }
}

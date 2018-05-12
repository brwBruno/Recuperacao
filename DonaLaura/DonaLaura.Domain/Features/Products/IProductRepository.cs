using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Products
{
     public interface IProductRepository
    {
        Product Add(Product product);
        Product Update(Product product);
        void Delete(long id);
        Product Get(long id);
        IList<Product> GetAll();
    }
}

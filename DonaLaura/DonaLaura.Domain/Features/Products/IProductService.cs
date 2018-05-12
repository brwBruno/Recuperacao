using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Products
{
    public interface IProductService
    {
        Product Add(Product product);
        Product Update(Product product);
        Product Get(Product product);
        void Delete(Product product);
        IList<Product> GetAll();
    }
}

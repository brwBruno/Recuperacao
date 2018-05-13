using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.App.Features.Products
{
    public class ProductService : IProductService
    {
        IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            this._repository = repository;
        }

        public Product Add(Product product)
        {
            product.Validate();
            return _repository.Add(product);
        }

        public void Delete(Product product)
        {
            if (product.Id == 0)
            {
                throw new InvalidIdException();
            }
            _repository.Delete(product.Id);
        }

        public Product Get(Product product)
        {
            if (product.Id == 0)
            {
                throw new InvalidIdException();
            }
            return _repository.Get(product.Id);
        }

        public IList<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public Product Update(Product product)
        {
            product.Validate();
            return _repository.Update(product);
        }
    }
}

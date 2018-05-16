using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.App.Features.Sales
{
    public class SaleService : ISaleService
    {
        ISaleRepository _repository;

        public SaleService(ISaleRepository repository)
        {
            _repository = repository;
        }

        public Sale Add(Sale sale)
        {
            sale.Validate();
            return _repository.Add(sale);
        }

        public void Delete(Sale sale)
        {
            if (sale.Id <= 0)
            {
                throw new InvalidIdException();
            }
            _repository.Delete(sale.Id);
        }

        public Sale Get(Sale sale)
        {
            if (sale.Id <= 0)
            {
                throw new InvalidIdException();
            }
            return _repository.Get(sale.Id);
        }

        public IList<Sale> GetAll()
        {
            return _repository.GetAll();
        }

        public Sale Update(Sale sale)
        {
            sale.Validate();
            return _repository.Update(sale);
        }
    }
}

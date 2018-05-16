using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Sales
{
    public interface ISaleRepository
    {
        Sale Add(Sale sale);
        Sale Update(Sale sale);
        void Delete(long id);
        Sale Get(long id);
        IList<Sale> GetAll();
    }
}

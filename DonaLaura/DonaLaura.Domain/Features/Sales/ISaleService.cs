using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Sales
{
    public interface ISaleService
    {
        Sale Add(Sale sale);
        Sale Update(Sale sale);
        Sale Get(Sale sale);
        void Delete(Sale sale);
        IList<Sale> GetAll();
    }
}

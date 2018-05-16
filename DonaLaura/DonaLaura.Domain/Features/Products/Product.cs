using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Products
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double SalePrice { get; set; }
        public double CostPrice { get; set; }
        public int Availability { get; set; }
        public DateTime Manufacture { get; set; }
        public DateTime Expiration { get; set; }

        public void Validate()
        {
            if (String.IsNullOrEmpty(Name)) throw new ProductInvalidOrNullNameException();
            if (CostPrice >= SalePrice) throw new ProductCostBiggerSaleException();
            if (Manufacture >= Expiration) throw new ProductExpirationDateSmallerFabricationDateException();
        }
    }
}

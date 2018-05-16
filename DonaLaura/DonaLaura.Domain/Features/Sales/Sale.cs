using DonaLaura.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Sales
{
    public class Sale
    {
        public long Id { get; set; }
        public Product ProductSale { get; set; }
        public string Client { get; set; }
        public int Amount { get; set; }
        public double Profit { get { return Profit = (ProductSale.SalePrice - ProductSale.CostPrice) * Amount; } set { } }

        public void Validate()
        {
            if (String.IsNullOrEmpty(Client)) throw new SaleEmptyClienteException();
            if (Amount <= 0) throw new SaleEmptyOrZeroAmountException();
            if (ProductSale == null) throw new SaleEmptyOrNullProductSaleException();
            if (ProductSale.Availability <= 0) throw new SaleNotAvailabilityProductException();
        }
    }
}

﻿using System;
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
        public bool Availability { get; set; }
        public DateTime Manufacture { get; set; }
        public DateTime Expiration { get; set; }

        public void Validate()
        {
            if (Name.Length < 4) throw new ProductMinCharacterException();
            if (CostPrice >= SalePrice) throw new ProductCostBiggerSaleException();
            if (Manufacture >= Expiration) throw new ProductExpirationDateSmallerFabricationDateException();
        }
    }
}

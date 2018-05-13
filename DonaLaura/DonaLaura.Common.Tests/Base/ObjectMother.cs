using DonaLaura.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Common.Tests.Base
{
    public static partial class ObjectMother
    {
        public static Product GetProduct()
        {
            return new Product()
            {
                Id = 1,
                Name = "Creme Facial",
                SalePrice = 10.50,
                CostPrice = 8.50,
                Availability = 1,
                Manufacture = DateTime.Now,
                Expiration = DateTime.Now.AddDays(5)
            };
        }

        public static Product GetInvalidNameProduct()
        {
            return new Product()
            {
                Id = 1,
                Name = "Cre",
                SalePrice = 10.50,
                CostPrice = 8.50,
                Availability = 1,
                Manufacture = DateTime.Now,
                Expiration = DateTime.Now.AddDays(5)
            };
        }

        public static Product GetInvalidCostPriceProduct()
        {
            return new Product()
            {
                Id = 1,
                Name = "Creme Teste",
                SalePrice = 8.50,
                CostPrice = 10.50,
                Availability = 1,
                Manufacture = DateTime.Now,
                Expiration = DateTime.Now.AddDays(5)
            };
        }

        public static Product GetInvalidExpirationProduct()
        {
            return new Product()
            {
                Id = 1,
                Name = "Creme Facial",
                SalePrice = 10.50,
                CostPrice = 8.50,
                Availability = 1,
                Manufacture = DateTime.Now.AddDays(5),
                Expiration = DateTime.Now
            };
        }

        public static Product GetInvalidIdProduct()
        {
            return new Product()
            {
                Name = "Creme Facial",
                SalePrice = 10.50,
                CostPrice = 8.50,
                Availability = 1,
                Manufacture = DateTime.Now.AddDays(5),
                Expiration = DateTime.Now
            };
        }

        public static IList<Product> GetListPorduct()
        {
            return new List<Product>
            {
                GetProduct()
            };
        }

        public static Product GetProductSql()
        {
            return new Product()
            {
                Name = "Creme Facial",
                SalePrice = 10.50,
                CostPrice = 8.50,
                Availability = 1,
                Manufacture = DateTime.Now,
                Expiration = DateTime.Now.AddDays(5)
            };
        }
    }
}

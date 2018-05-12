using DonaLaura.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Products
{
    public class ProductCostBiggerSaleException : BusinessException
    {
        public ProductCostBiggerSaleException() : base("Preço de custo não pode ser maior que o preço de venda")
        {

        }
    }
}

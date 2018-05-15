﻿using DonaLaura.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Sales
{
    public class SaleEmptyOrNullProductSaleException : BusinessException
    {
        public SaleEmptyOrNullProductSaleException() : base("O produto esta vazio ou nullo")
        {

        }
    }
}

﻿using DonaRosangela.Domain.Features.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Domain.Features.Loans
{
    public class Loan
    {
        public long Id { get; set; }
        public string Client { get; set; }
        public Book LoanBook { get; set; }
        public DateTime Devolution { get; set; }

        public void Validate() { }
    }
}

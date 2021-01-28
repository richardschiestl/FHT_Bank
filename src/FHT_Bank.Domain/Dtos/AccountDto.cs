using System;
using System.Collections.Generic;
using System.Text;

namespace FHT_Bank.Domain.Dtos
{
    public class AccountDto
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}

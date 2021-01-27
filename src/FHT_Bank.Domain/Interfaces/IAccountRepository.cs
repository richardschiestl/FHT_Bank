﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FHT_Bank.Domain.Models;

namespace FHT_Bank.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetByAccountNumber(int accountNumber);
        Task Update(Account account);
    }
}

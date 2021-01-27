using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FHT_Bank.Domain.Dtos;
using FHT_Bank.Domain.Models;

namespace FHT_Bank.Domain.Interfaces
{
    public interface IAccountService
    {
        Task<Account> Withdraw(AccountDto accountDto);
        Task<Account> Deposit(AccountDto accountDto);
        Task<decimal> Balance(int accountNumber);
    }
}

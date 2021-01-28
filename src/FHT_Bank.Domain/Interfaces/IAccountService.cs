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
        Task<AccountDto> Withdraw(WithdrawDto withdrawDto);
        Task<AccountDto> Deposit(DepositDto withdrawDto);
        Task<decimal> Balance(int accountNumber);
        Task<bool> Exists(int accNumber);
        Task<bool> ValidateBalance(WithdrawDto withdrawDto);
    }
}

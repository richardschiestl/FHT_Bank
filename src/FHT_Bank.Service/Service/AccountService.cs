using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FHT_Bank.Data.Repository;
using FHT_Bank.Domain.Dtos;
using FHT_Bank.Domain.Interfaces;
using FHT_Bank.Domain.Models;

namespace FHT_Bank.Service.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<Account> Withdraw(AccountDto accountDto)
        {
            var account = await _accountRepository.GetByAccountNumber(accountDto.AccountNumber);

            account.Balance -= accountDto.Value;

            await _accountRepository.Update(account);

            return account;
        }

        public async Task<Account> Deposit(AccountDto accountDto)
        {
            var account = await _accountRepository.GetByAccountNumber(accountDto.AccountNumber);

            account.Balance += accountDto.Value;

            await _accountRepository.Update(account);

            return account;
        }

        public async Task<decimal> Balance(int accountNumber)
        {
            var account = await _accountRepository.GetByAccountNumber(accountNumber);

            return account.Balance;
        }
    }
}
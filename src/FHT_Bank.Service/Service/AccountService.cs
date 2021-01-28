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
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<AccountDto> Withdraw(WithdrawDto withdrawDto)
        {
            var account = await _accountRepository.GetByAccountNumber(withdrawDto.AccountNumber);

            account.Balance -= withdrawDto.Value;

            await _accountRepository.Update(account);

            return _mapper.Map<AccountDto>(account);
        }

        public async Task<AccountDto> Deposit(DepositDto withdrawDto)
        {
            var account = await _accountRepository.GetByAccountNumber(withdrawDto.AccountNumber);

            account.Balance += withdrawDto.Value;

            await _accountRepository.Update(account);

            return _mapper.Map<AccountDto>(account);
        }

        public async Task<decimal> Balance(int accountNumber)
        {
            var account = await _accountRepository.GetByAccountNumber(accountNumber);

            return account.Balance;
        }

        public async Task<bool> Exists(int accNumber)
           => await _accountRepository.Exists(accNumber);

        public async Task<bool> ValidateBalance(WithdrawDto withdrawDto)
            => await _accountRepository.ValidateBalance(withdrawDto);
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using FHT_Bank.Domain.Dtos;
using FHT_Bank.Domain.Interfaces;
using FHT_Bank.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FHT_Bank.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {

        private readonly Context.Context _context;

        public AccountRepository(Context.Context context)
        {
            _context = context;
        }

        public async Task<Account> GetByAccountNumber(int accountNumber)
            => await _context.Accounts.Where(x => x.AccountNumber == accountNumber).FirstOrDefaultAsync();

        public async Task Update(Account account)
        {
            _context.Accounts.Update(account);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int accountNumber)
            => await _context.Accounts.AllAsync(x => x.AccountNumber == accountNumber);

        public async Task<bool> ValidateBalance(WithdrawDto withdrawDto)
        {
            var account = await _context.Accounts.
                                                Where(x => x.AccountNumber == withdrawDto.AccountNumber)
                                                    .FirstOrDefaultAsync();

            if (account == null) return false;

            return account.Balance >= withdrawDto.Value;
        }
    }
}
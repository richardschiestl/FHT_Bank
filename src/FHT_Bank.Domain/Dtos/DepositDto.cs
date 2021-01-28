using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FHT_Bank.Domain.Interfaces;
using FluentValidation;

namespace FHT_Bank.Domain.Dtos
{
    public class DepositDto
    {
        public int AccountNumber { get; set; }
        public decimal Value { get; set; }
    }

    public class DepositDtoValidator : AbstractValidator<DepositDto>
    {
        private readonly IAccountService _accountService;

        public DepositDtoValidator(IAccountService accountService)
        {
            _accountService = accountService;

            RuleFor(x => x.AccountNumber).NotNull().NotEmpty().MustAsync(ValidarConta).WithMessage("Conta inválida");
            RuleFor(x => x.Value).NotNull().NotEmpty().GreaterThan(0);
        }

        private async Task<bool> ValidarConta(int accountNumber, CancellationToken arg2)
            => await _accountService.Exists(accountNumber);
    }
}

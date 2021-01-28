using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using FHT_Bank.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Validators;

namespace FHT_Bank.Domain.Dtos
{
    public class WithdrawDto
    {
        public int AccountNumber { get; set; }
        public decimal Value { get; set; }
    }

    public class TransactionDtoValidator : AbstractValidator<WithdrawDto>
    {
        private readonly IAccountService _accountService;

        public TransactionDtoValidator(IAccountService accountService)
        {
            _accountService = accountService;

            RuleFor(x => x.AccountNumber).NotNull().NotEmpty().MustAsync(Exists).WithMessage("Conta inválida");
            RuleFor(x => x.Value).NotNull().NotEmpty().GreaterThan(0).MustAsync(ValidateBalance).WithMessage("Saldo insuficiente");
        }

        private async Task<bool> Exists(int accountNumber, CancellationToken arg2)
            => await _accountService.Exists(accountNumber);

        private async Task<bool> ValidateBalance(WithdrawDto withdrawDto, decimal arg2, CancellationToken cancellationToken)
            => await _accountService.ValidateBalance(withdrawDto);
    }
}
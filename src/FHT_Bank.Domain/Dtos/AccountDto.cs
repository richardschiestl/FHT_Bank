using FluentValidation;

namespace FHT_Bank.Domain.Dtos
{
    public class AccountDto
    {
        public int AccountNumber { get; set; }
        public decimal Value { get; set; }
    }

    public class SacarDtoValidator : AbstractValidator<AccountDto>
    {
        public SacarDtoValidator()
        {
            RuleFor(x => x.AccountNumber).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Value).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
using FluentValidation;

namespace Application.Features.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
    {
        public UpdateAccountCommandValidator()
        {
            RuleFor(c => c.CustomerId)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.AccountNumber)
                .Length(10)
                .NotEmpty()
                .NotNull();
        }
    }
}

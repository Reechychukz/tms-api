using FluentValidation;

namespace Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
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

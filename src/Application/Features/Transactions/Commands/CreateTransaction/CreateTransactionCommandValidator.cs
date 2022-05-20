using FluentValidation;

namespace Application.Features.Transactions.Commands.InitiateTransaction
{
    public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        public CreateTransactionCommandValidator()
        {
            RuleFor(i => i.AccountId)
                .NotNull()
                .NotEmpty();

            RuleFor(i => i.FromAcct)
                .NotEmpty().WithMessage("{Sender} is required. ")
                .NotNull();

            RuleFor(i =>i.ToAcct)
                .NotEmpty().WithMessage("{Receiver} is required. ")
                .NotNull();

            RuleFor(i => i.TransactionType)
                .NotEmpty().WithMessage("{Receiver} is required. ");

            RuleFor(i => i.TransactionChannel)
                .NotEmpty().WithMessage("{Receiver} is required. ");
        }
    }
}

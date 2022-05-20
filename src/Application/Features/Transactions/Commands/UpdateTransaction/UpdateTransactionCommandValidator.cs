using FluentValidation;

namespace Application.Features.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommandValidator : AbstractValidator<UpdateTransactionCommand>
    {
        public UpdateTransactionCommandValidator()
        {
            RuleFor(i => i.FromAcct)
                .NotEmpty().WithMessage("{Sender} is required. ")
                .NotNull();

            RuleFor(i => i.ToAcct)
                .NotEmpty().WithMessage("{Receiver} is required. ")
                .NotNull();

            RuleFor(i => i.TransactionType)
                .NotEmpty().WithMessage("{Receiver} is required. ");

            RuleFor(i => i.TransactionChannel)
                .NotEmpty().WithMessage("{Receiver} is required. ");
        }
    }
}

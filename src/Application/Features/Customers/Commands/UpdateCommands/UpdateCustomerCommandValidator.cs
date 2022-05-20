using FluentValidation;

namespace Application.Features.Customers.Commands.UpdateCommands
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.FirstName)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.Email)
                .NotEmpty()
                .NotNull();
        }
    }
}

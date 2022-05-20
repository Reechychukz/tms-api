using FluentValidation;

namespace Application.Features.Customers.Commands.CreateCustomers
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(i => i.FirstName)
                .NotNull()
                .NotEmpty();

            RuleFor(i => i.LastName)
                .NotNull()
                .NotEmpty();

            RuleFor(i => i.Email)
                .NotNull()
                .NotEmpty();
        }
    }
}

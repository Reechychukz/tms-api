using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<List<CustomersVm>>
    {
        public string FirstName { get; set; }

        public GetCustomersListQuery(string firstName)
        {
            FirstName = FirstName ?? throw new ArgumentNullException(nameof(firstName));
        }
    }

    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, List<CustomersVm>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomersListQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomersVm>> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var customersList = await _customerRepository.GetCustomersByFIrstName(request.FirstName);
            return _mapper.Map<List<CustomersVm>>(customersList);
        }
    }
}

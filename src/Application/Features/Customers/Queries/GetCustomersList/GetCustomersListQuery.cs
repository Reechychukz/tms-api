using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<List<CustomersDto>>
    {
        public string FirstName { get; set; }

        public GetCustomersListQuery(string firstName)
        {
            FirstName = firstName;
        }
    }

    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, List<CustomersDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomersListQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomersDto>> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var customersList = await _customerRepository.GetCustomersByFIrstName(request.FirstName);
            return _mapper.Map<List<CustomersDto>>(customersList);
        }
    }
}

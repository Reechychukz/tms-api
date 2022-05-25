using Application.Contracts.Persistence;
using Application.Features.Customers.Queries.GetCustomersList;
using Application.Mappings;
using AutoMapper;
using Moq;
using Shouldly;
using TmsTest.Mocks;

namespace TmsTest.AccountType.Queries
{
    public class GetCustomersListRequestHandler
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICustomerRepository> _mockCustomerRepo;

        public GetCustomersListRequestHandler()
        {
            _mockCustomerRepo = MockCustomerRepository.GetListCustomersRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCutomersListTest()
        {
            var handler = new GetCustomersListQueryHandler(_mockCustomerRepo.Object, _mapper);
            string firstName = "John";
            var result = await handler.Handle(new GetCustomersListQuery(firstName), CancellationToken.None);

            result.ShouldBeOfType<List<CustomersDto>>();
            result.Count.ShouldBe(2);
        }
    }
}

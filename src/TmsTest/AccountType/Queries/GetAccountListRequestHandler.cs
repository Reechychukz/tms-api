using Application.Contracts.Persistence;
using Application.Features.Accounts.Queries.GetAccountsList;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Moq;
using Shouldly;
using TmsTest.Mocks;

namespace TmsTest.AccountType.Queries
{
    public class GetAccountListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAccountRepository> _mockAccountRepo;

        public GetAccountListRequestHandlerTests()
        {
            _mockAccountRepo = MockAccountRepository.GetListAccoountsRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetAccountListTest()
        {
            var handler = new GetAccountsListQueryHandler(_mockAccountRepo.Object, _mapper);
            var customerId = Guid.Parse("221b2312-29c8-27da-ab26-8327ab12bc3a");
            var result = await handler.Handle(new GetAccountsListQuery(customerId), CancellationToken.None);

            result.ShouldBeOfType<List<AccountsDto>>();
            result.Count.ShouldBe(2);
        }
    }
}

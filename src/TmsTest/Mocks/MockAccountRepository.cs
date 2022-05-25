using Application.Contracts.Persistence;
using Domain.Entities;
using Moq;

namespace TmsTest.Mocks
{
    public static class MockAccountRepository
    {

        public static Mock<IAccountRepository> GetListAccoountsRepository()
        {
            var accounts = new List<Account>
            {
                new Account
                {
                    Id = Guid.NewGuid(),
                    AccountNumber = "0232107784",
                    CreatedAt = DateTime.Now,
                    Balance = 140,
                    CustomerId = Guid.Parse("221b2312-29c8-27da-ab26-8327ab12bc3a"),
                    AccountType = Domain.Enums.EAccountType.SAVINGS,
                    BranchCode = "904"
                },
                new Account
                {
                    Id = Guid.NewGuid(),
                    AccountNumber = "0222107784",
                    CreatedAt = DateTime.Now,
                    Balance = 130,
                    CustomerId = Guid.Parse("221b2312-29c8-27da-ab26-8327ab12bc3a"),
                    AccountType = Domain.Enums.EAccountType.SAVINGS,
                    BranchCode = "964"
                }

            };
            var mockRepo = new Mock<IAccountRepository>();
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(accounts);

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Account>())).ReturnsAsync((Account account) =>
            {
                accounts.Add(account);
                return account;
            });

            return mockRepo;
        }
    }
}
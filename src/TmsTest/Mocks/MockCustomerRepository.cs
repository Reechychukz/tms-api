using Application.Contracts.Persistence;
using Domain.Entities;
using Moq;

namespace TmsTest.Mocks
{
    public static class MockCustomerRepository
    {
        public static Mock<ICustomerRepository> GetListCustomersRepository()
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Address = "Lagos",
                    Email = "johndoe@gmail.com",
                    FirstName = "John",
                    LastName = "Doe",
                    State = "Lagos",
                    Gender = "Male",
                    PhoneNumber = "09029232x",
                    CreatedAt = DateTime.Now
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Address = "Lagos",
                    Email = "johnde@gmail.com",
                    FirstName = "John",
                    LastName = "Doe",
                    State = "Lagos",
                    Gender = "Male",
                    PhoneNumber = "09029232x",
                    CreatedAt = DateTime.Now
                }

            };
            var mockRepo = new Mock<ICustomerRepository>();
            string firstName = "John";
            mockRepo.Setup(r => r.GetCustomersByFIrstName(firstName)).ReturnsAsync(customers);

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Customer>())).ReturnsAsync((Customer customer) =>
            {
                customers.Add(customer);
                return customer;
            });

            return mockRepo;
        }
    }
}
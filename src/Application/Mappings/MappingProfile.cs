using Application.Features.Accounts.Commands.CreateAccount;
using Application.Features.Accounts.Commands.UpdateAccount;
using Application.Features.Accounts.Queries.GetAccountsList;
using Application.Features.Customers.Commands.CreateCustomers;
using Application.Features.Customers.Commands.UpdateCommands;
using Application.Features.Customers.Queries.GetCustomersList;
using Application.Features.Transactions.Commands.InitiateTransaction;
using Application.Features.Transactions.Commands.UpdateTransaction;
using Application.Features.Transactions.Queries.GetTransactionsList;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Transaction, TransactionsVm>().ReverseMap();
            CreateMap<Transaction, CreateTransactionCommand>().ReverseMap();
            CreateMap<Transaction, UpdateTransactionCommand>().ReverseMap();
            CreateMap<Customer, CustomersVm>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
            CreateMap<Account, AccountsVm>().ReverseMap();
            CreateMap<Account, CreateAccountCommand>().ReverseMap();
            CreateMap<Account, UpdateAccountCommand>().ReverseMap();
        }
    }
}

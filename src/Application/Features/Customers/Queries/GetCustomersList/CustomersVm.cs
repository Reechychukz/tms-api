namespace Application.Features.Customers.Queries.GetCustomersList
{
    public class CustomersDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string State { get; set; }
        public string Lga { get; set; }
    }
}

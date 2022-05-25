using Domain.Enums;

namespace Application.Features.Accounts.Queries.GetAccountsList
{
    public class AccountsDto
    {
        public Guid Id { get; set; }
        public EAccountType AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string BranchCode { get; set; }
        public double Balance { get; set; }
        public bool IsApproved { get; set; } = false;


        //Navigation Properties
        public Guid CutomerId { get; set; }
    }
}

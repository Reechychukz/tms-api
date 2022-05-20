using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Account : AuditableEntity
    {
        public Guid Id { get; set; }
        public EAccountType AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string BranchCode { get; set; }
        public double Balance { get; set; }
        public bool IsApproved { get; set; } = false;


        //Navigation Properties
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}

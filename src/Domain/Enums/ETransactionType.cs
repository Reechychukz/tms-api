using System.ComponentModel;

namespace Domain.Enums
{
    public enum ETransactionType
    {
        [Description("Debit")]
        DEBIT = 1,
        [Description("Credit")]
        CREDIT = 2,
    }
}

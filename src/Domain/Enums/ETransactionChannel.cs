using System.ComponentModel;

namespace Domain.Enums
{
    public enum ETransactionChannel
    {
        [Description("ussd")]
        USSD = 1,
        [Description("Moile Banking")]
        MOBILEBANKING = 2,
        [Description("Internet Banking")]
        INTERNETBANKING = 3
    }
}

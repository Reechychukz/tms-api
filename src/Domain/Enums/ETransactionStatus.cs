using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum ETransactionStatus
    {
        [Description("successful")]
        SUCCESSFUL = 1,
        [Description("Failed")]
        FAILED = 2,
        [Description("Internet Banking")]
        PENDING = 3
    }
}

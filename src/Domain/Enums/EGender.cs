using System.ComponentModel;

namespace Domain.Enums
{
    public enum EGender
    {
        [Description("Male")]
        Male = 1,
        [Description("Female")]
        Female = 2,
        [Description("Other")]
        Other = 3
    }
}

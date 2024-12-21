using System.ComponentModel;

namespace N_Layer_App_EF_Template.Domain.Enums;

public enum TokenKeys
{
    [Description("RefreshToken")]
    RefreshToken = 0,
    [Description("ComfirmationToken")]
    ComfirmationToken = 1,
    [Description("PasswordResetToken")]
    PasswordResetToken = 2
}

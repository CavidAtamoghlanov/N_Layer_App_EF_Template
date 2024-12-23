using System.ComponentModel;

namespace N_Layer_App_EF_Template.Domain.Enums
{
    public enum ConfirmationMethod
    {
        [Description("Confirmation via Email.")]
        Email,

        [Description("Confirmation via Phone call or SMS.")]
        Phone,

        [Description("Confirmation via WhatsApp message.")]
        WhatsApp,

        [Description("Confirmation via Instagram message.")]
        Instagram,

        [Description("Confirmation via Telegram message.")]
        Telegram,

        [Description("Confirmation via Facebook message.")]
        Facebook,

        [Description("Confirmation via LinkedIn message.")]
        LinkedIn
    }
}

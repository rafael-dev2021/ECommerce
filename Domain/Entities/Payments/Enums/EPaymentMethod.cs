using System.ComponentModel;
using System.Diagnostics;

namespace Domain.Entities.Payments.Enums;

public enum EPaymentMethod
{
    [Description("Credit Card")]
    CreditCard = 1,

    [Description("Debit Card")]
    DebitCard = 2,

    [Description("Bank Slip")]
    BankSlip = 3
}
public static class EPaymentMethodHelper
{
    public static string GetDescription(this EPaymentMethod value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());

        Debug.Assert(fieldInfo != null, nameof(fieldInfo) + " != null");
        var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(
            typeof(DescriptionAttribute), false);

        return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }
}
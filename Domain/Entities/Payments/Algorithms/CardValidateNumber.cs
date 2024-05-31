namespace Domain.Entities.Payments.Algorithms;

public abstract class CardValidateNumber
{
    public static bool ValidateCardNumber(string creditCardNumber)
    {
        creditCardNumber = new string(creditCardNumber.Where(char.IsDigit).ToArray());

        var sum = 0;
        var alternate = false;

        for (var i = creditCardNumber.Length - 1; i >= 0; i--)
        {
            var digit = int.Parse(creditCardNumber[i].ToString());

            if (alternate)
            {
                digit *= 2;

                if (digit > 9)
                {
                    digit -= 9;
                }
            }
            sum += digit;
            alternate = !alternate;
        }
        return (sum % 10 == 0);
    }
}
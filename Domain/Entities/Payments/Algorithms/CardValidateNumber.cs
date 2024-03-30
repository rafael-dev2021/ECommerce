namespace Domain.Entities.Payments.Algorithms;

public class CardValidateNumber
{
    public static bool ValidateCardNumber(string creditCardNumber)
    {
        creditCardNumber = new string(creditCardNumber.Where(char.IsDigit).ToArray());

        int sum = 0;
        bool alternate = false;

        for (int i = creditCardNumber.Length - 1; i >= 0; i--)
        {
            int digit = int.Parse(creditCardNumber[i].ToString());

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
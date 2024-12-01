namespace ZielCodingChallenge.Business
{
    public class CreditCardHelper
    {
        public bool ValidCreditCard(string creditCardNumber)
        {
            // Luhn algorithm
            int sum = 0;
            bool alternate = false;
            for (int count = creditCardNumber.Length - 1; count >= 0; count--)
            {
                int number;
                if(!int.TryParse(creditCardNumber[count].ToString(), out number))
                {
                    throw (new Exception("Invalid credit card number character or symbol!"));
                }

                if (alternate)
                {
                    number *= 2;
                    if (number > 9)
                    {
                        number = (number % 10) + 1;
                    }
                }
                sum += number;
                alternate = !alternate;
            }
            return (sum % 10 == 0);
        }
    }
}

using POS.Domain.Exceptions.Abstractions;

namespace POS.Domain.Exceptions
{
    public sealed class InvalidCurrencyException : GlobalException
    {
        public string Currency { get; }

        public InvalidCurrencyException(string currency) : base($"Currency: '{currency}' is invalid.")
        {
            Currency = currency;
        }
    }
}

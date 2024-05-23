namespace POS.Application.Services;

public interface IPaymentService
{
    decimal CalculateRoundedRemainder(decimal amount, decimal scale, string roundingOverridingConfiguration);
}

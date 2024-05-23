using System.ComponentModel.DataAnnotations;
using POS.Application.DTO;
using POS.Application.Payments.Commands;

namespace POS.Application.Services;

public class PaymentService : IPaymentService
{
    public decimal CalculateRoundedRemainder(decimal amount, decimal scale, string roundingOverridingConfiguration)
    {
        decimal rounded = decimal.Zero;
        decimal roundedRemainder = decimal.Zero;

        if (scale == decimal.Zero)
        {
            rounded = amount;
        }
        else
        {
            decimal v = amount;

            decimal remainder = decimal.Zero;
            decimal midpoint = decimal.Zero;
            if (decimal.Zero != scale)
            {
                remainder = decimal.Remainder(v, scale);
                midpoint = GetScaleMidPoint(scale);
            }

            decimal actual = decimal.Subtract(v, remainder);
            decimal mpCheck = decimal.Subtract(midpoint, remainder);

            rounded = CheckAndCalculateNormalRounding(mpCheck, scale, actual);
            if (!string.IsNullOrEmpty(roundingOverridingConfiguration))
                rounded = CheckAndCalculateOverridedRounding(remainder, roundingOverridingConfiguration, v, rounded);

            roundedRemainder = decimal.Subtract(rounded, amount);
        }

        return roundedRemainder;
    }

    private static decimal CheckAndCalculateNormalRounding(decimal mpCheck, decimal scale, decimal actual)
    {
        decimal rounded;
        if ((decimal.Zero >= mpCheck && scale > decimal.Zero) || (decimal.Zero <= mpCheck && scale < decimal.Zero))
        {
            rounded = decimal.Add(actual, scale);
        }
        else
        {
            rounded = actual;
        }
        return rounded;
    }

    private static decimal CheckAndCalculateOverridedRounding(decimal remainder, string roundingOverridingConfiguration, decimal amount, decimal roundedAmount)
    {
        var listConfiguredSets = roundingOverridingConfiguration.Split('|');
        //0,0.05;0|0.05;0.05|0.05,1.0;0.05
        foreach (var setEval in listConfiguredSets)
        {
            try
            {
                var splTmp = setEval.Split(';');
                var roundTarget = splTmp[1];
                decimal roundTargetDec = decimal.Parse(roundTarget);
                var remainderExpr = splTmp[0];
                if (remainderExpr.Contains(','))
                {
                    var boundariesSplit = remainderExpr.Split(',');
                    var lowerBoundary = decimal.Parse(boundariesSplit[0]);
                    var upperBoundary = decimal.Parse(boundariesSplit[1]);
                    if ((lowerBoundary < Math.Abs(remainder)) && (Math.Abs(remainder) < upperBoundary))
                        return CalculateRoundingOverrideAmountSigned(amount, remainder, roundTargetDec);

                }
                else
                {
                    decimal remainderExprDec = decimal.Parse(remainderExpr);
                    if (remainder == remainderExprDec)
                        return CalculateRoundingOverrideAmountSigned(amount, remainder, roundTargetDec);
                }
            }
            catch (System.Exception ex)
            {
                throw new ValidationException("The rounding override config is not valid", ex);
            }
        }
        return roundedAmount;
    }

    private static decimal CalculateRoundingOverrideAmountSigned(decimal amount, decimal remainder, decimal roundTarget)
    {
        var sign = amount > 0 ? 1M : -1M;
        var roundingUnsigned = Math.Abs(amount) - (Math.Abs(remainder) - roundTarget);
        return sign * roundingUnsigned;
    }

    private static decimal GetScaleMidPoint(decimal scale)
    {
        decimal midpoint = decimal.Zero;
        if (scale != decimal.Zero)
        {
            midpoint = decimal.Divide(scale, 2M);
        }

        return midpoint;
    }
}

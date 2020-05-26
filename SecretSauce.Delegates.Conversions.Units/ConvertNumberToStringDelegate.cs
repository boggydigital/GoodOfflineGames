using System;
using System.Linq;
using SecretSauce.Delegates.Conversions.Interfaces;

namespace SecretSauce.Delegates.Conversions.Units
{
    public abstract class ConvertNumberToStringDelegate : IConvertDelegate<long, string>
    {
        protected string format;
        protected string[] orderTitles;
        protected long[] relativeOrders;
        protected bool roundValue;
        protected string zero;

        public string Convert(long value)
        {
            var max = relativeOrders.Aggregate((long) 1, (a, b) => a * b);

            for (var ii = 0; ii < relativeOrders.Length; ii++)
            {
                if (value >= max)
                {
                    var outputValue = decimal.Divide(value, max);
                    if (roundValue) outputValue = Math.Round(outputValue);
                    return string.Format(
                        format,
                        outputValue,
                        orderTitles[ii]);
                }

                max /= relativeOrders[ii];
            }

            return zero;
        }
    }
}
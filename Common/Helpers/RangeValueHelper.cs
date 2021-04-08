using System;

namespace Common.Helpers
{
    public static class RangeValueHelper
    {
        public static double GetInRange(double requestedValue, double minValue, double maxValue)
        {
            if (maxValue < minValue)
            {
                throw new NotSupportedException();
            }

            if (requestedValue >= maxValue)
            {
                return maxValue;
            }

            if (requestedValue <= minValue)
            {
                return minValue;
            }

            return requestedValue;
        }
    }
}
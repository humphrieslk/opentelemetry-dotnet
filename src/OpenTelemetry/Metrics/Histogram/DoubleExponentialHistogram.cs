using System;

namespace OpenTelemetry.Metrics.Histogram
{
    public class DoubleExponentialHistogram : ExponentialHistogram<double>
    {
        public DoubleExponentialHistogram(double scale, double growthFactor, int numberOfFiniteBuckets)
            : base(scale, growthFactor, numberOfFiniteBuckets)
        {
        }

        protected override int GetBucketIndex(double valueToAdd)
        {
            var doubleIndex = Math.Log(valueToAdd / this.Scale, this.GrowthFactor);

            return (int)Math.Floor(doubleIndex);
        }

        protected override double GetHighestBound()
        {
            return this.Scale * Math.Pow(this.GrowthFactor, this.NumberOfFiniteBuckets);
        }
    }
}

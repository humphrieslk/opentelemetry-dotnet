using System;

namespace OpenTelemetry.Metrics.Histogram
{
    public class Int64ExponentialHistogram : ExponentialHistogram<long>
    {
        public Int64ExponentialHistogram(long scale, long growthFactor, int numberOfFiniteBuckets)
            : base(scale, growthFactor, numberOfFiniteBuckets)
        {
        }

        protected override int GetBucketIndex(long valueToAdd)
        {
            var doubleIndex = Math.Log((double)valueToAdd / this.Scale, this.GrowthFactor);

            return (int)Math.Floor(doubleIndex);
        }

        protected override long GetHighestBound()
        {
            return this.Scale * (long)Math.Pow(this.GrowthFactor, this.NumberOfFiniteBuckets);
        }
    }
}

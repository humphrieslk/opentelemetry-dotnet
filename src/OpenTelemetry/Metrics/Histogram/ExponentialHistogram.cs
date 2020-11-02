using System;

namespace OpenTelemetry.Metrics.Histogram
{
    public abstract class ExponentialHistogram<T> : Histogram<T>
        where T : IComparable<T>
    {

        internal readonly T GrowthFactor;
        internal readonly T Scale;

        protected ExponentialHistogram(T scale, T growthFactor, int numberOfFiniteBuckets)
            : base (numberOfFiniteBuckets)
        {
            this.GrowthFactor = growthFactor;
            this.Scale = scale;
        }

        // scale * growth_factor ^ i
        protected override T GetLowestBound()
        {
            return this.Scale;
        }
    }
}

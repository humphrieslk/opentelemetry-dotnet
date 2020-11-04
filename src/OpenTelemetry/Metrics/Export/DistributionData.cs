namespace OpenTelemetry.Metrics.Export
{
    public class DistributionData : MetricData
    {
        public long Count { get; set; }

        public double Mean { get; set; }

        public double SumOfSquaredDeviation { get; set; }

        public long[] BucketCounts { get; set; }
    }
}

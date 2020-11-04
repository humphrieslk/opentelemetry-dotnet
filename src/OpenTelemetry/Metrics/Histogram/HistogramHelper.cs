using System;
using System.Collections.Concurrent;
using System.Linq;
using OpenTelemetry.Metrics.Export;

namespace OpenTelemetry.Metrics.Histogram
{
    public static class HistogramHelper
    {
        public static double GetSumOfSquaredDeviation(double mean, double[] values)
        {
            var result = 0.0;

            foreach (var value in values)
            {
                result += Math.Pow((mean - value), 2);
            }

            return result;
        }

        // public static DistributionData GetDoubleDistributionData(long[] bucketCounts, ConcurrentDictionary<double, long> valueCounts)
        // {
        //     var count = valueCounts.Values.Sum();
        //     var sum = 0.0;
        //
        //     foreach (var value in valueCounts.Keys)
        //     {
        //         var valueCount = valueCounts[value];
        //
        //         sum += value * valueCount;
        //     }
        //
        //     return new DistributionData
        //     {
        //         BucketCounts = bucketCounts,
        //         Count = valueCounts.Values.Sum(),
        //         Mean = mean,
        //         SumOfSquaredDeviation = GetSumOfSquaredDeviation(
        //             mean, valueCounts),
        //     };
        // }
    }
}

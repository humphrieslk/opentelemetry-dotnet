// <copyright file="DoubleMeasureDistributionAggregator.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using System;
using System.Collections.Immutable;
using System.Linq.Expressions;
using System.Threading;
using OpenTelemetry.Metrics.Export;
using OpenTelemetry.Metrics.Histogram;

namespace OpenTelemetry.Metrics.Aggregators
{
    public class DoubleMeasureDistributionAggregator : Aggregator<double>
    {
        private readonly Histogram<double> histogram;
        private double[] bucketCounts;

        public DoubleMeasureDistributionAggregator(AggregationOptions aggregationOptions)
        {
            switch (aggregationOptions)
            {
                case DoubleExplicitDistributionOptions explicitOptions :
                    this.histogram = new ExplicitHistogram<double>(explicitOptions.Bounds);
                    break;
                case DoubleLinearDistributionOptions linearOptions :
                    this.histogram = new DoubleLinearHistogram(
                        linearOptions.Offset, linearOptions.Width, linearOptions.NumberOfFiniteBuckets);
                    break;
                case DoubleExponentialDistributionOptions exponentialOptions :
                    this.histogram = new DoubleExponentialHistogram(
                        exponentialOptions.Scale,
                        exponentialOptions.GrowthFactor,
                        exponentialOptions.NumberOfFiniteBuckets);
                    break;
                default:
                    throw new NotSupportedException(
                        "Unsupported aggregation options. Supported option types include: " +
                        "DoubleExplicitDistributionOptions, DoubleLinearDistributionOptions, " +
                        "DoubleExponentialDistributionOptions");
            }
            this.histogram = new ExplicitHistogram<double>(new double[1]);
        }

        /// <inheritdoc/>
        public override void Update(double value)
        {
            this.histogram.RecordValue(value);
        }

        /// <inheritdoc/>
        public override void Checkpoint()
        {
            // TODO
            Interlocked.Exchange(ref this.bucketCounts, new double[] { });
        }

        /// <inheritdoc/>
        public override MetricData ToMetricData()
        {
            return new DoubleDistributionData();
        }

        /// <inheritdoc/>
        public override AggregationType GetAggregationType()
        {
            return AggregationType.DoubleDistribution;
        }
    }
}

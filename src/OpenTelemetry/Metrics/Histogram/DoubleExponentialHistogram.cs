﻿// <copyright file="DoubleExponentialHistogram.cs" company="OpenTelemetry Authors">
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
using System.Linq;
using OpenTelemetry.Metrics.Export;

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

        protected override DistributionData<double> GetDistributionData()
        {
            var mean = this.Values.Average();

            return new DistributionData<double>
            {
                BucketCounts = this.GetBucketCounts(),
                Count = this.Values.Count,
                Mean = mean,
                SumOfSquaredDeviation = HistogramHelper.GetSumOfSquaredDeviation(mean, this.Values.ToArray()),
            };
        }

        protected override double GetHighestBound()
        {
            return this.Scale * Math.Pow(this.GrowthFactor, this.NumberOfFiniteBuckets);
        }
    }
}

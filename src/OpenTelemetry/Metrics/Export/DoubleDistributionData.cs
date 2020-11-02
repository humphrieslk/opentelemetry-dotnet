// <copyright file="DoubleDistributionData.cs" company="OpenTelemetry Authors">
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

namespace OpenTelemetry.Metrics.Export
{
    public class DoubleDistributionData : MetricData
    {
        public long Count { get; set; }

        public double Mean { get; set; }

        public double SumOfSquaredDeviation { get; set; }

        public double Min { get; set; }

        public double Max { get; set; }

        public long BucketCounts { get; set; }

        // TODO: Bucket Options

        // count_ = other.count_;
        // mean_ = other.mean_;
        // sumOfSquaredDeviation_ = other.sumOfSquaredDeviation_;
        // range_ = other.range_ != null ? other.range_.Clone() : null;
        // bucketOptions_ = other.bucketOptions_ != null ? other.bucketOptions_.Clone() : null;
        // bucketCounts_ = other.bucketCounts_.Clone();

        // at this time not supporting:
        // exemplars_ = other.exemplars_.Clone();
    }
}

﻿// <copyright file="Int64ExponentialHistogramTest.cs" company="OpenTelemetry Authors">
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

using System.Collections.Immutable;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTelemetry.Metrics.Histogram;
using Xunit;
using Assert = Xunit.Assert;

namespace OpenTelemetry.Metrics.Tests
{
    public class Int64ExponentialHistogramTest
    {
        [Fact]
        public void RecordValue()
        {
            // expected bucket boundaries: { 1, 2, 4, 8, 16, 32 }
            var exponentialHistogram = new Int64ExponentialHistogram(1, 2, 5);
            var expectedBucketCounts = ImmutableArray.Create(new long[] { 1, 1, 2, 4, 8, 16, 1 });

            for (var i = 0; i <= 32; ++i)
            {
                exponentialHistogram.RecordValue(i);
            }

            var distributionData = exponentialHistogram.GetDistributionAndClear();
            CollectionAssert.AreEqual(expectedBucketCounts, distributionData.BucketCounts);
            Assert.Equal(33, distributionData.Count);
            Assert.Equal(16, distributionData.Mean);
            Assert.Equal(2992, distributionData.SumOfSquaredDeviation);
        }
    }
}

// <copyright file="ExplicitHistogramTest.cs" company="OpenTelemetry Authors">
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
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTelemetry.Metrics.Histogram;
using Xunit;
using Assert = Xunit.Assert;

namespace OpenTelemetry.Metrics.Tests
{
    public class ExplicitHistogramTest
    {
        [Fact]
        public void RecordValue_Success()
        {
            var explicitHistogram = new ExplicitHistogram<long>(new long[] { -1, 0, 1, 2, 4, 8, 10, 16 });
            var expected = ImmutableArray.Create(new long[] { 1, 1, 1, 1, 2, 4, 2, 6, 2 });

            for (var i = -2; i <= 17; ++i)
            {
                explicitHistogram.RecordValue(i);
            }

            CollectionAssert.AreEqual(expected, explicitHistogram.GetBucketCountsAndClear());
        }

        [Fact]
        public void RecordValue_SuccessWithOneBoundary()
        {
            var explicitHistogram = new ExplicitHistogram<long>(new long[] { 0 });
            var expected = ImmutableArray.Create(new long[] { 10, 11 });

            for (var i = -10; i <= 10; ++i)
            {
                explicitHistogram.RecordValue(i);
            }

            CollectionAssert.AreEqual(expected, explicitHistogram.GetBucketCountsAndClear());
        }

        [Fact]
        public void GetBucketCountsAndClear_ClearsCounts()
        {
            var explicitHistogram = new ExplicitHistogram<long>(new long[] { 0, 1 });
            var expectedValues = ImmutableArray.Create(new long[] { 0, 1, 1 });
            var expectedEmpty = ImmutableArray.Create(new long[] { 0, 0, 0 });

            explicitHistogram.RecordValue(0);
            explicitHistogram.RecordValue(1);

            CollectionAssert.AreEqual(expectedValues, explicitHistogram.GetBucketCountsAndClear());
            CollectionAssert.AreEqual(expectedEmpty, explicitHistogram.GetBucketCountsAndClear());
        }

        [Fact]
        public void ThrowsForInvalidHistogramParams()
        {
            try
            {
                var explicitHistogram = new ExplicitHistogram<long>(new long[] { });
                Assert.True(false, "Constructor should have thrown error.");
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                var explicitHistogram = new ExplicitHistogram<long>(new long[210]);
                Assert.True(false, "Constructor should have thrown error.");
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }
    }
}

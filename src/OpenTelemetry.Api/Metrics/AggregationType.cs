// <copyright file="AggregationType.cs" company="OpenTelemetry Authors">
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

namespace OpenTelemetry.Metrics
{
    [Obsolete("Metrics API/SDK is not recommended for production. See https://github.com/open-telemetry/opentelemetry-dotnet/issues/1501 for more information on metrics support.")]
    public enum AggregationType
    {
        /// <summary>
        /// Sum of type Double which is reported with OpenTelemetry.Metrics.Export.DoubleSumData />
        /// </summary>
        DoubleSum,

        /// <summary>
        /// Sum of type Long which is reported with OpenTelemetry.Metrics.Export.Int64SumData/>
        /// </summary>
        LongSum,

        /// <summary>
        /// Summary of measurements (Min, Max, Sum, Count), which is reported with OpenTelemetry.Metrics.Export.DoubleSummaryData/>
        /// </summary>
        DoubleSummary,

        /// <summary>
        /// Summary of measurements (Min, Max, Sum, Count), which is reported with OpenTelemetry.Metrics.Export.Int64SummaryData/>
        /// </summary>
        Int64Summary,

        /// <summary>
        /// Distribution of measurements(Min, Max, Sum, Count), which is reported with OpenTelemetry.Metrics.Export.DoubleDistributionData/>
        /// </summary>
        DoubleDistribution,

        /// <summary>
        /// Distribution of measurements (Min, Max, Sum, Count), which is reported with OpenTelemetry.Metrics.Export.Int64DistributionData/>
        /// </summary>
        Int64Distribution,
    }
}

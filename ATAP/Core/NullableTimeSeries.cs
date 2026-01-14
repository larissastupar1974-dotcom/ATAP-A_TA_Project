// <copyright file="NullableTimeSeries.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace Core;

/// <summary>
/// Timeseries where DataPoints are nullable.
/// </summary>
/// <param name="Name">TimeSeries name.</param>
/// <param name="Values">Nullable data points.</param>
public record NullableTimeSeries(string Name, IReadOnlyList<NullableDataPoint> Values);
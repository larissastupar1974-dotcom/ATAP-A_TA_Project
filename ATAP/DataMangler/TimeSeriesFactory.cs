// <copyright file="TimeSeriesFactory.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace DataMangler;

using Core;
using DataLoader.DTO;
using DataMangler.Pickers;

/// <summary>
/// Factory to make TimeSeries.
/// </summary>
public class TimeSeriesFactory
{
    /// <summary>
    /// Create nullable time series by picking one field from list of ohlcv.
    /// </summary>
    /// <param name="name">TimeSeries name.</param>
    /// <param name="ohlcvs">Raw ohlcv list.</param>
    /// <param name="picker">Field picker.</param>
    /// <returns>Nullable timeseries.</returns>
    public static NullableTimeSeries Create(string name, IReadOnlyList<Ohlcv> ohlcvs, IPicker<Ohlcv> picker)
    {
        List<NullableDataPoint> points = [..ohlcvs.Select(picker.GetValue)];
        return new NullableTimeSeries(name, points);
    }
}

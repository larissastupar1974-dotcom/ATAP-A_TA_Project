// <copyright file="ReadCsv.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace DataLoader;

using System.Globalization;
using CsvHelper;
using DataLoader.DTO;

/// <summary>
/// Read csv.
/// </summary>
public static class ReadCsv
{
    /// <summary>
    /// Read from path to DataBentoOhlcv.
    /// </summary>
    /// <param name="path">File path.</param>
    /// <returns>Records.</returns>
    public static IReadOnlyList<DataBentoOhlcv> ReadDataBentoOhlcv(string path)
    {
        using StreamReader reader = new(path);
        using CsvReader csv = new(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<DataBentoOhlcv>();
        return [..records];
    }
}

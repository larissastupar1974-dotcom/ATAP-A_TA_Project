// <copyright file="OhlcvTests.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace DataMangler.Test;

using Core;
using DataLoader.DTO;
using DataLoader.Test;
using DataMangler.Pickers;
using Xunit.Abstractions;

public class OhlcvTests(ITestOutputHelper output)
{
    [Fact]
    public void TestGetSnippetAsStandardDtos()
    {
        _ = this.GetSnippetAsStandardDtos();
    }

    [Fact]
    public void TestGetClosingNullableTimeSeriesFromSnippet()
    {
        _ = this.GetNullableTimeSeriesOfSnippetCloses();
    }

    [Fact]
    public void TestGetClosingNullableTimeSeriesFromFile()
    {
        _ = this.GetNullableTimeSeriesOfFileCloses();
    }

    [Fact]
    public void TestGetClosingTimeSeriesFromFile()
    {
        _ = this.GetTimeSeriesOfFileCloses();
    }

    [Theory]
    [InlineData(65152)]
    public void TestTimeSeriesFromFileNullCount(int expectedNulls)
    {
        NullableTimeSeries ts = this.GetNullableTimeSeriesOfFileCloses();
        int actualNulls = ts.NullCount();
        output.WriteLine($"{actualNulls.WithCommas()} out of {ts.Values.Count.WithCommas()} are null.");
        Assert.Equal(expectedNulls, actualNulls);
    }

    private static NullableTimeSeries GetNullableTimeSeriesOfCloses(List<Ohlcv> dtos)
    {
        var picker = new OhlcvClosePicker();
        var ts = TimeSeriesFactory.Create("TestClosingTimeSeries", dtos, picker);
        return ts;
    }

    private TimeSeries GetTimeSeriesOfFileCloses()
    {
        var ts = this.GetNullableTimeSeriesOfFileCloses().ToTimeSeries();
        return ts;
    }

    private NullableTimeSeries GetNullableTimeSeriesOfFileCloses()
    {
        var ts = GetNullableTimeSeriesOfCloses(this.GetFileAsStandardDtos());
        return ts;
    }

    private NullableTimeSeries GetNullableTimeSeriesOfSnippetCloses()
    {
        return GetNullableTimeSeriesOfCloses(this.GetSnippetAsStandardDtos());
    }

    private List<Ohlcv> GetSnippetAsStandardDtos()
    {
        DataBentoTest dbt = new(output);
        return dbt.ConvertToStandardDtosSnippet();
    }

    private List<Ohlcv> GetFileAsStandardDtos()
    {
        DataBentoTest dbt = new(output);
        return dbt.ConvertToStandardDtosFile();
    }
}
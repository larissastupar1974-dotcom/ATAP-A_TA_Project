// <copyright file="NullableDataPoint.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace Core;

/// <summary>
/// Data point where value is nullable.
/// </summary>
/// <param name="TimeStamp">Timestamp.</param>
/// <param name="Value">Nullable value.</param>
public record NullableDataPoint(DateTime TimeStamp, double? Value);

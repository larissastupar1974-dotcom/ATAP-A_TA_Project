// <copyright file="Globals.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Global things.
/// </summary>
public static class Globals
{
    /// <summary>
    /// Returns int to string but with commas.
    /// </summary>
    /// <param name="value">int.</param>
    /// <returns>with thousand commas.</returns>
    public static string WithCommas(this int value)
    {
        return value.ToString("#,###,###");
    }
}

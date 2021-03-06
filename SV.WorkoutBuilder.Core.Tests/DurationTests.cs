﻿using FluentAssertions;
using NUnit.Framework;
using SV.Builder.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Core.Tests
{
    public class DurationTests
    {
        [Test]
        public void Add_two_durations()
        {
            var duration = Duration.FiveMinutes;
            var duration2 = Duration.FiveMinutes;

            var total = duration + duration2;

            total.Length.TotalMinutes.Should().Be(10);
        }
    }
}

﻿using FluentAssertions;
using BitFaster.Caching.Lru;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BitFaster.Caching.UnitTests.Lru
{
    public class NoTelemetryPolicyTests
    {
        private NoTelemetryPolicy<int, int> counter = new NoTelemetryPolicy<int, int>();

        [Fact]
        public void HitRatioIsZero()
        {
            counter.HitRatio.Should().Be(0);
        }

        [Fact]
        public void TotalIsZero()
        {
            counter.Total.Should().Be(0);
        }

        [Fact]
        public void HitsIsZero()
        {
            counter.Hits.Should().Be(0);
        }

        [Fact]
        public void MissesIsZero()
        {
            counter.Misses.Should().Be(0);
        }

        [Fact]
        public void EvictedIsZero()
        {
            counter.Evicted.Should().Be(0);
        }

        [Fact]
        public void IsEnabledIsFalse()
        {
            counter.IsEnabled.Should().BeFalse();
        }

        [Fact]
        public void IncrementHitCountIsNoOp()
        {
            counter.Invoking(c => c.IncrementHit()).Should().NotThrow();
        }

        [Fact]
        public void IncrementTotalCountIsNoOp()
        {
            counter.Invoking(c => c.IncrementMiss()).Should().NotThrow();
        }

        [Fact]
        public void OnItemRemovedIsNoOp()
        {
            counter.Invoking(c => c.OnItemRemoved(1, 2, ItemRemovedReason.Evicted)).Should().NotThrow();
        }
    }
}

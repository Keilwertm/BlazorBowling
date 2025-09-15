using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBowling;

public class DebugCheckResult
{
    public bool Passed { get; set; }
    public string Message { get; set; } = string.Empty;
}

public class DebugChecker
{
    private readonly List<(string name, IEnumerable<int> rolls, int expected)> _scenarios = new()
    {
        // Perfect game: 12 strikes
        ("Perfect game (12X)", Enumerable.Repeat(10, 12), 300),

        // All spares (5,5) with bonus 5
        ("All spares 5/ with fill 5", Enumerable.Repeat(5, 21), 150),

        // Strike followed by 3,4, then misses
        ("Strike, then 3 and 4", new [] {10, 3, 4}.Concat(Enumerable.Repeat(0, 16)), 24),

        // Open frames only (no bonuses)
        ("All open 9-0", Enumerable.Repeat(9, 10).SelectMany(x => new[]{9,0}), 90),

        // 10th frame spare with bonus
        ("10th-frame spare with 7 fill",
            Enumerable.Repeat(1, 18)
                .Concat(new[] { 4, 6, 7 }),
            9 * 2 + (10 + 7)), // 18 + 17 = 35

        // Turkey to start, then 1,1 then gutters
        ("Turkey start, then 1,1", new [] {10,10,10,1,1}.Concat(Enumerable.Repeat(0, 14)), 10+10+10 + 10+10+1 + 10+1+1 + 1+1),

        // Edge: mixed sequence with strikes, spares, and an open 10th (9-)
        ("Mixed: X X 9/ ... 10th 9-", new [] {10,10,9,1, 3,5, 10, 0,0, 7,2, 6,4, 10, 9,0}, 137)
    };

    public async Task<DebugCheckResult> RunAsync(Func<IEnumerable<int>, int> scorer)
    {
        // Simulate async like adding in a wait between clicks
        await Task.Delay(1);

        var failures = new List<string>();
        foreach (var (name, rolls, expected) in _scenarios)
        {
            var actual = scorer(rolls);
            if (actual != expected)
            {
                failures.Add($"{name}: expected {expected}, got {actual}");
            }
        }

        if (failures.Count == 0)
        {
            return new DebugCheckResult
            {
                Passed = true,
                Message = "All debug checks passed"
            };
        }

        // Trims the banner message a little
        var preview = string.Join(" | ", failures.Take(2));
        var more = failures.Count > 2 ? $" (+{failures.Count - 2} more)" : "";
        return new DebugCheckResult
        {
            Passed = false,
            Message = $"Debug checks failed: {preview}{more}"
        };
    }
}
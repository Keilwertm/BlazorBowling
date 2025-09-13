using System;
using System.Collections.Generic;

namespace BlazorBowling;

internal static class DebugChecker
{
    public static void Run()
    {
        // Perfect game = 300
        ExpectEqual(300, BowlingScorer.ScoreFromRolls(Rolls(12, 10)), "PerfectGame");

        // All spares (21 rolls of 5) = 150
        ExpectEqual(150, BowlingScorer.ScoreFromRolls(Rolls(21, 5)), "AllSparesWithFives");

        // Gutter game (20 zeros) = 0
        ExpectEqual(0, BowlingScorer.ScoreFromRolls(Rolls(20, 0)), "GutterGame");

        // 9- in every frame (10 frames of 9,0) = 90
        var ninesMisses = new List<int>();
        for (int i = 0; i < 10; i++) { ninesMisses.Add(9); ninesMisses.Add(0); }
        ExpectEqual(90, BowlingScorer.ScoreFromRolls(ninesMisses), "NinesAndMisses");

        // Strike, then 3,4 then fill with zeros => 24
        var strikeThen34 = new List<int> { 10, 3, 4 };
        for (int i = 0; i < 17; i++) strikeThen34.Add(0);
        ExpectEqual(24, BowlingScorer.ScoreFromRolls(strikeThen34), "StrikeThenThreeFour");

        Console.WriteLine("[DebugChecker] All checks passed.");
    }

    private static void ExpectEqual(int expected, int actual, string name)
    {
        if (expected != actual)
            throw new InvalidOperationException($"[DebugChecker] {name} failed. Expected {expected}, got {actual}.");
    }

    private static List<int> Rolls(int count, int pins)
    {
        var list = new List<int>(count);
        for (int i = 0; i < count; i++) list.Add(pins);
        return list;
    }
}
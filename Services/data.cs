using System;
using System.Collections.Generic;

namespace BlazorBowling.Services;

public class SavedGame
{
    public string PlayerName { get; set; } = string.Empty;
    public int Score { get; set; }
    public DateTime Timestamp { get; set; }
}

public class DataRazor
{
    public string PlayerName { get; set; } = string.Empty;

    // Storage for saved games (in-memory for this session)
    public List<SavedGame> SavedGames { get; } = new List<SavedGame>();

    // These fields are kept for potential shared-state use, though the ScoreCard currently manages its own state
    public int[,] rolls = new int[2,10];   
    public int[] frameTotals = new int[10];
    public int currentFrame = 0;
    public int currentRoll = 0;
}
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
    
}
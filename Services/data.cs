namespace BlazorBowling.Services;

public class DataRazor
{
    public string PlayerName { get; set; } 
    public int[,] rolls = new int[2,10];   
    public int[] frameTotals = new int[10];
    public int currentFrame = 0;
    public int currentRoll = 0;

}
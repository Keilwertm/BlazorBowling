using System.Collections.Generic;
using System.Linq;

public static class BowlingScorer
{
    // Standard bowling scoring from a list of pinfalls.
    // Accepts typical 20–21 rolls (or 12 strikes); ignores extra beyond 10 frames.
    public static int ScoreFromRolls(IEnumerable<int> rollsEnumerable)
    {
        var rolls = rollsEnumerable.ToList();
        int score = 0;
        int rollIndex = 0;

        for (int frame = 0; frame < 10; frame++)
        {
            if (rollIndex >= rolls.Count) break;

            // Strike
            if (rolls[rollIndex] == 10)
            {
                score += 10 + Get(rolls, rollIndex + 1) + Get(rolls, rollIndex + 2);
                rollIndex += 1;
                continue;
            }

            // Otherwise two-ball frame
            int first = rolls[rollIndex];
            int second = Get(rolls, rollIndex + 1);
            int framePins = first + second;

            if (framePins == 10) // Spare
            {
                score += 10 + Get(rolls, rollIndex + 2);
            }
            else
            {
                score += framePins;
            }

            rollIndex += 2;
        }

        return score;
    }

    private static int Get(List<int> rolls, int index) => index < rolls.Count ? rolls[index] : 0;
}
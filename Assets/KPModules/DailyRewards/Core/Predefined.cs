using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KPModules.DailyReward
{
    [System.Serializable]
    public enum Day
    {
        Day1 = 0, Day2 = 1, Day3 = 2, Day4 = 3, Day5 = 4, Day6 = 5, Day7 = 6, Day8 = 7, Day9 = 8, Day10 = 9
    }

    [System.Serializable]
    public enum RewardBoxState
    {
        Claimed = 0, ReadyToClaimed = 1, CannotClaimed = 2
    }
}
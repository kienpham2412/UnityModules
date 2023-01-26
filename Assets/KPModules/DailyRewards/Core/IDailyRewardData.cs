using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KPModules.DailyReward
{
    public interface IDailyRewardData
    {
        public int LastestUnlockedChestDay { get; set; }
        public int LastLoginTime { get; set; }
        public int FirstLoginTime { get; set; }
        public int NumberOfLoginDays { get; set; }
        public bool IsTodayRewardClaimed { get; set; }
    }
}

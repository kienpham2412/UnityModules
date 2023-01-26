using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace KPModules.DailyReward
{
    public abstract class DailyRewardBox : MonoBehaviour
    {
        public Day day;
        public IDailyRewardData dailyRewardData;

        public abstract void DisplayReward();
        public abstract void ClickBox();
        public abstract void SetUnlockState(RewardBoxState rewardBoxState);
    }
}

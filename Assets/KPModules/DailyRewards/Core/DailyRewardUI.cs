using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KPModules.DailyReward
{
    public abstract class DailyRewardUI : MonoBehaviour
    {
        public IDailyRewardData DailyRewardData { get; set; }
        public DailyRewardBox[] rewardBoxes;
        private int day;

        protected virtual void Awake()
        {
            for (int i = 0; i < rewardBoxes.Length; i++)
            {
                rewardBoxes[i].day = (Day)i;
                rewardBoxes[i].dailyRewardData = DailyRewardData;
            }
        }

        protected virtual void Start()
        {
            day = DailyRewardData.NumberOfLoginDays % 7 != 0 ? DailyRewardData.NumberOfLoginDays % 7 : 7;
            for (int i = 0; i < rewardBoxes.Length; i++)
            {
                if (i + 1 < day) rewardBoxes[i].SetUnlockState(RewardBoxState.Claimed);
                else if (i + 1 == day)
                {
                    if (!DailyRewardData.IsTodayRewardClaimed)
                        rewardBoxes[i].SetUnlockState(RewardBoxState.ReadyToClaimed);
                    else rewardBoxes[i].SetUnlockState(RewardBoxState.CannotClaimed);
                }
                else rewardBoxes[i].SetUnlockState(RewardBoxState.CannotClaimed);
            }
        }

        public abstract void GetReward(Day day);
    }
}

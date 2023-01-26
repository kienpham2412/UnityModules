using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KPModules.DailyReward
{
    public class DailyRewardController
    {
        private IDailyRewardData dailyRewardData;
        private DailyRewardUI dailyRewardUIPrefab;
        public bool IsNewDay => DateTime.Now.DayOfYear != dailyRewardData.LastLoginTime;
        public bool IsRewardAvailable => IsNewDay && dailyRewardData.IsTodayRewardClaimed;

        public DailyRewardController(IDailyRewardData dailyRewardData, string pathToDailyRewardUI)
        {
            this.dailyRewardData = dailyRewardData;
            dailyRewardUIPrefab = Resources.Load<DailyRewardUI>(pathToDailyRewardUI);
        }

        public DailyRewardController(IDailyRewardData dailyRewardData, DailyRewardUI dailyRewardUIPrefab)
        {
            this.dailyRewardData = dailyRewardData;
            this.dailyRewardUIPrefab = dailyRewardUIPrefab;
        }

        public void UpdateDataForNewDay()
        {
            dailyRewardData.NumberOfLoginDays++;
            dailyRewardData.IsTodayRewardClaimed = false;
            dailyRewardData.LastLoginTime = DateTime.Now.DayOfYear;
        }

        /// <summary>
        /// Instantiate Daily reward UI with lastest login data
        /// </summary>
        /// <param name="setActive">set ui active after instantiate</param>
        /// <returns>A daily reward UI instance</returns>
        public DailyRewardUI InstantiateUI(bool setActive)
        {
            DailyRewardUI dailyRewardUI = GameObject.Instantiate(dailyRewardUIPrefab);
            dailyRewardUI.gameObject.SetActive(setActive);
            dailyRewardUI.DailyRewardData = dailyRewardData;
            return dailyRewardUI;
        }
    }
}


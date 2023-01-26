using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KPModules.DailyReward;

public class GameInstance : MonoBehaviour
{
    private DailyRewardController dailyRewardController;
    private DailyRewardData dailyRewardData;
    public DailyRewardUI dailyRewardPopup;

    private void Awake()
    {
        dailyRewardData = new DailyRewardData();
        dailyRewardController = new DailyRewardController(dailyRewardData, dailyRewardPopup);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (dailyRewardController.IsRewardAvailable)
        {
            dailyRewardController.UpdateDataForNewDay();
            dailyRewardController.InstantiateUI(true);
        }
    }
}

[System.Serializable]
public class DailyRewardData : IDailyRewardData
{
    public int LastestUnlockedChestDay { get; set; }
    public int LastLoginTime { get; set; }
    public int FirstLoginTime { get; set; }
    public int NumberOfLoginDays { get; set; }
    public bool IsTodayRewardClaimed { get; set; }

    public DailyRewardData()
    {
        LastLoginTime = -1;
        FirstLoginTime = -1;
        LastestUnlockedChestDay = 0;
        NumberOfLoginDays = 0;
        IsTodayRewardClaimed = true;
    }
}

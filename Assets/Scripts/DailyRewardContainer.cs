using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KPModules.DailyReward;
using TMPro;

public class DailyRewardContainer : DailyRewardBox
{
    public TMP_Text dayText;
    public Image background;
    public Image checkImage;
    public Image shinningBorder;
    private static Color dark = new Color(0.7f, 0.7f, 0.7f, 1);
    private static Color transaprent = new Color(1, 1, 1, 0);

    private void Start()
    {
        DisplayReward();
    }

    public override void ClickBox()
    {
        throw new System.NotImplementedException();
    }

    public override void DisplayReward()
    {
        dayText.text = $"Day {(int)day + 1}";
    }

    public override void SetUnlockState(RewardBoxState rewardBoxState)
    {
        throw new System.NotImplementedException();
    }
}

using System;
using UnityEngine;

public class DailyQuestService
{
    private const string Key = "DailyRewardDate";

    public void CheckReward()
    {
        string last = PlayerPrefs.GetString(Key, "");

        if (last != DateTime.Now.Date.ToString())
        {
            ServiceLocator.Get<EconomyService>().AddCoins(300);
            PlayerPrefs.SetString(Key, DateTime.Now.Date.ToString());
        }
    }
}
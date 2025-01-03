using GamePush;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AdController : MonoBehaviour
{
    [SerializeField] private UpgradeSystem upgradeSystem;
    [SerializeField] private VolumController volumController;

    // �������� rewarded video
    public void ShowRewarded() => GP_Ads.ShowRewarded("COINS", OnRewardedReward, OnRewardedStart, OnRewardedClose);

    // ������� �����
    private void OnRewardedStart() => Debug.Log("ON REWARDED: START");
    // �������� �������
    private void OnRewardedReward(string value)
    {
        if (value == "COINS")
            AddMoney();

        if (value == "GEMS")
            Debug.Log("ON REWARDED: +5 GEMS");
    }

    // ���������� �����
    private void OnRewardedClose(bool success) => Debug.Log("ON REWARDED: CLOSE");

    //private void Rewarded(int id)
    //{
    //    AddMoney(0);
    //}

    private void AddMoney()
    {
        upgradeSystem.AddMoney(Math.Round(upgradeSystem.MoneyCount / 2));
    }
}

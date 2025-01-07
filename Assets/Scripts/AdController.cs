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
    [SerializeField] private AudioSource mainAudioSource;

    private bool volumeMute = false;

    // �������� rewarded video
    public void ShowRewarded() => GP_Ads.ShowRewarded("COINS", OnRewardedReward, OnRewardedStart, OnRewardedClose);

    // ������� �����
    private void OnRewardedStart()
    {
        if(mainAudioSource.mute)
            volumeMute = true;
        else
            volumController.VolumeOnOff();
    }
    // �������� �������
    private void OnRewardedReward(string value)
    {
        if (value == "COINS")
            AddMoney();

        if (value == "GEMS")
            Debug.Log("ON REWARDED: +5 GEMS");
    }

    // ���������� �����
    private void OnRewardedClose(bool success)
    {
        if (!volumeMute)
            volumController.VolumeOnOff();
    }

    //private void Rewarded(int id)
    //{
    //    AddMoney(0);
    //}

    private void AddMoney()
    {
        upgradeSystem.AddMoney(Math.Round(upgradeSystem.MoneyCount / 2));
    }
}

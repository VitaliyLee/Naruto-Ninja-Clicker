using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using YG;

public class AdController : MonoBehaviour
{
    [SerializeField] private UpgradeSystem upgradeSystem;
    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;
    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

    private void Rewarded(int id)
    {
        AddMoney(0);
    }

    private void AddMoney(int id)
    {
        upgradeSystem.AddMoney(Math.Round(upgradeSystem.MoneyCount / 2));
    }
}

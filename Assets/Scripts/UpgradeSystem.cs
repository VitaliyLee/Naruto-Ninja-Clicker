using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] private BossDamage bossDamage;
    [SerializeField] private TextMeshProUGUI money;
    [SerializeField] private Image backgroundImage;

    public List<AudioSource> bySounds;
    [SerializeField] private AudioSource mainAudioSource;

    [Space(10)]
    [SerializeField] private List<UpgradeStats> upgradeList;
    [SerializeField] public List<ShopSlotStats> backgroundList;

    private double moneyCount;

    [Space(10)]
    public ShopSlotStats shopSlotRemember;
    public double MoneyCount => moneyCount;

    private void Start()
    {
        SetMoney();
        CheckObjectAccess();
    }

    public void ByBackground(ShopSlotStats shopSlotStats)
    {
        if (DeductMoney(shopSlotStats.backgroundCost))
        {
            shopSlotRemember = shopSlotStats;
            backgroundImage.sprite = shopSlotStats.backgroundImage.sprite;
            mainAudioSource.clip = shopSlotStats.audioClip;

            mainAudioSource.Play();

            shopSlotStats.byBtnText.text = "Выбрать";
            shopSlotStats.backgroundCost = 0;
        }
    }

    public void ByDamageUpgrade(UpgradeStats upgradeStats) 
    {
        if (DeductMoney(upgradeStats.upgradeCost))
            bossDamage.AddDmg(upgradeStats.addedDamage);
    }
    public void ByDamagePerSecond(UpgradeStats upgradeStats) 
    {
        if(DeductMoney(upgradeStats.upgradeCost))
            bossDamage.AddDmgPerSec(upgradeStats.addedDamage);
    }

    public void AddMoney(double money)
    {
        moneyCount += money;
        SetMoney();

        CheckObjectAccess();
    }

    private bool DeductMoney(float money)
    {
        if (moneyCount >= money)
        {
            moneyCount -= money;
            SetMoney();

            for (int i = 0; i < bySounds.Count; i++)
                bySounds[i].Play();

            CheckObjectAccess();

            return true;
        }

        return false;
    }

    private void SetMoney()
    {
        if(moneyCount >= 1000)
        {
            double tmpMoney = moneyCount / 1000;
            money.text = $"{Math.Round(tmpMoney, 2)}K";
        }

        else
            money.text = moneyCount.ToString();

        if (moneyCount >= 1000000)
        {
            double tmpMoney = moneyCount / 1000000;
            money.text = $"{Math.Round(tmpMoney, 2)}M";
        }

        if (moneyCount >= 1000000000)
        {
            double tmpMoney = moneyCount / 1000000000;
            money.text = $"{Math.Round(tmpMoney, 2)}B";
        }

        if (moneyCount >= 1000000000000)
        {
            double tmpMoney = moneyCount / 1000000000000;
            money.text = $"{Math.Round(tmpMoney, 2)}t";
        }

        if (moneyCount >= 1000000000000000)
        {
            double tmpMoney = moneyCount / 1000000000000000;
            money.text = $"{Math.Round(tmpMoney, 2)}q";
        }

        if (moneyCount >= 1000000000000000000)
        {
            double tmpMoney = moneyCount / 1000000000000000000;
            money.text = $"{Math.Round(tmpMoney, 2)}Q";
        }
    }

    private void CheckObjectAccess()
    {
        for (int i = 0; i < upgradeList.Count; i++) 
        {
            if (upgradeList[i].upgradeCost <= moneyCount)
                upgradeList[i].upgradeButton.interactable = true;
            else
                upgradeList[i].upgradeButton.interactable = false;
        }

        for (int i = 0; i < backgroundList.Count; i++)
        {
            if(backgroundList[i].backgroundCost == 0)
                backgroundList[i].byBtnText.text = "Выбрать";
            if (backgroundList[i].backgroundCost <= moneyCount)
                backgroundList[i].byButton.interactable = true;
            else
                backgroundList[i].byButton.interactable = false;
        }
    }
}

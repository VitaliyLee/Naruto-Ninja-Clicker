using GamePush;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Saver : MonoBehaviour
{
    [SerializeField] UpgradeSystem upgradeSystem;
    [SerializeField] BossDamage bossDamage;
    [SerializeField] CreateBoss createBoss;
    [SerializeField] Slider healthSlider;

    [Space(30)]
    [SerializeField] InputField integerText;
    [SerializeField] InputField stringifyText;
    [SerializeField] Text systemSavesText;
    [SerializeField] Toggle[] booleanArrayToggle;

    //private void OnEnable() => GP_Storage.OnGetValue += GetLoad;
    //private void OnDisable() => GP_Storage.OnGetValue -= GetLoad;

    private void OnEnable()
    {
        GP_Init.OnReady += GetLoad;
        GP_Init.OnReady += InvokeSaver;
    }

    private void OnDisable()
    {
        GP_Init.OnReady -= GetLoad;
        GP_Init.OnReady -= InvokeSaver;
    }

    private void Start()
    {
        //InvokeRepeating("Save", 0, 5);
        //Save();
        //GetLoad();
    }

    private void OnApplicationQuit()
    {
        //Save();
    }

    //public List<ShopSlotStats> shopStats;

    //Используемые ключи и их значение
    //allMoney - колличество накликанных денег
    //moneyInSecond - колличество денег (авто кликов) в секунду
    //moneyClick - денег за клик
    //bossIndex - индекс босса (какой босс должен появиться)
    //level - текущий уровень по счету (к боссу не завязать, тк реализация механики боссов не позволяет, а менять лень)
    //levelProgress - прогресс шкалы босса (шкалы урона босса)
    //bgCostData - список цен на задний фон в магазине

    private void InvokeSaver()
    {
        InvokeRepeating("Save", 0, 5);
    }

    //Сохранение данных
    public void Save()
    {
        GP_Player.Set("allMoney", (float)upgradeSystem.MoneyCount);
        GP_Player.Set("moneyInSecond", bossDamage.MoneyPerSecond);
        GP_Player.Set("moneyClick", bossDamage.MoneyClick);

        GP_Player.Set("bossIndex", createBoss.bossIndex);
        GP_Player.Set("level", createBoss.level);
        GP_Player.Set("levelProgress", healthSlider.value);

        string bgCostSaveData = "";
        for (int i = 0; i < upgradeSystem.backgroundList.Count; i++)
        {
            if (i > 0)
                bgCostSaveData += $",{upgradeSystem.backgroundList[i].backgroundCost}";

            bgCostSaveData += $"{upgradeSystem.backgroundList[i].backgroundCost}";
        }

        GP_Player.Set("oneBgCost", upgradeSystem.backgroundList[0].backgroundCost);
        GP_Player.Set("twoBgCost", upgradeSystem.backgroundList[1].backgroundCost);
        GP_Player.Set("threeBgCost", upgradeSystem.backgroundList[2].backgroundCost);
        GP_Player.Set("fourBgCost", upgradeSystem.backgroundList[3].backgroundCost);
        GP_Player.Set("fiveBgCost", upgradeSystem.backgroundList[4].backgroundCost);
        GP_Player.Set("sixBgCost", upgradeSystem.backgroundList[5].backgroundCost);
        GP_Player.Set("sevenBgCost", upgradeSystem.backgroundList[6].backgroundCost);
        GP_Player.Set("eightBgCost", upgradeSystem.backgroundList[7].backgroundCost);

        GP_Player.Sync(storage: SyncStorageType.preffered);
        //GP_Storage.Set("shopSlot", upgradeSystem.shopSlotRemember);

        //Debug.Log(bgCostSaveData);
    }

    //Загрузка данных
    private void GetLoad()
    {
        upgradeSystem.AddMoney(GP_Player.GetFloat("allMoney"));
        bossDamage.AddDmgPerSec(GP_Player.GetFloat("moneyInSecond"));

        float dmg = GP_Player.GetFloat("moneyClick");

        if (dmg > 1)
            bossDamage.AddDmg(dmg - 1);
        else
            bossDamage.AddDmg(dmg);

        createBoss.SetLevelData(GP_Player.GetInt("level"), GP_Player.GetFloat("levelProgress"), GP_Player.GetInt("bossIndex"));
        //createBoss.bossIndex = GP_Player.GetInt("bossIndex");
        //createBoss.level = GP_Player.GetInt("level");
        //createBoss.levelProgress = GP_Player.GetFloat("levelProgress");

        List<int> bgCosts = new List<int>
        {
            GP_Player.GetInt("oneBgCost"),
            GP_Player.GetInt("twoBgCost"),
            GP_Player.GetInt("threeBgCost"),
            GP_Player.GetInt("fourBgCost"),
            GP_Player.GetInt("fiveBgCost"),
            GP_Player.GetInt("sixBgCost"),
            GP_Player.GetInt("sevenBgCost"),
            GP_Player.GetInt("eightBgCost")
        };

        upgradeSystem.SetBgCost(bgCosts);
    }
}

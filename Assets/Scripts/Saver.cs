using GamePush;
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

    private void Awake()
    {
        GetLoad();
    }

    private void Start()
    {
        InvokeRepeating("Save", 0, 5);
    }

    //public List<ShopSlotStats> shopStats;

    public void Save()
    {
        GP_Storage.SetStorage(SaveStorageType.platform);
        GP_Storage.Set("allMoney", upgradeSystem.MoneyCount);
        //GP_Storage.Set("moneyInSecond", bossDamage.MoneyPerSecond);
        //GP_Storage.Set("moneyClick", bossDamage.MoneyClick);
        //GP_Storage.Set("bossIndex", createBoss.bossIndex);
        //GP_Storage.Set("level", createBoss.level);
        //GP_Storage.Set("levelProgress", healthSlider.value);
        //GP_Storage.Set("shopSlot", upgradeSystem.shopSlotRemember);

        //for (int i = 0; i < upgradeSystem.backgroundList.Count; i++)
        //    GP_Storage.Set($"backCost{i}", upgradeSystem.backgroundList[i].backgroundCost);

        //YandexGame.savesData.allMoney = upgradeSystem.MoneyCount;

        //YandexGame.savesData.moneyInSecond = bossDamage.MoneyPerSecond;
        //YandexGame.savesData.moneyClick = bossDamage.MoneyClick;

        //YandexGame.savesData.bossIndex = createBoss.bossIndex;
        //YandexGame.savesData.level = createBoss.level;
        //YandexGame.savesData.levelProgress = healthSlider.value;

        //YandexGame.savesData.shopSlot = upgradeSystem.shopSlotRemember;

        //for (int i = 0; i < upgradeSystem.backgroundList.Count; i++)
        //    YandexGame.savesData.backCost[i] = upgradeSystem.backgroundList[i].backgroundCost;
        
        //YandexGame.SaveProgress();

        Debug.Log("Game is saved!");
    }

    //public void Load() => YandexGame.LoadProgress();

    public void GetLoad(/*StorageField storage*/)
    {
        GP_Storage.SetStorage(SaveStorageType.platform);
        Debug.Log("GetLoad colling");
        GP_Storage.Get("allMoney", value => { upgradeSystem.AddMoney(value is double doubleValue ? doubleValue : 0); });
        //upgradeSystem.AddMoney(YandexGame.savesData.allMoney);

        //GP_Storage.Get("moneyInSecond", value => { bossDamage.AddDmgPerSec(value is float floatValue ? floatValue : 0); });
        ////bossDamage.AddDmgPerSec(YandexGame.savesData.moneyInSecond);

        //float dmg = 0;
        //GP_Storage.Get("moneyClick", value => { dmg = value is float floatValue ? floatValue : 0; });

        //if (dmg > 1)
        //    bossDamage.AddDmg(dmg - 1);

        //else
        //    bossDamage.AddDmg(dmg);

        //GP_Storage.Get("bossIndex", value => { createBoss.bossIndex = value is int intValue ? intValue : 0; });
        ////createBoss.bossIndex = YandexGame.savesData.bossIndex;

        //GP_Storage.Get("level", value => { createBoss.level = value is int intValue ? intValue : 0; });
        ////createBoss.level = YandexGame.savesData.level;

        //GP_Storage.Get("levelProgress", value => { createBoss.levelProgress = value is float floatValue ? floatValue : 0; });
        ////createBoss.levelProgress = YandexGame.savesData.levelProgress;

        //ShopSlotStats shopSlot = new ShopSlotStats();
        //GP_Storage.Get("shopSlot", value => { shopSlot = value is ShopSlotStats ShopSlotStatsValue ? ShopSlotStatsValue : null; });

        //if (shopSlot != null)
        //    upgradeSystem.ByBackground(shopSlot);

        //for (int i = 0; i < upgradeSystem.backgroundList.Count; i++)
        //    GP_Storage.Get($"backCost{i}", value => { upgradeSystem.backgroundList[i].backgroundCost = value is int intValue ? intValue : 0; });
        //    //upgradeSystem.backgroundList[i].backgroundCost = YandexGame.savesData.backCost[i];

        Debug.Log("Game is loaded!");

        //integerText.text = string.Empty;
        //stringifyText.text = string.Empty;
        //
        //integerText.placeholder.GetComponent<Text>().text = YandexGame.savesData.money.ToString();
        //stringifyText.placeholder.GetComponent<Text>().text = YandexGame.savesData.newPlayerName;
        //
        //for (int i = 0; i < booleanArrayToggle.Length; i++)
        //    booleanArrayToggle[i].isOn = YandexGame.savesData.openLevels[i];
        //
        //systemSavesText.text = $"Language - {YandexGame.savesData.language}\n" +
        //$"First Session - {YandexGame.savesData.isFirstSession}\n" +
        //$"Prompt Done - {YandexGame.savesData.promptDone}\n";
    }
}

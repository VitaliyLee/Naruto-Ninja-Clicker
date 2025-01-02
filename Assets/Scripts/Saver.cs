using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

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

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Awake()
    {
        if (YandexGame.SDKEnabled)
            GetLoad();
    }

    private void Start()
    {
        InvokeRepeating("Save", 0, 5);
    }

    //public List<ShopSlotStats> shopStats;

    public void Save()
    {
        YandexGame.savesData.allMoney = upgradeSystem.MoneyCount;

        YandexGame.savesData.moneyInSecond = bossDamage.MoneyPerSecond;
        YandexGame.savesData.moneyClick = bossDamage.MoneyClick;

        YandexGame.savesData.bossIndex = createBoss.bossIndex;
        YandexGame.savesData.level = createBoss.level;
        YandexGame.savesData.levelProgress = healthSlider.value;

        YandexGame.savesData.shopSlot = upgradeSystem.shopSlotRemember;

        for (int i = 0; i < upgradeSystem.backgroundList.Count; i++)
            YandexGame.savesData.backCost[i] = upgradeSystem.backgroundList[i].backgroundCost;
        
        YandexGame.SaveProgress();

        Debug.Log("Game is saved!");
    }

    public void Load() => YandexGame.LoadProgress();

    public void GetLoad()
    {
        Debug.Log("GetLoad colling");
        upgradeSystem.AddMoney(YandexGame.savesData.allMoney);

        bossDamage.AddDmgPerSec(YandexGame.savesData.moneyInSecond);

        if(YandexGame.savesData.moneyClick > 1)
            bossDamage.AddDmg(YandexGame.savesData.moneyClick - 1);

        else
            bossDamage.AddDmg(YandexGame.savesData.moneyClick);

        createBoss.bossIndex = YandexGame.savesData.bossIndex;
        createBoss.level = YandexGame.savesData.level;
        createBoss.levelProgress = YandexGame.savesData.levelProgress;

        if(YandexGame.savesData.shopSlot != null)
            upgradeSystem.ByBackground(YandexGame.savesData.shopSlot);

        for (int i = 0; i < upgradeSystem.backgroundList.Count; i++)
            upgradeSystem.backgroundList[i].backgroundCost = YandexGame.savesData.backCost[i];

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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossDamage : MonoBehaviour
{
    [SerializeField] private UpgradeSystem upgradeSystem;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI moneyPerSecondTxt;
    [SerializeField] private GameObject clickEffect;

    [Space(10)]
    [SerializeField] private float damage;
    [SerializeField] private float damagePerSecond;

    public float MoneyClick => damage;
    public float MoneyPerSecond => damagePerSecond;

    private List<GameObject> clickEffectList;
    private int poolWarm = 20;
    private static int index = 0;

    private void Start()
    {
        clickEffectList = new List<GameObject>();

        for (int i = 0; i < poolWarm; i++) 
        {
            GameObject gameObject = Instantiate(clickEffect, new Vector3(0, 0, 0), Quaternion.identity);
            gameObject.SetActive(false);

            clickEffectList.Add(gameObject);
        }

        InvokeRepeating("GetDamagePerSecond", 0, 1);
    }

    private void ActiveEffect(Vector2 effectPosition)
    {
        index %= clickEffectList.Count;

        if (damage >= 1000)
        {
            double tmpMoney = damage / 1000;
            clickEffectList[index].gameObject.GetComponent<EffectStats>().effectTxt.text = $"+{Math.Round(tmpMoney, 2)}K";
        }

        else
            clickEffectList[index].gameObject.GetComponent<EffectStats>().effectTxt.text = $"+{damage}";

        if (damage >= 1000000)
        {
            double tmpMoney = damage / 1000000;
            clickEffectList[index].gameObject.GetComponent<EffectStats>().effectTxt.text = $"+{Math.Round(tmpMoney, 2)}M";
        }

        if (damage >= 1000000000)
        {
            double tmpMoney = damage / 1000000000;
            clickEffectList[index].gameObject.GetComponent<EffectStats>().effectTxt.text = $"+{Math.Round(tmpMoney, 2)}B";
        }

        if (damage >= 1000000000000)
        {
            double tmpMoney = damage / 1000000000000;
            clickEffectList[index].gameObject.GetComponent<EffectStats>().effectTxt.text = $"+{Math.Round(tmpMoney, 2)}t";
        }

        if (damage >= 1000000000000000)
        {
            double tmpMoney = damage / 1000000000000000;
            clickEffectList[index].gameObject.GetComponent<EffectStats>().effectTxt.text = $"+{Math.Round(tmpMoney, 2)}q";
        }

        if (damage >= 1000000000000000000)
        {
            double tmpMoney = damage / 1000000000000000000;
            clickEffectList[index].gameObject.GetComponent<EffectStats>().effectTxt.text = $"+{Math.Round(tmpMoney, 2)}Q";
        }

        clickEffectList[index].gameObject.SetActive(true);
        clickEffectList[index].transform.position = effectPosition;

        index++;
    }

    public void GetDamage()
    {
        healthSlider.value += 1;
        upgradeSystem.AddMoney(damage);

        //Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ActiveEffect(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public void GetDamagePerSecond()
    {
        //healthSlider.value += damagePerSecond;
        upgradeSystem.AddMoney(damagePerSecond);
    }

    public void AddDmg(float damag)
    {
        this.damage += damag;
    }

    public void AddDmgPerSec(float damag)
    {
        damagePerSecond += damag;

        if (damagePerSecond >= 1000)
        {
            double tmpMoney = damagePerSecond / 1000;
            moneyPerSecondTxt.text = $"+{Math.Round(tmpMoney, 2)}K/сек.";
        }

        else
            moneyPerSecondTxt.text = $"+{damagePerSecond}/сек.";

        if (damagePerSecond >= 1000000)
        {
            double tmpMoney = damagePerSecond / 1000000;
            moneyPerSecondTxt.text = $"+{Math.Round(tmpMoney, 2)}M/сек.";
        }

        if (damagePerSecond >= 1000000000)
        {
            double tmpMoney = damagePerSecond / 1000000000;
            moneyPerSecondTxt.text = $"+{Math.Round(tmpMoney, 2)}B/сек.";
        }

        if (damagePerSecond >= 1000000000000)
        {
            double tmpMoney = damagePerSecond / 1000000000000;
            moneyPerSecondTxt.text = $"+{Math.Round(tmpMoney, 2)}t/сек.";
        }

        if (damagePerSecond >= 1000000000000000)
        {
            double tmpMoney = damagePerSecond / 1000000000000000;
            moneyPerSecondTxt.text = $"+{Math.Round(tmpMoney, 2)}q/сек.";
        }

        if (damagePerSecond >= 1000000000000000000)
        {
            double tmpMoney = damagePerSecond / 1000000000000000000;
            moneyPerSecondTxt.text = $"+{Math.Round(tmpMoney, 2)}Q/сек.";
        }
    }

    public void Decrease(RectTransform rectTransformBtn) 
        { rectTransformBtn.localScale = new Vector3 (0.95f, 0.95f, 1f);}

    public void Increase(RectTransform rectTransformBtn)
        { rectTransformBtn.localScale = new Vector3(1f, 1f, 1f); }
}

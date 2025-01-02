using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateBoss : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private int firstBossHealth;
    [SerializeField] private TextMeshProUGUI levelText;

    [Space(10)]
    [SerializeField] private Image bossBodyImage;
    [SerializeField] private List<Sprite> bossBodyImg;

    public int level = 0;
    public float levelProgress = 0;
    public int bossIndex = 0;

    private void Start()
    {
        NewBoss();
    }

    private void Update()
    {
        if (healthSlider.value >= healthSlider.maxValue)
        {
            levelProgress = 0;
            level++;
            bossIndex++;

            NewBoss();
        }
    }

    private void NewBoss() 
    {
        if (bossIndex > bossBodyImg.Count - 1)
            bossIndex = 0;

        bossBodyImage.sprite = bossBodyImg[bossIndex];

        healthSlider.maxValue = firstBossHealth * (level + 1);
        healthSlider.value = levelProgress;

        levelText.text = $"Уровень {level + 1}";
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EffectStats : MonoBehaviour
{
    public SpriteRenderer effectSprite;
    public TextMeshProUGUI effectTxt;

    public void DisactivateObject()
    {
        this.gameObject.SetActive(false);
    }
}

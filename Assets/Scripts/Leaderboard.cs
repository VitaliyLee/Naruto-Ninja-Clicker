using GamePush;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public void Open()
    {
        GP_Leaderboard.Open("allMoney", Order.DESC, 10, 1, WithMe.none, "allMoney", "allMoney");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AddCoins : MonoBehaviour
{
    public Data data;

    public void AddCoin()
    {
        if (data.coins < data.lvlNumber * 130)
        {
            data.coins += (data.lvlNumber * 130) - data.coins;
        }
        else
        {
            data.coins += 100;
        }
        SaveAndLoad.Instance.Save();

    }
}

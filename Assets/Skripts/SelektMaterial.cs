using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelektMaterial : MonoBehaviour
{
    public Interface iF;
    public AudioClip yes, no;
    public int index;
    public Text tsena;
    public int num;
    public Data data;
    public void Selekt()
    {
        data.cena = index;
        if (data.coins >= index)
        {
            AudioPlayer.regit.Play(yes);
            data.num = num;
        }
        else
        {
            iF.AndCoins();
            AudioPlayer.regit.Play(no);
        }
    }
    private void Start()
    {
        tsena.text = "" + index;
    }
}

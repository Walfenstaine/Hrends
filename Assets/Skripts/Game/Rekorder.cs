using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InstantGamesBridge;
public class Rekorder : MonoBehaviour
{
    public Text lev, rec;
    public Data data;
    [SerializeField] private Language lvl;
    [SerializeField] private Language record;
    void Start()
    {
        if (Bridge.platform.language == "ru")
        {
            lev.text =  lvl.ru + ":  "+ data.lvlNumber;
            rec.text = record.ru + ":  " + data.record;
        }
        else
        {
            lev.text = lvl.en + ":  " + data.lvlNumber;
            rec.text = record.en + ":  " + data.record;
        }
        
    }
}

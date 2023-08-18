using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Subtitres : MonoBehaviour
{
    public float interval = 3.0f;
    public Image fon, fon1;
    public Text titres, titres1;
    public string subtitres { get; set; }
    public float timer { get; set; }
    public static Subtitres regit { get; set; }

    void Awake()
    {        
        if (regit == null)
        {
            regit = this;
        }
        else
        {
            Destroy(this);
        }
        OffTitres();
    }
    void OnDestroy()
    {
        regit = null;
    }
    void OnTitres()
    {
        titres.text = subtitres;
        fon.enabled = true;
        titres1.text = subtitres;
        fon1.enabled = true;
    }
    void OffTitres()
    {
        subtitres = "";
        titres.text = subtitres;
        fon.enabled = false;
        titres1.text = subtitres;
        fon1.enabled = false;
    }
    void Update()
    {
        if (timer >= interval)
        {
            OffTitres();
            timer = 0;
        }
        if (subtitres != "")
        {
            OnTitres();
            timer += Time.deltaTime;
        }
    }
}

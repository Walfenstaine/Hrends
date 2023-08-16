using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using pEventBus;
using InstantGamesBridge;

public class AutoSave : MonoBehaviour
{
    public GameObject adsPanel;
    public Text adsPanelText;
    public Language adsPanelL;

    private float scale = 1;


    string adsPanelString;



    void Start()
    {
        if (Bridge.platform.language == "ru")
        {
            adsPanelString = adsPanelL.ru;
        }
        else
        {
            adsPanelString = adsPanelL.en;
        }
    }







    private void Show()
    {
        StartCoroutine(ShowEnum());
    }

    private IEnumerator ShowEnum()
    {
        SaveAndLoad.Instance.isAds = true;
        scale = Time.timeScale;
        Time.timeScale = 0;
        adsPanel.SetActive(true);
        adsPanelText.text = adsPanelString + " 3";
        yield return new WaitForSecondsRealtime(0.5f);
        adsPanelText.text = adsPanelString + " 2";
        yield return new WaitForSecondsRealtime(0.5f);
        adsPanelText.text = adsPanelString + " 1";
        yield return new WaitForSecondsRealtime(0.4f);
        Time.timeScale = scale;
        EventBus<ShowInterAds>.Raise(new ShowInterAds()
        {

        });
        yield return new WaitForSecondsRealtime(0.4f);
        adsPanel.SetActive(false);
        
    }

    void OnEnable()
    {
        Events.OnShow += Show;
    }

    void OnDisable()
    {
        Events.OnShow -= Show;
    }
}
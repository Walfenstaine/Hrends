using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if !UNITY_EDITOR
using System;
using System.Runtime.InteropServices;
#endif

public class SoundButton : MonoBehaviour
{

    #if !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern string InstantGamesBridgeMuteSound();
    [DllImport("__Internal")]
    private static extern string InstantGamesBridgeUnMuteSound();
    #endif


    public Sprite soundIsOn, soundIsOff;
    public Data data;
    public AudioSource sorse;
    public Button butt;
    public Image im;

    bool sourseState;

    private void Awake()
    {
       sourseState = data.soundOn;
       sorse.mute = !data.soundOn;
       SetSprite(data.soundOn);
    }

    private void SetSprite(bool stateTemp)
    {
        if (stateTemp)
        {
            im.sprite = soundIsOn;
        }
        else
        {
            im.sprite = soundIsOff;
        }
    }

    private void OnEnable()
    {
        butt.onClick.AddListener(Change);
    }

    private void OnDisable()
    {
        butt.onClick.RemoveListener(Change);
    }

    private void Change()
    {
        data.soundOn = !data.soundOn;
        SetSprite(data.soundOn);
        sorse.mute = !data.soundOn;

        #if !UNITY_EDITOR
        if (!data.soundOn)
        {
            InstantGamesBridgeMuteSound();
        }
        else
        {
            InstantGamesBridgeUnMuteSound();
        }                      
        #endif
    }
}
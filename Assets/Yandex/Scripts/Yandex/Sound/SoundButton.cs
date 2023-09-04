using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
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
        Events.OnUnHide += UnHide;
        Events.OnHide += Hide;
    }

    private void OnDisable()
    {
        butt.onClick.RemoveListener(Change);
        Events.OnUnHide -= UnHide;
        Events.OnHide -= Hide;
    }

    private void Change()
    {
        data.soundOn = !data.soundOn;
        SetSprite(data.soundOn);
        sorse.mute = !data.soundOn;
    }




    void Hide()
    {
            sourseState = data.soundOn;
            data.soundOn = false;
            SetSprite(data.soundOn);
            sorse.mute = !data.soundOn;

    }

    void UnHide()
    {
        data.soundOn = sourseState;
        SetSprite(data.soundOn);
        sorse.mute = !data.soundOn;
    }

    void OnApplicationPause(bool isPaused)
    {
        Debug.Log("pause");
    }
}
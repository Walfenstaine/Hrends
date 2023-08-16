using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge;
using InstantGamesBridge.Modules.Advertisement;
using UnityEngine.Events;

public class Reward : MonoBehaviour
{
    public Data data;
    public AudioSource sorse;
    public UnityEvent OnReward;

    private bool isRewarded;


    void OnEnable()
    {
        Bridge.advertisement.rewardedStateChanged += MyReward;
        isRewarded = false;
    }

    void OnDisable()
    {
        Bridge.advertisement.rewardedStateChanged -= MyReward;
    }

    public void ShowReward()
    {
        Bridge.advertisement.ShowRewarded(success =>
        {

        });
    }
          
    void MyReward(RewardedState state)
    {

        if (state == RewardedState.Opened)
        {
            isRewarded = false;
            sorse.mute = true;
            SaveAndLoad.Instance.isAds = true;

        }

        if (state == RewardedState.Rewarded)
        {
            isRewarded = true;
        }

        if (state == RewardedState.Closed)
        {
            sorse.mute = !data.soundOn;

            if (isRewarded)
            {
                isRewarded = false;
                OnReward.Invoke();
            }
            SaveAndLoad.Instance.isAds = false;
        }
    }
}
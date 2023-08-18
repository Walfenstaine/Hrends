using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge;
using InstantGamesBridge.Modules.Leaderboard;
using InstantGamesBridge.Modules.Player;
using pEventBus;


public struct OnLoadIsComplete : IEvent
{

}


public class SaveAndLoad : MonoBehaviour
{
    public static SaveAndLoad Instance { get; private set; }

    public bool isFirstLoad;

    public bool isAds = false;
    
    [SerializeField] private Data myData;
    [SerializeField] private string id;

    private float time, record;

    public int count = 0;


    public void Load()
    {
        StartCoroutine(AutoShowEnum());
        Bridge.storage.Get(id, OnGetCompleted);
    }

    public void Save()
    {
        if (Time.unscaledTime >= time + 1f)
        {
            time = Time.unscaledTime;
            string data = JsonUtility.ToJson(myData);
            Bridge.storage.Set(id, data, success =>
            {
                if(record < myData.record)
                {
                    record = myData.record;
                    SetBoard();
                }
            });
        }
    }


    private void SetBoard()
    {
        var _yandexLeaderboardNameInput = "LEADER1";
        Bridge.leaderboard.SetScore(
            success =>
            {

            },
            new SetScoreYandexOptions(myData.record, _yandexLeaderboardNameInput));
    }


    public void Reset()
    {
        SetInitValue();
        Bridge.storage.Delete(id, success =>
        {
        });
    }

    void SetInitValue()
    {
        myData.record = 0;

        myData.lvlNumber = 1;
        myData.maxLvlNumber = 1;
        myData.soundOn = true;
    }


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        time = Time.unscaledTime - 1f;
        record = 0;
        isFirstLoad = true;
    }

    private void OnGetCompleted(bool success, string data)
    {
        if (success && data != null)
        {
            JsonUtility.FromJsonOverwrite(data, myData);
        }
        else
        {
            SetInitValue();
        }

        EventBus<OnLoadIsComplete>.Raise(new OnLoadIsComplete()
        {

        });
    }

    private IEnumerator AutoShowEnum()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(80f);
            if (!isAds) {
                Events.OnShow?.Invoke();
            }
            count++;
            if (count == 4)
            {
                Events.OnGameButtonAppear?.Invoke();
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public AudioClip skrim, winer;
    public Data data;
    // public Text coins;
   [HideInInspector] public Sprite skrimer;

    public GameObject gamover,andLevel, game, menue, lvl;
    public static Interface rid { get; set; }
    void Awake()
    {
        Menue();
        if (rid == null)
        {
            rid = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        if(!SaveAndLoad.Instance.isFirstLoad)
        {
            SaveAndLoad.Instance.isFirstLoad = true;
            Game();
        }
    }



    void OnDestroy()
    {
        rid = null;
    }


    public void Rspune()
    {
        Events.OnDie?.Invoke();
        Game();
    }
    public void Gamover()
    {
        if (Time.timeScale > 0)
        {
            SoundPlayer.regit.sorse.PlayOneShot(skrim);
            Time.timeScale = 0;
        }
        gamover.SetActive(true);
        game.SetActive(false);
        andLevel.SetActive(false);
    }



    public void Game()
    {
        Time.timeScale = 1;
        menue.SetActive(false);
        gamover.SetActive(false);
        game.SetActive(true);
        andLevel.SetActive(false);
        lvl.SetActive(false);
    }
    public void LvlSelect()
    {
        Time.timeScale = 0;
        menue.SetActive(false);
        gamover.SetActive(false);
        game.SetActive(false);
        andLevel.SetActive(false);
        lvl.SetActive(true);
    }
    public void Menue()
    {
        Time.timeScale = 0;
        menue.SetActive(true);
        gamover.SetActive(false);
        game.SetActive(false);
        andLevel.SetActive(false);
        lvl.SetActive(false);
    }
    public void AndLevel()
    {
        if (Time.timeScale > 0)
        {
            SoundPlayer.regit.sorse.PlayOneShot(winer);
            Time.timeScale = 0;
        }
        gamover.SetActive(false);
        game.SetActive(false);
        andLevel.SetActive(true);
        lvl.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if !UNITY_EDITOR
 using System;
 using System.Runtime.InteropServices;
#endif

public class Interface : MonoBehaviour
{

    #if !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern string InstantGamesBridgeStartSound();
    #endif

    public AudioClip skrim, winer;
    public Data data;
    [HideInInspector] public Sprite skrimer;

    public enum GameState {menu,die,game, lvlSelect, win};
    public GameState gameState = GameState.menu;

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





    void OnDestroy()
    {
        rid = null;
    }


    public void Rspune()
    {
        Game();
    }

    public void Gamover()
    {
        gameState = GameState.die;
        Events.OnDie?.Invoke();
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
        gameState = GameState.game;
        Time.timeScale = 1;
        menue.SetActive(false);
        gamover.SetActive(false);
        game.SetActive(true);
        andLevel.SetActive(false);
        lvl.SetActive(false);
        #if !UNITY_EDITOR
        InstantGamesBridgeStartSound();
        #endif
    }
    public void LvlSelect()
    {
        gameState = GameState.lvlSelect;
        Time.timeScale = 0;
        menue.SetActive(false);
        gamover.SetActive(false);
        game.SetActive(false);
        andLevel.SetActive(false);
        lvl.SetActive(true);
    }
    public void Menue()
    {
        gameState = GameState.menu;
        Time.timeScale = 0;
        menue.SetActive(true);
        gamover.SetActive(false);
        game.SetActive(false);
        andLevel.SetActive(false);
        lvl.SetActive(false);
    }
    public void AndLevel()
    {
        gameState = GameState.win;
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


    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            SetPauseState();
        }
    }

    void Hide()
    {
        SetPauseState();
    }

    void OnEnable()
    {
        Events.OnHide += Hide;
    }

    void OnDisable()
    {
        Events.OnHide -= Hide;
    }

    void SetPauseState()
    {
        if (gameState == GameState.game)
        {
            Menue();
        }
    }

}

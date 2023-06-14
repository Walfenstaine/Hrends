using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public Data data;
   // public Text coins;
    public GameObject gamover,andLevel, game, menue;

    private void Start()
    {
        Menue();
    }
    public void Gamover()
    {
        Time.timeScale = 0;
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
    }
    public void Menue()
    {
        Time.timeScale = 0;
        menue.SetActive(true);
        gamover.SetActive(false);
        game.SetActive(false);
        andLevel.SetActive(false);
    }
    public void AndLevel()
    {
        Time.timeScale = 0;
        gamover.SetActive(false);
        game.SetActive(false);
        andLevel.SetActive(true);
    }
    void Update()
    {
        //coins.text = "" + data.coins;
    }
}

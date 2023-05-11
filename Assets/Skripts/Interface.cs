using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public MeshCollider greed;
    public Data data;
    public Text coins;
    public bool ded;
    public GameObject gamover,tools,andLevel, andCoins, lvlSelect, obuchenie;

    private void Start()
    {
        Game();
    }
    public void LVLselect()
    {
        if (data.record == 0 && obuchenie != null)
        {
            obuchenie.SetActive(false);
        }
        greed.enabled = false;
        gamover.SetActive(false);
        tools.SetActive(false);
        andLevel.SetActive(false);
        andCoins.SetActive(false);
        lvlSelect.SetActive(true);
    }
    public void Gamover()
    {
        greed.enabled = false;
        if (data.record == 0)
        {
            obuchenie.SetActive(false);
        }
        ded = true;
        gamover.SetActive(true);
        tools.SetActive(false);
        andCoins.SetActive(false);
        andLevel.SetActive(false);
        lvlSelect.SetActive(false);
    }
    public void AndCoins()
    {
        greed.enabled = false;
        if (data.record == 0 && obuchenie != null)
        {
            obuchenie.SetActive(false);
        }
        gamover.SetActive(false);
        tools.SetActive(false);
        andLevel.SetActive(false);
        andCoins.SetActive(true);
        lvlSelect.SetActive(false);
    }
    public void Game()
    {
        greed.enabled = true;
        if (data.record == 0 && obuchenie != null)
        {
            obuchenie.SetActive(true);
        }
        gamover.SetActive(false);
        tools.SetActive(true);
        andLevel.SetActive(false);
        andCoins.SetActive(false);
        lvlSelect.SetActive(false);
    }
    public void AndLevel()
    {
        greed.enabled = false;
        if (!ded)
        {
            gamover.SetActive(false);
            tools.SetActive(false);
            andLevel.SetActive(true);
            andCoins.SetActive(false);
            lvlSelect.SetActive(false);
            if (data.record == 0 && obuchenie != null)
            {
                obuchenie.SetActive(false);
            }
        }
    }
    void Update()
    {
        coins.text = "" + data.coins;
    }
}

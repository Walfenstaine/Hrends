using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LVLButton : MonoBehaviour
{

    public int lvlNumber = 1;
    public Button lVLButton;
    public GameObject lockImage;
    public Text levelText;


    public Data data;

    void Awake()
    {
        levelText.text = $"{lvlNumber}";
    }

    void OnEnable()
    {
        lVLButton.enabled = (lvlNumber <= data.maxLvlNumber);
        lockImage.SetActive(!(lvlNumber <= data.maxLvlNumber));
    }

    public void LevelSelect()
    {

        if (data.lvlNumber != lvlNumber)
        {
            SaveAndLoad.Instance.isFirstLoad = false;
            SceneManager.LoadScene(lvlNumber);
        }
        else
        {
            Interface.rid.Game();
        }
    }
}

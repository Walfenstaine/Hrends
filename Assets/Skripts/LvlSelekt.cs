using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlSelekt : MonoBehaviour
{
    public GameObject lok;
    public Data data;
    public int lvl;
    public string lvlName;
    private bool activate;
    void Start()
    {
        
        if (lvl < data.lvlNumber)
        {
            lok.SetActive(false);
            activate = true;
        }
        else {
            activate = false;
            lok.SetActive(true);
        }
    }

   
    public void Klik()
    {
        if (activate)
        {
            SceneManager.LoadScene(lvlName);
        }
    }
}

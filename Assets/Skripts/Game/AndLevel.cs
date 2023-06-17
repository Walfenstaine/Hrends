using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AndLevel : MonoBehaviour
{
    public int lvlnum;
    public int lvl;
    public Data data;

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void And()
    {
        data.record += 1;
        data.lvlNumber = lvl;
        if(data.maxLvlNumber < lvl)
        {
            data.maxLvlNumber = lvl;
        }

        SaveAndLoad.Instance.Save();

        SceneManager.LoadScene(lvl);
    }
}

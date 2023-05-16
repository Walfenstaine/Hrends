using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AndLevel : MonoBehaviour
{
    public int lvlnum;
    public string lvl;
    public Data data;

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void And()
    {
        data.record += 1;
        if (lvlnum >= data.lvlNumber)
        {
            data.lvlNumber += 1;
        }

        SaveAndLoad.Instance.Save();

        SceneManager.LoadScene(lvl);
    }
}

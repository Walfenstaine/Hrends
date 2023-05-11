using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obuchenie : MonoBehaviour
{
    public Data data;
    public GameObject[] lesons;
    public int num = 0;
    private void Start()
    {
        if (data.record > 0) {
            Destroy(gameObject);
        }
        num = 0;
    }
    public void NextLeson()
    {
        num += 1;
    }

    void Update()
    {
        if (num > lesons.Length - 1)
        {
            Destroy(gameObject);
        }
        for (int i = 0; i < lesons.Length; i++)
        {
            if (i == num)
            {
                lesons[i].SetActive(true);
            }
            else {
                lesons[i].SetActive(false);
            }
        }
    }
}

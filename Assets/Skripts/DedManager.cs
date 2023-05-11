using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DedManager : MonoBehaviour
{
    public Material[] material;
    public MeshRenderer[] render;
    public Data data;

    void Start()
    {
        for (int i = 0; i < render.Length; i++)
        {
            render[i].material = material[data.num];
        }
    }
    public void Delate()
    {
        Destroy(gameObject);
    }
}

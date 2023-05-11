using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHelsEditor : MonoBehaviour
{
    public BlokInseter inser;
    public Material[] material;
    public MeshRenderer render;
    void Start()
    {
        render.material = material[inser.num];
        inser.helse = material.Length - 1;
    }
    void Update()
    {
        render.material = material[inser.num];
    }
}

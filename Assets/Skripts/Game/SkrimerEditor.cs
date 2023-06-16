using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkrimerEditor : MonoBehaviour
{
    public Image image;

    private void OnEnable()
    {
        image.sprite = Interface.rid.skrimer;
    }
}

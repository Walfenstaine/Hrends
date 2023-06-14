using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkrimerEditor : MonoBehaviour
{
    public Rade rade;
    public Image image;

    private void OnEnable()
    {
        image.sprite = rade.skrimer;
    }
}

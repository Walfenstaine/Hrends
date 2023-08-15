using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalResize : MonoBehaviour
{
    private RectTransform rectTransform;
    private float scale = 1;
    public float normalize = 0.9f;
        
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    
    void Update()
    {
        rectTransform.localScale = new Vector3(scale, scale, scale);
        scale = normalize*(Screen.height / rectTransform.sizeDelta.y);
    }
}

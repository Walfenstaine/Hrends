using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge.Modules.Game;

public class VerticalResize : MonoBehaviour
{
    private RectTransform rectTransform;
    private float scale = 1;
    public float normalize = 0.9f;


    private void Resize()
    {
        scale = normalize * ((float)Screen.height / (float)rectTransform.sizeDelta.y);
        if (scale > 1f)
        {
            scale = 1f;
        }
        rectTransform.localScale = new Vector3(scale, scale, scale);
        
    }

    private void ResizeEvent()
    {
        Resize();
        Invoke("Resize", 0.4f);
    }

    void OnEnable()
    {
        Events.OnResize += ResizeEvent;
        Resize();
    }

    void OnDisable()
    {
        Events.OnResize -= ResizeEvent;
    }

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }


#if UNITY_EDITOR
    void Update()
    {
        Resize();
        Debug.Log("editor");
    }  
#endif
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge.Modules.Game;

public class VerticalPosition: MonoBehaviour
{
    private RectTransform rectTransform;
    public float coordinateY = -20f;
    public float coordinateX = -20f;


    private void Resize()
    {
        float aspect = (float)Screen.height / 800;
        if (aspect > 1)
        {
            aspect = 1;
        }
        rectTransform.anchoredPosition = new Vector3(coordinateX * aspect, coordinateY * aspect, 0);
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
    }  
#endif
}

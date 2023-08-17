using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge.Modules.Game;

public class VerticalResize : MonoBehaviour
{
   
    private RectTransform rectTransform;
    private float scale = 1;
    private float horScale;


    private void Resize()
    {
        float aspect = (float)Screen.height/ (float)Screen.width;
        if (aspect >= 1f)
        {
            scale = 1f;
        }
        else
        {
            scale = horScale * ((float)Screen.height / 800);
            if (scale > horScale)
            {
                scale = horScale;
            }
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
        horScale = rectTransform.localScale.x;
    }


#if UNITY_EDITOR
    void Update()
    {
        Resize();
        Debug.Log("aspect " + (float)Screen.height/ (float)Screen.width);
    }  
#endif
}

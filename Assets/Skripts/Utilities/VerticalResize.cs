using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using InstantGamesBridge.Modules.Game;

public class VerticalResize : MonoBehaviour
{

    public UnityEvent OnHor, OnVert;
    
    private RectTransform rectTransform;
    private float scale = 1;
    private float horScale;
    private bool firstResize = true;


    private void Resize()
    {
        float aspect = (float)Screen.height/ (float)Screen.width;
        if (aspect >= 1.345f)
        {
            scale = 1f;
            OnVert.Invoke();
        }
        else
        {
            scale = horScale * ((float)Screen.height / 800);
            if (scale > horScale)
            {
                scale = horScale;                
            }
            OnHor.Invoke();
        }
        rectTransform.localScale = new Vector3(scale, scale, scale);
        
    }

    private void ResizeEvent()
    {
        Resize();
        Invoke("Resize", 0.2f);
        Invoke("Resize", 0.4f);
    }

    void OnEnable()
    {
        Events.OnResize += ResizeEvent;
        if (!firstResize) 
        {
            Resize();
        }
    }

    void Start()
    {
        Resize();
        firstResize = false;
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

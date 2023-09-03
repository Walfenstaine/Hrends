using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using InstantGamesBridge.Modules.Game;

public class VerticalResize : MonoBehaviour
{

    public UnityEvent OnHor, OnVert;
    


    private void Resize()
    {
        float aspect = (float)Screen.height/ (float)Screen.width;
        if (aspect >= 1.3f)
        {
            OnVert.Invoke();
        }
        else
        {
            OnHor.Invoke();
        }        
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
        Events.OnUnHide += UnHide;
        Resize();
    }



    void OnDisable()
    {
        Events.OnResize -= ResizeEvent;
        Events.OnUnHide -= UnHide;
    }

    void OnApplicationFocus(bool hasFocus)
    {
        Resize();
    }

    void UnHide()
    {
        Resize();
    }




#if UNITY_EDITOR
    void Update()
    {
        Resize();
    }  
#endif
}

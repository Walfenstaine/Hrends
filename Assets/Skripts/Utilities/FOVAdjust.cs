using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge.Modules.Game;

public class FOVAdjust : MonoBehaviour
{
    float initFov;
    Camera myCamera;

    void Awake()
    {
        initFov = 65f;
        myCamera = GetComponent<Camera>();
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

    private void ResizeEvent()
    {
        Resize();
        Invoke("Resize", 0.4f);
    }


    void Resize()
    {
        float aspectRatio = (16f/9f)*((float)Screen.height/(float)Screen.width);       
        float fOV = 2f * Mathf.Rad2Deg*Mathf.Atan(Mathf.Tan(0.5f*initFov * Mathf.Deg2Rad) * aspectRatio);
        if (fOV > 89f)
        {
            fOV = 89f;
        }
        else
        {
            if (fOV < 49f)
            {
                fOV = 49f;
            }
        }
        myCamera.fieldOfView = fOV;
    }

#if UNITY_EDITOR
    void Update()
    {
        Resize();
    }  
#endif
}

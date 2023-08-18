using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivateGameButton : MonoBehaviour
{
    public UnityEvent activateEvent;

    void OnEnable()
    {        
        if (SaveAndLoad.Instance.count >= 4)
        {
            Activate();
        }
        Events.OnGameButtonAppear += Activate;
    }

    void OnDisable()
    {
        Events.OnGameButtonAppear -= Activate;
    }

    void Activate()
    {
        activateEvent.Invoke();
    }
}

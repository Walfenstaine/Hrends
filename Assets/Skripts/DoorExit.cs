using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExit : MonoBehaviour
{
    public bool activate;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (activate)
            {
                Debug.Log("Exit");
            }
            else
            {

            }
        }
    }
}

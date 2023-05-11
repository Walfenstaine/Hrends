using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Interface iF;
    public Transform player;
    void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.Lerp(transform.position, player.position, 10.5f * Time.deltaTime);
        }
        else {
            //iF.Ded();
        }
    }
}

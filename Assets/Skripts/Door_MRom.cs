using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_MRom : MonoBehaviour
{
    public bool activate;
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && activate) {
            anim.SetBool("Open", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && activate)
        {
            anim.SetBool("Open", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_MRom : MonoBehaviour
{
    public bool activate;
    public Animator anim;
    private bool open;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && activate) {
            open = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && activate)
        {
            open = false;
        }
    }

    void Update()
    {
        anim.SetBool("Open", open);
    }
}

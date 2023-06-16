using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Emiter : MonoBehaviour
{
    public AudioClip clip;
    public Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SoundPlayer.regit.sorse.PlayOneShot(clip);
            anim.SetBool("Close", true);
            other.tag = "Block";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Block")
        {
            SoundPlayer.regit.sorse.PlayOneShot(clip);
            anim.SetBool("Close", false);
            other.tag = "Player";
        }
    }
}


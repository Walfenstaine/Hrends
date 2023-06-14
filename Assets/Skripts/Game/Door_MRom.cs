using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge;
public class Door_MRom : MonoBehaviour
{
    [SerializeField] private Language language;
    public AudioClip open, close, locked;
    public bool activate;
    public Animator anim;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            if (activate)
            {
                anim.SetBool("Open", true);
                SoundPlayer.regit.sorse.PlayOneShot(open);
            }
            else
            {
                SoundPlayer.regit.sorse.PlayOneShot(locked);
                if (Bridge.platform.language == "ru")
                {
                    Subtitres.regit.subtitres = language.ru;
                }
                else
                {
                    Subtitres.regit.subtitres = language.en;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && activate)
        {
            SoundPlayer.regit.sorse.PlayOneShot(close);
            anim.SetBool("Open", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge;
public class DoorExit : MonoBehaviour
{
    [SerializeField] private Language language;
    public AudioClip clip;
    public bool activate;
    public Interface iF;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (activate)
            {
                iF.AndLevel();
            }
            else
            {
                if (Bridge.platform.language == "ru")
                {
                    Subtitres.regit.subtitres = language.ru;
                }
                else
                {
                    Subtitres.regit.subtitres = language.en;
                }
                SoundPlayer.regit.sorse.PlayOneShot(clip);
            }
        }
    }
}

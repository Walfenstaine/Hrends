using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge;
public class Key : MonoBehaviour
{
    public AudioClip clip;
    [SerializeField] private Language language;
    public Door_MRom door;
    public DoorExit exit;
    public KeyOfTipe tipe;
    public enum KeyOfTipe {Room, Exit}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SoundPlayer.regit.sorse.PlayOneShot(clip);
            if (Bridge.platform.language == "ru")
            {
               Subtitres.regit.subtitres = language.ru;
            }
            else
            {
                Subtitres.regit.subtitres = language.en;
            }
            if (tipe == KeyOfTipe.Room)
            {
                door.activate = true;
            }
            else {
                exit.activate = true;
            }
            Destroy(gameObject);
        }
    }
}

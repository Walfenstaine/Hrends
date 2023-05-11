using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource source { get; set; }
    [SerializeField] private Data data;
    public static AudioPlayer regit { get; set; }
    void Awake()
    {
        if (regit == null)
        {
            regit = this;
        }
        else
        {
            Destroy(this);
        }

        source = GetComponent<AudioSource>();
    }

    public void Play(AudioClip audioClip)
    {
        if (data.soundOn)
        {
            source.PlayOneShot(audioClip, 1f);
        }
    }

    void OnDisable()
    {
        regit = null;
    }

}
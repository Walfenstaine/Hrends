using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public AudioClip clip;
    public Killer killer;
    public float speed = 15;
    void Start()
    {
        AudioPlayer.regit.Play(clip);
    }
    void Update()
    {
        if (killer != null)
        {
            transform.Rotate(transform.forward * speed);
        }
    }
}

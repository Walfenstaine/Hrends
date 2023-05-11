using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip clip;
    public Interface iF;
    public float interval, timelevel;
    private bool atak;
    private int num;
    private float timer, numer;
    public Killer[] killers;
    public EnemyVisual[] visuals;
    public void Danger()
    {
        atak = true;
        AudioPlayer.regit.Play(clip);
        for (int i = 0; i < visuals.Length; i++)
        {
            visuals[i].enabled = true;
        }
    }
    private void Update()
    {
        if (num < killers.Length)
        {
            if (timer > interval)
            {
                timer = 0;
                killers[num].isActive = true;
                num += 1;
            }
            if (atak)
            {
                timer += Time.deltaTime;
            }
        }
        else
        {
            if (numer < timelevel)
            {
                numer += Time.deltaTime;
            }
            else
            {
                Destroy(this);
                iF.AndLevel();

            }
        }
    }
}

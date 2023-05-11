using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StiveManager : MonoBehaviour
{
    public BlocMuwer bm;
    public AudioClip clip,winer;
    public Interface iF;
    public Animator anim;
    private void Start()
    {
        bm.greedAktive = true;
        anim.SetBool("Idle", false);
        anim.SetBool("Ded", false);
        anim.SetBool("Winer", false);
    }
    public void Stabil()
    {
        bm.greedAktive = false;
        anim.SetBool("Idle", true);
    }
    public void Ded()
    {
        bm.greedAktive = false;
        anim.SetBool("Ded", true);
        iF.Gamover();
        AudioPlayer.regit.Play(clip);
        Destroy(GetComponent<BoxCollider>());
        Destroy(this);
    }
    public void Winer()
    {
        bm.greedAktive = false;
        AudioPlayer.regit.Play(winer);
        anim.SetBool("Winer", true);
    }
}

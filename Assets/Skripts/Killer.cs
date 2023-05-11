using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    public AudioClip clip;
    public GameObject bumb;
    public LayerMask mask;
    public Rigidbody rb;
    public TipOfKiller tipOfKiller;
    public enum TipOfKiller{bullet,bomber}
    public ParticleSystem ps;
    public bool isActive, bum;
    public float speed, maxRadius;
    private float radius = 0;
    private void Update()
    {
        if (tipOfKiller == TipOfKiller.bomber)
        {
            rb.isKinematic = !isActive;
            if (bum)
            {
                Collider[] serch = Physics.OverlapSphere(transform.position, radius, mask);
                if (radius < maxRadius)
                {
                    radius += 30 * Time.deltaTime;
                }
                else {
                    for (int i = 0; i < serch.Length; i++)
                    {
                        Instantiate(bumb, transform.position, Quaternion.identity);
                        Destroy(gameObject);
                        AudioPlayer.regit.Play(clip);
                        if (serch[i].GetComponent<BlokInseter>())
                        {
                            serch[i].GetComponent<BlokInseter>().num += 1;
                        }
                        if (serch[i].GetComponent<StiveManager>())
                        {
                            serch[i].GetComponent<StiveManager>().Ded();
                            
                        }

                    }
                    Instantiate(bumb, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                    AudioPlayer.regit.Play(clip);
                }
            }
        }
        if (tipOfKiller == TipOfKiller.bullet)
        {
            if (isActive)
            {
                transform.position -= transform.up * speed * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (tipOfKiller == TipOfKiller.bomber)
        {
            if (collision.gameObject.tag != "Pnel")
            {
                if (isActive)
                {
                    isActive = false;
                    bum = true;
                }
            }   
        }

            if (tipOfKiller == TipOfKiller.bullet)
        {
            if (collision.gameObject.tag == "Player")
            {
                ps.Play();
                collision.gameObject.GetComponent<StiveManager>().Ded();
                transform.parent = collision.transform;
                Destroy(GetComponent<Rigidbody>());
                Destroy(this);
            }
            if (collision.gameObject.tag == "Block")
            {
                collision.gameObject.GetComponent<BlokInseter>().num += 1;
                Destroy(gameObject);
                AudioPlayer.regit.Play(clip);
            }
            if (collision.gameObject.tag == "Grund")
            {
                transform.parent = collision.transform;
                Destroy(GetComponent<Rigidbody>());
                AudioPlayer.regit.Play(clip);
                Destroy(this);
            }
        }
       
    }
}

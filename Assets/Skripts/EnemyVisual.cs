using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisual : MonoBehaviour
{
    public GameObject prefab;
    public Transform knif;
    public float interval;
    public int bK;
    public Killer kil;
    public Animator anim;
    private float moushen, timer;
    public bool atak = true;
    void Start()
    {

    }

    void Update()
    {
        if (bK < 0) {
            Destroy(this);
        }
        anim.SetFloat("Kik", moushen);
        if (atak)
        {
            timer = 0;
            if (moushen < 1)
            {
                moushen += 5 * Time.deltaTime;
            }
            else
            {
                atak = false;
                Instantiate(prefab, knif.position, knif.rotation);
                bK -= 1;
            }
        }
        else {
            if (moushen > 0)
            {
                moushen -= Time.deltaTime;
            }
            if (timer < interval)
            {
                timer += Time.deltaTime;
            }
            else {
                atak = true;
            }
        }
    }
}

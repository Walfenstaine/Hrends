using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiAI : MonoBehaviour {
	public float speed, stopDist;
	public Animator anim;
	public Transform[] target;
    private int num;
	public NavMeshAgent agent;

    private float timer = 0;

    public FOVArea fOVArea;


    void OnEnable()
    {
        Events.OnDie += Die;
    }

    void OnDisable()
    {
        Events.OnDie -= Die;
    }

    void Die()
    {
        agent.isStopped = true;
        agent.Warp(WarpPoint());
        agent.isStopped = false;
    }


    Vector3 WarpPoint()
    {
        Vector3 warpPoinTemp = target[0].position;
        for(int i = 1; i < target.Length; i++)
        {
            float delta = (warpPoinTemp - Muwer.regit.myTransform.position).sqrMagnitude;
            if (delta < (target[i].position - Muwer.regit.myTransform.position).sqrMagnitude)
            {
                warpPoinTemp = target[i].position;
            }
        }
        return warpPoinTemp;
    }



    void Update () 
    {
        
        
        anim.SetFloat ("Speed", agent.velocity.magnitude/speed);
        if (timer > 0)
        {
            anim.SetBool("Run", false);
            timer -= Time.deltaTime;
            agent.isStopped = true;
        }
        else
        {
            anim.SetBool("Run", true);
            agent.isStopped = false;
        }
        if (Vector3.Distance(target[num].position, transform.position) <= stopDist)
        {
            if (num < target.Length-1)
            {
                num += 1;
                timer = Random.Range(0.7f, 3.0f);
            }
            else {
                num = 0;
            }
        }
        agent.speed = speed;
        agent.destination = target[num].position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fOVArea.Catch();
        }
    }


}

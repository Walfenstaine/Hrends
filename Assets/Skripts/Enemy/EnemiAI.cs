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
        //print("warp");
        agent.isStopped = false;
    }


    Vector3 WarpPoint()
    {
        Vector3 warpPoinTemp = target[0].position;
        for(int i = 1; i < target.Length; i++)
        {
            if(Vector3.Distance(warpPoinTemp, Muwer.regit.myTransform.position) < Vector3.Distance(target[i].position, Muwer.regit.myTransform.position))
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
        else
        {
            //agent.speed = speed;
            
        }
        agent.speed = speed;
        agent.destination = target[num].position;
    }


}

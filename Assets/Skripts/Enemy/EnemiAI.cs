using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiAI : MonoBehaviour {
	public float speed, stopDist;
	public Animator anim;
	public Transform[] target;
    public int num;
	public NavMeshAgent agent;

    private float timer = 0;

    public FOVArea fOVArea;

    private bool isForward = true;

    void Start()
    {
        agent.speed = speed;
        num = 0;
        NextPoint();
    }


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
        NextPoint();
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
                num = i;
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
            NextPoint();
            timer = Random.Range(0.7f, 3.0f);
        }
    }

    void NextPoint()
    {
        if (num == target.Length - 1)
        {
            isForward = false;

        }
        if(num == 0)
        {
            isForward = true;
        }

        if (isForward)
        {
            num++;
        }
        else
        {
            num--;
        }
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

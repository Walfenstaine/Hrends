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


    void Update () {
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

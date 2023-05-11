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



    void Update () {
        anim.SetFloat ("Speed", agent.velocity.magnitude/speed);
        if (Vector3.Distance(target[num].position, transform.position) <= stopDist)
        {
            if (num < target.Length-1)
            {
                num += 1;
            }
            else {
                num = 0;
            }
        }
        else
        {
            //agent.speed = speed;
            //anim.SetBool("Run", true);
        }
        agent.speed = speed;
        agent.destination = target[num].position;
    }
}

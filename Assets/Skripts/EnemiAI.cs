using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiAI : MonoBehaviour {
	public float speed, stopDist, spector;
	public Animator anim;
	public Transform player;
	public NavMeshAgent agent;
    private float radius;
    public LayerMask mask;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.transform;
        }
    }
    public void Serching()
    {
        Collider[] serch = Physics.OverlapSphere(transform.position, radius, mask);
        if (serch.Length > 0)
        {
            player = serch[0].transform;
        }
        if (radius < spector)
        {
            radius += spector * 10 * Time.deltaTime;
        }
        else
        {
            radius = 0;
        }
    }
    void Update () {
        anim.SetFloat ("Speed", agent.velocity.magnitude/speed);
        if (player != null)
        {
            if (Vector3.Distance(player.position, transform.position) <= stopDist)
            {
                agent.speed = 0;
                anim.SetBool("Kik", true);
            }
            else {
                agent.speed = speed;
                anim.SetBool("Run", true);
                anim.SetBool("Kik", false);
            }
            agent.destination = player.position;
        }
        else
        {
            Serching();
            agent.speed = 0;
            anim.SetBool("Run", false);
            anim.SetBool("Kik", false);
        }
	}
}

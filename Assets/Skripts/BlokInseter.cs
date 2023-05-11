using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlokInseter : MonoBehaviour
{
    public AudioClip clip;
    public Rigidbody rb;
    public GameObject[] bHE;
    public GameObject ded;
    public int helse = 1;
    public int num;
    public Data data;
    private int indexer;
    
    void Start()
    {
        for (int i = 0; i < bHE.Length; i++)
        {
            if (i == data.num)
            {
                bHE[i].SetActive(true);
            }
            else
            {
                bHE[i].SetActive(false);
            }
        }
        AudioPlayer.regit.Play(clip);
        indexer = data.num;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<StiveManager>().Ded();
            Instantiate(ded, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void Activate()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.up);
        if (Physics.Raycast(ray, out hit, 1.2f))
        {
            if (hit.collider.tag == "Block")
            {
                hit.collider.GetComponent<BlokInseter>().Activate();
            }
        }
        rb.isKinematic = false;
    }
    void Update()
    {
        if (num > helse)
        {
            Activate();
            data.num = indexer;
            Instantiate(ded, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

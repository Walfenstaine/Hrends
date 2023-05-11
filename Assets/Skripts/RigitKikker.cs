using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigitKikker : MonoBehaviour
{
    public float fors;
    public Rigidbody rb;
    void Start()
    {
        rb.AddForce(transform.forward * fors);
    }
    private void Update()
    {
        if (rb.velocity.magnitude > 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rb.velocity), 5.5f * Time.deltaTime);
        }
    }
}

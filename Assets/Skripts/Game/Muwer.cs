using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muwer : MonoBehaviour {

    [HideInInspector] public Transform myTransform;
    public Animator anim;
    public Transform bodey;
	public Vector3 muve;
	public float speed = 6.0f, coeficient = 0.3f;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
    public static Muwer regit { get; set; }


    void Awake()
    {
        if (regit == null)
        {
            regit = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void OnDestroy()
    {
        regit = null;
    }

    void Start () 
    {
		controller = GetComponent<CharacterController>();
        myTransform = transform;
    }

	void Update() {
		if (controller.isGrounded) {
            anim.SetFloat("Speed", controller.velocity.magnitude / speed * coeficient);
            if (controller.velocity.magnitude > 1.1f)
            {
                anim.SetBool("Run", true);
                Vector3 looker = new Vector3(controller.velocity.x, 0, controller.velocity.z);
                if (looker != Vector3.zero)
                {
                    bodey.rotation = Quaternion.Lerp(bodey.rotation, Quaternion.LookRotation(looker), 10.5f * Time.deltaTime);
                }
            }
            else
            {
                anim.SetBool("Run", false);
            }
            moveDirection = muve;
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;

		} else {
			moveDirection.y -= gravity * Time.deltaTime;
		}

		controller.Move (moveDirection * Time.deltaTime);
	}
}

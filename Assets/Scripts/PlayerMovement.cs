using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Use this for initialization
    public float moveSpeed = 3f;
    public float turnSpeed = 1f;
    public float maxSpeed = 20f;
    public Vector3 vel;
    //public Vector3 movement;
    Rigidbody rb;
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

	}
    void FixedUpdate()
    {
        transform.Rotate(transform.up * turnSpeed * Input.GetAxis("Horizontal") * Time.fixedDeltaTime);
        if (rb.velocity.magnitude <= maxSpeed)
        {
            rb.AddForce(transform.forward * moveSpeed);
        }
    }
}

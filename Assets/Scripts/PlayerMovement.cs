using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Use this for initialization
    public float moveSpeed = 3f;
    public float turnSpeed = 1f;
    public float maxSpeed = 20f;
    public Vector3 movement;
    Rigidbody rb;
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        movement = new Vector3(0, 0, 1);
        transform.Rotate(transform.up * turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        if (rb.velocity.magnitude <= maxSpeed)
            rb.AddForce(transform.forward * moveSpeed);
	}
}

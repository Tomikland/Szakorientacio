using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Use this for initialization
    public float moveSpeed = 3f;
    public float maxSpeed = 3f;
    public float turnSpeed = 1f;
    public float jumpForce = 1f;
    public float maxTurn = 50f;
    private Vector3 startPos;
    private Rigidbody rb;
    private Quaternion startRot;
    int i = 0;

    void Start () {
        startPos = transform.position;
        startRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Physics.Raycast(rb.position, Vector3.down, out hit);
        if (Input.GetKeyDown(KeyCode.Space) && hit.distance == 0)
        {
            rb.AddRelativeForce(Vector3.up * jumpForce);
            Debug.Log("JUMP BITCHEEEES!" + i++);
        }
    }
	// Update is called once per frame
	void Update () 
    {
        //Moving to the direction we are facing at
        if (rb.velocity.magnitude < maxSpeed)
            rb.AddRelativeForce(Vector3.forward * moveSpeed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        //Just for development purposes
        if (transform.position.y < -3)
        {
            ResetPlayer();
        }
    }
    public void ResetPlayer()
    {
        transform.position = startPos;
        rb.velocity = Vector3.zero;
        transform.rotation = startRot;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Use this for initialization
    public float moveSpeed = 3f;
    public float turnSpeed = 1f;
    public float maxTurn = 50f;
    private Vector3 startPos;
    private Rigidbody rb;
    private Quaternion startRot;

    void Start () {
        startPos = transform.position;
        startRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        //Moving to the direction we are facing at
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
        transform.Rotate(0, Input.GetAxis("Horizontal") * maxTurn * Time.deltaTime, 0);

        //Just for developping purposes
        if (transform.position.y < -3)
        {
            transform.position = startPos;
            rb.velocity = Vector3.zero;
            transform.rotation = startRot;
        }
    }
}

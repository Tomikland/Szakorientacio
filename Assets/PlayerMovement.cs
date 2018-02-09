using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Use this for initialization
    public float moveSpeed = 3f;
    public float turnSpeed = 1f;
    public float maxSpeed = 20f;
    public Vector3 startPosition;
    public float maxTurn = 50f;
    private float fixedRotation;
    Rigidbody rb;

    void Clamp(float val , float min , float max)
    {
        if (val < min)
            val = min;
        else if (val >= max)
            val = max;
    }

    void Start () {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        fixedRotation = rb.rotation.eulerAngles.y;
    }
	
	// Update is called once per frame
	void Update () {
        float rotY = rb.rotation.eulerAngles.y;
        if (rotY >= fixedRotation - maxTurn && rotY <= fixedRotation + maxTurn)
            transform.Rotate(transform.up * turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        else if (rotY < fixedRotation - maxTurn)
            transform.rotation = Quaternion.Euler(0, fixedRotation - maxTurn, 0);
        else if (rotY > fixedRotation + maxTurn)
            transform.rotation = Quaternion.Euler(0, fixedRotation + maxTurn, 0);

        if (rb.velocity.magnitude <= maxSpeed)
            rb.AddForce(transform.forward * moveSpeed);

        //Just for development
        if (rb.position.y < -2)
        {
            transform.position = startPosition;
            rb.velocity = new Vector3(0 , 0 , 0);
            rb.rotation = Quaternion.Euler(0f , -90f , 0f);
        }
	}
}

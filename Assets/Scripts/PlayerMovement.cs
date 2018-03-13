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
    public float maxMultiplier = 0.1f;
    public float moveMultiplier = 0.1f;
    public bool gameOn = true;
    private Vector3 startPos;
    private Rigidbody rb;

    public Vector3 CoM = Vector3.zero;
    private Quaternion startRot;
    private GameManager gm;
    int i = 0;

    void Start () {

        startPos = transform.position;
        startRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
        gm = GetComponent<GameManager>();

        rb.centerOfMass = CoM;
    }

    void FixedUpdate()
    {
        if (gm.gameOn)
        {
            RaycastHit hit;
            Physics.Raycast(rb.position, Vector3.down, out hit);
            if (transform.position.x <= -18)
            {
                if (Input.GetKeyDown(KeyCode.Space) && hit.distance < 0.05f)
                    rb.AddRelativeForce(Vector3.up * jumpForce);
                transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.fixedDeltaTime, 0);
            }
            maxSpeed += Mathf.Abs(Time.fixedDeltaTime) * maxMultiplier;
            moveSpeed += Mathf.Abs(Time.fixedDeltaTime) * moveMultiplier;
            if (rb.velocity.magnitude < maxSpeed)
                rb.AddRelativeForce(Vector3.forward * moveSpeed * Time.fixedDeltaTime);
        }
    }


    public void ResetPlayer()
    {
        transform.position = startPos;
        rb.velocity = Vector3.zero;
        transform.rotation = startRot;
    }
}

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
    //public bool gameOn = true;
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
        Vector3 force = Vector3.zero;

        if (gm.gameOn)
        {

            if ( transform.position.x <= -18) {
                transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.fixedDeltaTime, 0);
            }
            maxSpeed += Mathf.Abs(Time.fixedDeltaTime) * maxMultiplier;
            moveSpeed += Mathf.Abs(Time.fixedDeltaTime) * moveMultiplier;
            if (rb.velocity.magnitude < maxSpeed)
            {

                force = Vector3.forward * moveSpeed * Time.fixedDeltaTime;
                force = transform.TransformDirection(force);
                force.y = 0;

                rb.AddForce(force);
            }

            Vector3 rot = transform.rotation.eulerAngles;
            rot.z = 0;
            transform.rotation = Quaternion.Euler(rot);
        }
    }

    public void Update()
    {
        if (gm.gameOn && transform.position.x <= -18) {

            RaycastHit hit;
            Physics.Raycast(rb.position, Vector3.down, out hit);
            if (Input.GetKeyDown(KeyCode.Space) && (hit.distance < 0.1f || hit.distance > 1000f))
                rb.AddRelativeForce(Vector3.up * jumpForce);

        }
    }


    public void ResetPlayer()
    {
        transform.position = startPos;
        rb.velocity = Vector3.zero;
        transform.rotation = startRot;
    }
}

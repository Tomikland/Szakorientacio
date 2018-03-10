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
    public bool gameOn = true;
    private Vector3 startPos;
    private Rigidbody rb;
    private Quaternion startRot;
    private GameManager gm;
    int i = 0;

    void Start () {
        startPos = transform.position;
        startRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
        gm = GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        if (gm.gameOn)
        {
            RaycastHit hit;
            Physics.Raycast(rb.position, Vector3.down, out hit);
            if (transform.position.x <= -18)
            {
                if (Input.GetKeyDown(KeyCode.Space) && hit.distance < 0.01)
                    rb.AddRelativeForce(Vector3.up * jumpForce);
                transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.fixedDeltaTime, 0);
            }
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

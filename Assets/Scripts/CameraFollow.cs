using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    PlayerMovement player;
    public Vector3 posOffset = Vector3.zero;
    public Vector3 mimicRot = Vector3.zero;
    public Vector3 rotOffset = Vector3.zero;


    public float startTime;
    public float speed;
    public float rotSpeed;
    public Vector3 startPosition;
    public Quaternion startRot;

    float animationTime = 1f;


    public bool follow = false;
    public bool animation = false;
	// Use this for initializations
	void Start () {
        player = GameObject.FindObjectOfType<PlayerMovement>();
        startPosition = transform.position;
        startRot = transform.rotation;
	}
	
        Vector3 endpos;
	// Update is called once per frame
	void Update () {


        if (follow == true)
        {
            Vector3 pos = player.transform.position;
            pos.x += posOffset.x;
            pos.z += posOffset.z;

            pos.y = posOffset.y;
            transform.position = pos;
            

            if (mimicRot.sqrMagnitude < 0.01)
            {
                /*
                Vector3 EuA = player.transform.rotation.eulerAngles;

                Debug.Log("rotation:"+EuA);
                float x = EuA.x * mimicRot.x + rotOffset.x;
                float y = EuA.y * mimicRot.y + rotOffset.y;
                float z = EuA.z * mimicRot.z + rotOffset.z;
                Debug.Log("x:"+x);
                transform.Rotate(x, y, z);
                */
            }
        }
        if(animation == true)
        {
            endpos = player.transform.position + posOffset;
            float distance = Vector3.Distance(transform.position, endpos);
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / distance;

            transform.position = Vector3.Lerp(transform.position, endpos, fracJourney+0.01f);

            if(Vector3.Distance(transform.position, endpos) < 0.01f){
                animation = false;
                Debug.Log("Animation ended");
                follow = true;
            }

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * rotSpeed);

        }
	}

    public void ResetCamera()
    {
        transform.position = startPosition;
        transform.rotation = startRot;
    }

    public void StartAnimation()
    {
        startTime = Time.time;
        animation = true;
    }
}

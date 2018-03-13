using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    PlayerMovement player;
    public Vector3 posOffset = Vector3.zero;
    public Vector3 mimicRot = Vector3.zero;
    public Vector3 rotOffset = Vector3.zero;
	// Use this for initializations
	void Start () {
        player = GameObject.FindObjectOfType<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = player.transform.position;
        pos.x += posOffset.x;
        pos.z += posOffset.z;

        pos.y = posOffset.y;
        transform.position = pos;

        if(mimicRot.sqrMagnitude < 0.01)
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
}

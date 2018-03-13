using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFollowPlayer : MonoBehaviour {

    PlayerMovement player;
    public Vector3 posOffset = Vector3.zero;
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

	}
}

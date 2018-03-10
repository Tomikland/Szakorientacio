using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFollowPlayer : MonoBehaviour {

    PlayerMovement player;
	// Use this for initializations
	void Start () {
        player = GameObject.FindObjectOfType<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = player.transform.position;
        pos.y = 0;
        transform.position = pos;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private float score;
    Vector3 startPos;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void EndGame()
    {
        score = Mathf.Ceil(Mathf.Abs(transform.position.x));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Floor")
        {
            EndGame();
        }
    }
}

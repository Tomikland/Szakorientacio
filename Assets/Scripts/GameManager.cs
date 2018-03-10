using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float explForce = 5.0f;
    private float score;
    Vector3 startPos;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void EndGame()
    {
        score = Mathf.Ceil(Mathf.Abs(transform.position.x));
        Transform pm = transform.FindChild("PlayerModel");
        List<Rigidbody> crbs = new List<Rigidbody>();
        for (int i = 0; i < pm.childCount; i++)
        {
            Transform child = pm.GetChild(i);
            child.gameObject.AddComponent<Rigidbody>();            
            Rigidbody crb = child.GetComponent<Rigidbody>();
            crbs.Add(crb);
        }
        pm.DetachChildren();
        foreach (Rigidbody crb in crbs)
            crb.AddRelativeForce(Vector3.up * explForce);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Floor")
        {
            EndGame();
        }
    }
}

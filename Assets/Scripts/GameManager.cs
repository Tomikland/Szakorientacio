using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float explForce = 5.0f;
    private float score;
    public bool gameOn = true;
    public bool was = false;
    Vector3 startPos;
    Rigidbody rb;
    public BiomeManager bm;
    // Use this for initialization
    void Start() {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {

    }

    void EndGame()
    {
        if (was == false)
        {
            was = true;
            score = Mathf.Ceil(Mathf.Abs(transform.position.x));
            Transform pm = transform.FindChild("PlayerModel");
            if (pm != null)
            {
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
                gameOn = false;
                rb.isKinematic = true;
            }
        }
    }

    void ResetGame()
    {
        bm.biomeNum = 0;
        transform.position = startPos;
        rb.velocity = Vector3.zero;
        //rb.isKinematic = false;
        foreach (GameObject biome in bm.biomes)
            GameObject.Destroy(biome);
        bm.biomes.Clear();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Floor" && was == false)
        {
            EndGame();
            //TODO : Some delay here
            ResetGame();
        }
    }
}

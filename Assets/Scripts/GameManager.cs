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
    Quaternion startRot;
    List<GameObject> partOb = new List<GameObject>();
    public GameObject pmPrefab; 
    public BiomeManager bm;
    // Use this for initialization
    void Start() {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        startRot = transform.rotation;
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
                    partOb.Add(child.gameObject);
                    Rigidbody crb = child.GetComponent<Rigidbody>();
                    crbs.Add(crb);
                }
                partOb.Add(pm.gameObject);
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
        rb.velocity = Vector3.zero;
        transform.position = startPos;
        transform.rotation = startRot;
        foreach (GameObject ob in partOb)
            GameObject.Destroy(ob);

        GameObject go = Instantiate(pmPrefab , transform.position + new Vector3(0 , 0.5f , 0) , transform.rotation , this.gameObject.transform);
        go.name = "PlayerModel";
        rb.isKinematic = false;
        foreach (GameObject biome in bm.biomes)
            GameObject.Destroy(biome);
        bm.biomes.Clear();
        was = false;
        gameOn = true;
    }

    IEnumerator sec(float time)
    {
        yield return new WaitForSeconds(time);
        ResetGame();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Floor" && was == false)
        {
            EndGame();
            //TODO : Button press -> ResetGame();
            StartCoroutine(sec(3));
        }
    }
}

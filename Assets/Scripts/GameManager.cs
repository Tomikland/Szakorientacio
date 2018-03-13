using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float explForce = 5.0f;
    private float maxSpeed;
    private float moveSpeed;
    public bool gameOn = true;
    public bool was = false;
    Vector3 startPos;
    Rigidbody rb;
    Quaternion startRot;
    List<GameObject> partOb = new List<GameObject>();
    public GameObject pmPrefab; 
    public BiomeManager bm;
    public CameraFollow cf;


    int score = 0;
    int highscore = 0;
    public TextMesh tm;
    public Text scoretext;

    // Use this for initialization
    void Start() {
        maxSpeed = GetComponent<PlayerMovement>().maxSpeed;
        moveSpeed = GetComponent<PlayerMovement>().moveSpeed;
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        startRot = transform.rotation;
        cf = GameObject.FindObjectOfType<CameraFollow>();
    }

    // Update is called once per frame
    void Update() {
        score = Mathf.FloorToInt(Mathf.Abs(transform.position.x)/20);
        scoretext.text = "Szkór: "+score;

        if (gameOn == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //raycast and stuff

                //camera animation and shit
                gameOn = true;
                cf.StartAnimation();
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && gameOn == true)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        if (was == false)
        {
            StartCoroutine(sec(3));

            was = true;
            Transform pm = transform.Find("PlayerModel");
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
                cf.follow = false;

                if (score > highscore) highscore = score;

                tm.text = "Hájszkór: " + highscore.ToString();
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
        GetComponent<PlayerMovement>().moveSpeed = moveSpeed;
        GetComponent<PlayerMovement>().maxSpeed = maxSpeed;
        was = false;

        cf.ResetCamera();
        //gameOn = true;
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
            
        }
    }
}

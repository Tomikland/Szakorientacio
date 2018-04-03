using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biome_Trees : Biome {

    public Transform treePrefab;
    public Transform trunkPrefab;
    public int treeCount = 10;
    public int trunkCount = 5;

    // Use this for initialization
    void Start() {
        parent = this.transform;
        Spawn();
    }

    public Biome_Trees()
    {

    }

    // Update is called once per frame
    void Update () {
	    
	}

    public override void Spawn()
    {
        base.Spawn();

        for (int i = 0; i < treeCount; i++)
        {
            Vector3 pos = transform.position + new Vector3(Random.Range(-10,10), 0, Random.Range(-12, 12));
            GameObject go = Instantiate(treePrefab, pos, Quaternion.identity, parent).gameObject;

            float scaleX = Random.Range(0.7f, 1.2f);
            float scaleY = Random.Range(0.7f, 1f);
            go.transform.localScale = new Vector3(scaleX,scaleY,scaleX);

            biomeObjects.Add(go);
            
        }
        for (int i = 0; i < trunkCount; i++)
        {
            Vector3 pos = transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-12, 12));
            GameObject go = Instantiate(trunkPrefab, pos, Quaternion.identity, parent).gameObject;

            float scaleX = Random.Range(0.8f, 1.1f);
            float scaleY = Random.Range(1f, 1.3f);
            go.transform.localScale = new Vector3(scaleX, scaleY, scaleX);

            biomeObjects.Add(go);

        }
    }
}

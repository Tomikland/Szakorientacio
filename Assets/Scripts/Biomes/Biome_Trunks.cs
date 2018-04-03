using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biome_Trunks : Biome
{

    public Transform treePrefab;
    public Transform trunkPrefab;
    public Transform rockPrefab;
    public int treeCount = 0;
    public int trunkCount = 12;
    public int rockCount = 6;
    

    // Use this for initialization
    void Start()
    {
        parent = this.transform;
        Spawn();
    }

    public Biome_Trunks()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Spawn()
    {
        base.Spawn();

        RandomlySpawn(treePrefab, treeCount, 0.7f, 1.2f, 0.7f, 1f);
        RandomlySpawn(trunkPrefab, trunkCount, 0.8f, 1.3f, 1f, 1.3f);
    }

    void RandomlySpawn(Transform prefab, int count, float scaleXmin, float scaleXmax, float scaleYmin,float  scaleYmax, float xLimit = 10, float yLimit = 14)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = transform.position + new Vector3(Random.Range(-xLimit, xLimit), 0, Random.Range(-yLimit, yLimit));
            GameObject go = Instantiate(prefab, pos, Quaternion.identity, parent).gameObject;

            float scaleX = Random.Range(scaleXmin, scaleXmax);
            float scaleY = Random.Range(scaleYmin, scaleYmax);
            go.transform.localScale = new Vector3(scaleX, scaleY, scaleX);

            biomeObjects.Add(go);

        }
    }
}
